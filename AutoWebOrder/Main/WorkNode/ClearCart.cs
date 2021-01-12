using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace AutoWebOrder.Main.WorkNode
{
    class ClearCart : WorkNodeBase
    {
        public override void Execute(WorkNodeArgment arg)
        {

            // 작업노드 시작시 수행루틴
            arg.cbOnChangeWorkState(arg.prevType, m_type, "");
            ChromeDriver driver = arg.seleMgr.GetDriver();
            Util.Logger logger = arg.logger;

            // 작업수행
            try
            {

                // 장바구니로 이동
                var element = driver.FindElementByXPath("/html/body/div[2]/div/header/div[2]/div/div/nav/ul/li[4]/a");
                element.Click();
                Thread.Sleep(6000);                

                // 장바구니에 물건이 있으면 장바구니 비우기
                if (arg.seleMgr.ExistElement(By.XPath("/html/body/div[2]/div/header/div[2]/div/div/nav/ul/li[4]/a/span")))
                {
                    
                    // 장바구니 마크에 쓰여진 숫자로 판별
                    element = driver.FindElementByXPath("/html/body/div[2]/div/header/div[2]/div/div/nav/ul/li[4]/a/span");
                    Thread.Sleep(100);
                    int cntBuyGroup = int.Parse(element.Text);
                    
                    // 장바구니 품목 그룹이 1개 있을경우와 여러개 있을경우 html 이 다르므로, 다르게 처리함
                    if (1 == cntBuyGroup)
                    {
                        element = driver.FindElementByXPath("/html/body/div[2]/div/div[5]/div/div/div/div[5]/div[2]/div/div/span/button");
                        element.Click();
                        Thread.Sleep(6000);                        
                    }
                    else
                    {
                        ReadOnlyCollection<IWebElement> listElem = driver.FindElementsByXPath("/html/body/div[2]/div/div[5]/div/div/div/div[5]/div[2]/div");
                        Thread.Sleep(100);
                        cntBuyGroup = listElem.Count;
                        
                        // 1개 그룹 빼고 나머지 처리한후 최종적으로 1개 그룹 비움
                        for (int i = 0; i < cntBuyGroup - 1; i++)
                        {
                            var elemSel = driver.FindElementByXPath("/html/body/div[2]/div/div[5]/div/div/div/div[5]/div[2]/div[1]/div/span/button");
                            elemSel.Click();
                            Thread.Sleep(6000);
                        }
                        
                        element = driver.FindElementByXPath("/html/body/div[2]/div/div[5]/div/div/div/div[5]/div[2]/div/div/span/button");
                        element.Click();
                        Thread.Sleep(6000);
                        
                    }
                }

                // 메인이동
                driver.FindElementByXPath("/html/body/div[2]/div/header/div[2]/div/div/a").Click();
                Thread.Sleep(3000);
                
            }
            catch (Exception e)
            {
                arg.cbOnErrorWorkNode(m_type, "장바구니 비우기 실패");
                logger.OutputError(e.StackTrace, e.Message);
                return;
            }

            // 다음 작업으로 이동
            arg.prevType = m_type;
            m_workManager.GoNextWork(TYPE_WORK.CheckOrderItem, arg);
        }
    }
}
