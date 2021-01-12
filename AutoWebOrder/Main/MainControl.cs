using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium.Chrome;

using AutoWebOrder.Util;

namespace AutoWebOrder.Main
{
    public class MainControl
    {
        private WorkManager m_workManager = null;
        private SeleniumManager m_seleManager = null;
        public Logger m_logger = null;
        public OrderData m_orderData { set; get; }    // 주문할 물건 항목

        public MainControl() {
            m_logger = new Logger();            
            m_workManager = new WorkManager();
            m_seleManager = new SeleniumManager();
        }

        ~MainControl()
        {
            m_seleManager.GetDriver().Close();
        }

        public void StartWebOrder(CbOnChangeWorkState cbOnChangeWorkState, CbOnErrorWorkNode cbOnErrorWorkNode, CbOnFinishOrderItem cbOnFinishOrderItem) {
            m_logger.OutputInfo("start web ordering");

            if (0 == m_orderData.GetCount()) {
                cbOnChangeWorkState(TYPE_WORK.Start, TYPE_WORK.Start, "주문 항목이 없습니다.");
                return;
            }

            // 주문 시작
            WorkNodeArgment arg = new WorkNodeArgment();
            arg.prevType = TYPE_WORK.Start;
            arg.logger = m_logger;
            arg.seleMgr = m_seleManager;
            arg.orderData = m_orderData;
            arg.cbOnChangeWorkState = cbOnChangeWorkState;
            arg.cbOnErrorWorkNode = cbOnErrorWorkNode;
            arg.cbOnFinishOrderItem = cbOnFinishOrderItem;

            m_workManager.StartWork(arg);
        }

    }
}
