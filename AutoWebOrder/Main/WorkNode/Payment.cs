using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AutoWebOrder.Main.WorkNode
{
    class Payment : WorkNodeBase
    {
        public override void Execute(WorkNodeArgment arg)
        {
            // 작업노드 시작시 수행루틴
            arg.cbOnChangeWorkState(arg.prevType, m_type, "");
            ChromeDriver driver = arg.seleMgr.GetDriver();
            Util.Logger logger = arg.logger;

            // 장바구니 버튼 클릭
            var element = driver.FindElementByXPath("/html/body/div[2]/div/header/div[2]/div/div/nav/ul/li[4]/a");
            element.Click();
            Thread.Sleep(8000);

            // 결제 버튼 클릭
            element = driver.FindElementByXPath("/html/body/div[2]/div/div[5]/div/div/div/div[2]/div[2]/form/button");
            element.Click();
            Thread.Sleep(5000);

            //// 동의 체크
            //element = driver.FindElementByXPath("/html/body/div[1]/div/main/form/div/div/div[4]/div/div/div[1]/input");
            //element.Click();
            //Thread.Sleep(500);

            //// 다음 메뉴
            //element = driver.FindElementByXPath("/html/body/div[1]/div/main/form/div/div/div[6]/button");
            //element.Click();
            //Thread.Sleep(3000);

            // 다음 작업으로 이동
            arg.prevType = m_type;
            m_workManager.GoNextWork(TYPE_WORK.Complete, arg);
        }
    }
}
