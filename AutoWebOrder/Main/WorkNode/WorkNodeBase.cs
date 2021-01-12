using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoWebOrder;
using AutoWebOrder.Util;

namespace AutoWebOrder.Main
{

    struct WorkNodeArgment {
        public TYPE_WORK prevType;
        public SeleniumManager seleMgr;
        public Logger logger;
        public OrderData orderData;    // 주문 리스트

        public CbOnChangeWorkState cbOnChangeWorkState;     // 작업 노드가 변경될때 호출될 콜백
        public CbOnErrorWorkNode cbOnErrorWorkNode;         // 작업 도중 에러가 발생할때 호출될 콜백
        public CbOnFinishOrderItem cbOnFinishOrderItem;     // 아이템 하나를 주문 처리가 끝났을때 호출될 콜백
    }

    class WorkNodeBase
    {
        protected TYPE_WORK m_type;
        protected WorkManager m_workManager;

        public void Init(TYPE_WORK type, WorkManager workManager) {
            m_type = type;
            m_workManager = workManager;
        }

        public virtual void Execute(WorkNodeArgment arg) { }
    }
}
