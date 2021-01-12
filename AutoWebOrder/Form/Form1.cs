using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoWebOrder.Main;
using AutoWebOrder.Util;

namespace AutoWebOrder
{

    // 작업 상태가 변경될 경우 호출할 콜백
    public delegate void CbOnChangeWorkState(TYPE_WORK prev, TYPE_WORK cur, string msg);

    // 작업 도중 에러 발생시 호출할 콜백
    public delegate void CbOnErrorWorkNode(TYPE_WORK type, string msg);

    // 아이템 주문을 마쳤을 경우 호출할 콜백
    public delegate void CbOnFinishOrderItem(string serialNum, int cntLeft);

    public partial class MainForm : Form
    {
        private MainControl m_mainCon;
        //private CbOnChangeWorkState m_cbOnChangeWorkState;
        //private CbOnErrorWorkNode m_cbOnErrorWorkNode;
        //private CbOnFinishOrderItem m_cbOnFinishOrderItem;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            m_mainCon = new MainControl();
        }

        private void btn_test_Click(object sender, EventArgs e)
        {
            // m_mainCon.StartWebOrder(m_cbOnChangeWorkState, m_cbOnErrorWorkNode, m_cbOnFinishOrderItem);
            FormOrder formOrder = new FormOrder();            
            formOrder.Show();
            formOrder.Init(m_mainCon);
        }
        
        private void btnOrder_Click(object sender, EventArgs e)
        {

            OpenFileDialog OFD = new OpenFileDialog();
            if (OFD.ShowDialog() == DialogResult.OK)
            {

                edtOrder.Text = OFD.FileName;
                string filepath = OFD.FileName;
                //edtOrder.Text = @"D:\Project\Auto web order\Doc\주문상품리스트.xls";

                // 엑셀 파일 찾기
                OrderData orderData = new OrderData();
                orderData.pathOrder = filepath;

                // 엑셀 파일 열기. 엑셀은 시작 인덱스가 1 임
                UtilExcel.GetColumDatas(filepath
                    , 1, orderData.listSerial
                    , 2, orderData.listName
                    , 4, orderData.listAmount
                    , 6, orderData.listCategory
                    , 7, orderData.listCode
                    , 8, orderData.listSeller );

                // 디엠 사이트만 필터링
                orderData.FilterBySeller("디엠");

                //// 주문 아이템 로드            
                //m_listOrderItem.Add(new OrderItem("111111111111", 1));  // 존재하지 않는 물건
                //m_listOrderItem.Add(new OrderItem("3600523399826", 1)); // 재고없는 물건
                //m_listOrderItem.Add(new OrderItem("4058172337215", 2));
                //m_listOrderItem.Add(new OrderItem("3574661264202", 17));// 주문 안되는 수량            

                // 리스트뷰 업데이트
                for (int i = 0; i < orderData.GetCount(); i++){

                    ListViewItem item = new ListViewItem(orderData.listSerial[i]);
                    item.SubItems.Add(orderData.listName[i]);
                    item.SubItems.Add(orderData.listAmount[i]);
                    item.SubItems.Add(orderData.listCategory[i]);
                    item.SubItems.Add(orderData.listSeller[i]);
                    item.SubItems.Add(orderData.listCode[i]);                
                    listOrder.Items.Add(item);
                }

                m_mainCon.m_orderData = orderData;

            }
            
        }
    }
}

