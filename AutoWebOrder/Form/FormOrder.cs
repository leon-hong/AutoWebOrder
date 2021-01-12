using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

using AutoWebOrder.Main;
using AutoWebOrder.Util;

namespace AutoWebOrder
{


    public partial class FormOrder : Form
    {

        private MainControl m_mainCon;
        private CbOnChangeWorkState m_cbOnChangeWorkState;
        private CbOnErrorWorkNode m_cbOnErrorWorkNode;
        private CbOnFinishOrderItem m_cbOnFinishOrderItem;

        private Color m_colRdy = Color.FromArgb(128, 128, 128);
        private Color m_colFin = Color.FromArgb(128, 255, 128);
        private Color m_colErr = Color.FromArgb(255, 128, 128);

        Thread m_thread;

        private bool m_bOrderOK = true;

        public FormOrder()
        {
            InitializeComponent();
        }

        ~FormOrder()
        {

        }


        private void FormOrder_Load(object sender, EventArgs e)
        {
            m_cbOnChangeWorkState = new CbOnChangeWorkState(OnChangeWorkState);
            m_cbOnErrorWorkNode = new CbOnErrorWorkNode(OnErrorWorkNode);
            m_cbOnFinishOrderItem = new CbOnFinishOrderItem(OnFinishOrderItem);
        }
        
        public void Init(MainControl mainControl)
        {
            m_mainCon = mainControl;

            m_bOrderOK = true;
            // 공급사 출력
            this.Text = "상세 주문 - " + mainControl.m_orderData.seller;

            // 전체 작업 상태 초기화
            btnStatLogin.BackColor = m_colRdy;
            btnStatInitCart.BackColor = m_colRdy;
            btnStatPayment.BackColor = m_colRdy;

            // 리스트 주문 상태 출력
            OrderData orderData = m_mainCon.m_orderData;
            for (int i = 0; i < orderData.GetCount(); i++)
            {
                ListViewItem item = new ListViewItem(orderData.listSerial[i]);
                item.SubItems.Add(orderData.listName[i]);
                item.SubItems.Add(orderData.listAmount[i]);
                item.SubItems.Add("0");
                item.SubItems.Add(orderData.listCategory[i]);
                item.SubItems.Add(orderData.listCode[i]);
                item.SubItems.Add("대기");
                listOrder.Items.Add(item);
            }

            // 스레드로 작업을 해야 UI를 업데이트 할 수 있음
            m_thread = new Thread(new ThreadStart(RunThread));
            m_thread.Start();            
        }

        void RunThread()
        {
            m_mainCon.StartWebOrder(m_cbOnChangeWorkState, m_cbOnErrorWorkNode, m_cbOnFinishOrderItem);
        }

        // 작업 상태가 변경될 경우 호출할 콜백
        void OnChangeWorkState(TYPE_WORK prev, TYPE_WORK cur, string msg)
        {
            string log = "work state convert : " + prev.ToString() + " to " + cur.ToString();
            if ("" == msg)
            {
                m_mainCon.m_logger.OutputInfo(log);
            }
            else
            {
                m_mainCon.m_logger.OutputInfo(log + " - " + msg);
            }

            // 작업 완료 상황에 맞추어 색상을 변경함
            if (TYPE_WORK.Login == prev && TYPE_WORK.ClearCart == cur)
            {
                btnStatLogin.BackColor = m_colFin;
            }
            else if (TYPE_WORK.ClearCart == prev && TYPE_WORK.CheckOrderItem == cur)
            {
                btnStatInitCart.BackColor = m_colFin;
            }
            else if (TYPE_WORK.CheckOrderItem == prev && TYPE_WORK.Payment == cur)
            {
                if (m_bOrderOK)
                {
                    btnStatPayment.BackColor = m_colFin;
                }
                else
                {
                    btnStatPayment.BackColor = m_colErr;
                }
            }
            else if (TYPE_WORK.Payment == prev && TYPE_WORK.Complete == cur)
            {
                // 작업이 끝났을때 처리.
                // 주문 상태를 엑셀로 출력.
                string inpath = m_mainCon.m_orderData.pathOrder;
                string outDir = Path.GetDirectoryName(inpath);
                string fileName = Path.GetFileNameWithoutExtension(inpath);
                string time = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
                string outPath = outDir + "\\" + fileName + " - result(" + m_mainCon.m_orderData.seller + ")-" + time + "-.xlsx";

                UtilExcel.ListViewToExcel(this.listOrder, outPath);

                MessageBox.Show("작업 완료.");
            }
        }

        // 제품 항목 주문을 마칠때 호출할 콜백
        // itemId : 해당 아이템의 ID
        // cntLeft : 주문하지 못하고 남은 갯수, 이 값이 "0"이 아니면 주문이 제대로 되지 않은 것
        void OnFinishOrderItem(string serialNum, int cntLeft)
        {
            //// MessageBox.Show("주문 완료 : " + itemId + " - 남은 주문량 : " + cntLeft.ToString());
            //// 리스트를 돌면서 해당 항목에 대하여 체크 해 줌.

            if (listOrder.InvokeRequired)
            {
                listOrder.Invoke(new MethodInvoker(delegate
                {
                    foreach (ListViewItem item in listOrder.Items)
                    {
                        string sn = item.SubItems[0].Text;
                        if (serialNum == sn)
                        {
                            int cntOrder = int.Parse(item.SubItems[2].Text);
                            item.SubItems[3].Text = (cntOrder - cntLeft).ToString();

                            if ( 0 == cntLeft)
                            {
                                item.SubItems[6].Text = "완료";
                                item.BackColor = m_colFin;
                            }
                            else
                            {
                                m_bOrderOK = false;
                                item.SubItems[6].Text = "실패";
                                item.BackColor = m_colErr;
                            }
                            break;
                        }
                    }
                }));
            }
            else {
                foreach (ListViewItem item in listOrder.Items)
                {
                    string sn = item.SubItems[0].Text;
                    if (serialNum == sn)
                    {
                        int cntOrder = int.Parse(item.SubItems[2].Text);
                        item.SubItems[3].Text = (cntOrder - cntLeft).ToString();

                        if (cntOrder - cntLeft == 0)
                        {
                            item.SubItems[6].Text = "완료";
                            item.BackColor = m_colFin;
                        }
                        else
                        {
                            m_bOrderOK = false;
                            item.SubItems[6].Text = "실패";
                            item.BackColor = m_colErr;
                        }
                        break;
                    }
                }
            }


        }

        // 작업 도중 에러 발생시 호출할 콜백
        // 에러 발생하면 중지 시키고 사용자에게 메시지 출력
        void OnErrorWorkNode(TYPE_WORK type, string msg)
        {
            MessageBox.Show(msg);
            m_mainCon.m_logger.OutputError("FormOrder::OnErrorWorkNode", msg);
            Application.Exit();
        }

    }
}
