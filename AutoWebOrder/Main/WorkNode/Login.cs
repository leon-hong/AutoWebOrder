using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using OpenQA.Selenium.Chrome;

namespace AutoWebOrder.Main.WorkNode
{
    class Login : WorkNodeBase
    {
        public override void Execute(WorkNodeArgment arg)
        {

            // 작업노드 시작시 수행루틴
            arg.cbOnChangeWorkState(arg.prevType, m_type, "");
            ChromeDriver driver = arg.seleMgr.GetDriver();
            Util.Logger logger = arg.logger;

            try
            {
                // 로그인 화면 버튼 찾아서 클릭
                var element = driver.FindElementByCssSelector(".d:nth-child(3) > div > .i");
                element.Click();
                Thread.Sleep(2000);

                // id, pw 입력
                element = driver.FindElementById("emailAddress-input");
                element.SendKeys("leonhong@naver.com");
                Thread.Sleep(100);

                // 로그인 클릭                
                element = driver.FindElementById("password-input");
                element.SendKeys("!8189809goD");
                Thread.Sleep(100);

                // 로그인 클릭                
                element = driver.FindElementById("login-button");
                element.Click();
                Thread.Sleep(3000);

                // 메인화면으로 이동
                element = driver.FindElementByXPath("//*[@id=\"__next\"]/div/header/div/div/a[1]");
                element.Click();
                Thread.Sleep(3000);

            }
            catch (Exception e)
            {
                arg.cbOnErrorWorkNode(m_type, "로그인 수행 실패");
                logger.OutputError(e.StackTrace, e.Message);
                return;
            }

            // 다음작업으로 이동
            arg.prevType = m_type;
            m_workManager.GoNextWork(TYPE_WORK.ClearCart, arg);

        }
    }
}
