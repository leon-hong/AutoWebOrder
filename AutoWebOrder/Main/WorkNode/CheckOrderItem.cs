using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutoWebOrder.Main.WorkNode
{
    class CheckOrderItem : WorkNodeBase
    {
        public override void Execute(WorkNodeArgment arg)
        {

            // 작업노드 시작시 수행루틴
            arg.cbOnChangeWorkState(arg.prevType, m_type, "");
            ChromeDriver driver = arg.seleMgr.GetDriver();
            Util.Logger logger = arg.logger;

            // 작업수행
            

            // 주문할 아이템이 존재하면 장바구니 담기로 이동
            // 존재하지 않으면 결제 화면으로 이동
            if (arg.orderData.GetCount() > 0)
            {                
                arg.prevType = m_type;
                m_workManager.GoNextWork(TYPE_WORK.AddItemToCart, arg);
            }
            else
            {
                arg.prevType = m_type;
                m_workManager.GoNextWork(TYPE_WORK.Payment, arg);
            }
            
        }
    }
}
