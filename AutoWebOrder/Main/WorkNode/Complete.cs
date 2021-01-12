using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutoWebOrder.Main.WorkNode
{
    class Complete : WorkNodeBase
    {
        public override void Execute(WorkNodeArgment arg)
        {

            // 작업노드 시작시 수행루틴
            arg.cbOnChangeWorkState(arg.prevType, m_type, "");
            ChromeDriver driver = arg.seleMgr.GetDriver();
            Util.Logger logger = arg.logger;

            logger.OutputInfo("Work finish.");
        }
    }

}
