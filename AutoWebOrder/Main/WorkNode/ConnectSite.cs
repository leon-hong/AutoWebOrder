using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoWebOrder.Main;

using System.Threading;
using OpenQA.Selenium.Chrome;

namespace AutoWebOrder.Main.WorkNode
{
    class ConnectSite : WorkNodeBase
    {
        public override void Execute(WorkNodeArgment arg)
        {
            // 작업노드 시작시 수행루틴
            arg.cbOnChangeWorkState(arg.prevType, m_type, "");
            ChromeDriver driver = arg.seleMgr.GetDriver();
            Util.Logger logger = arg.logger;

            // 작업수행
            driver.Navigate().GoToUrl("http://dm.de/");
            Thread.Sleep(10000);

            // 다음작업으로 이동
            arg.prevType = m_type;
            m_workManager.GoNextWork(TYPE_WORK.Login, arg);
        }
    }
}
