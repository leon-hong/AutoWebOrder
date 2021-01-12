using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AutoWebOrder.Main.WorkNode
{
    class AddItemToCart : WorkNodeBase
    {
        private void ProcessAfterOrder(WorkNodeArgment arg, string serialNum, int leftBuy)
        {
            arg.cbOnFinishOrderItem(serialNum, leftBuy);
            arg.orderData.RemoveAt(0);
            this.m_workManager.GoNextWork(TYPE_WORK.CheckOrderItem, arg);
        }

        public override void Execute(WorkNodeArgment arg)
        {
            // 작업노드 시작시 수행루틴
            arg.cbOnChangeWorkState(arg.prevType, m_type, "");
            ChromeDriver driver = arg.seleMgr.GetDriver();
            Util.Logger logger = arg.logger;

            // 작업수행
            //OrderItem orderItem = arg.orderData[0];

            string serialNum = arg.orderData.listSerial[0];
            string productCD = "p" + arg.orderData.listCode[0];
            int cntBuy = int.Parse(arg.orderData.listAmount[0]);

            try
            {
                // 검색창 깨끗이 지우고
                if (arg.seleMgr.ExistElement(By.XPath("/html/body/div[2]/div/header/div[2]/div/div/div/div/div/div/form/div[1]/button[1]"))) {
                    driver.FindElementByXPath("/html/body/div[2]/div/header/div[2]/div/div/div/div/div/div/form/div[1]/button[1]").Click();
                }
                Thread.Sleep(100);

                // 검색어 입력
                var element = driver.FindElementByXPath("//*[@id=\"input-search-input-field\"]");
                element.SendKeys(productCD);
                Thread.Sleep(100);

                // 검색 버튼 클릭
                element = driver.FindElementByXPath("//*[@id=\"app\"]/div/header/div[2]/div/div/div/div/div/div/form/div[1]/button[2]");
                element.Click();
                Thread.Sleep(5000);

                // 검색 결과중 첫번째 것 가져와서 href 링크에 제품코드가 들어 있다면 검색 성공
                // 검색에 성공하면 필요한 개수만큼 장바구니에 담음
                ReadOnlyCollection<IWebElement> listElem = driver.FindElementsByXPath("//*[@id=\"app\"]/div/div[5]/div/div/div/div[2]/div/div[2]/div/div/div/div/div");

                // 검색결과가 없다는 것은 제품이 등록되지 않은 것임
                // 장바구니에 담기 실패
                if (0 == listElem.Count) {                                        
                    ProcessAfterOrder(arg, serialNum, cntBuy);
                    return;
                }

                int idxExist = -1;
                // 해당물건이 여러개일 경우 정확한 물건을 찾음
                for (int i = 0; i < listElem.Count; i++) {
                    var elemSel = listElem[0].FindElement(By.CssSelector("div > div > a"));
                    string href = elemSel.GetAttribute("href");
                    // 정확한 코드를 포함한 제품을 찾음 12라는 코드를 찾으려고 하는데 123.html도 12를 포함하므로 위험함
                    if (href.Contains(productCD+".html")) {
                        idxExist = i;
                        break;
                    }
                }

                if (-1 == idxExist) {
                    ProcessAfterOrder(arg, serialNum, cntBuy);
                    return;
                }

                string strXPath = "/html/body/div[2]/div/div[5]/div/div/div/div[2]/div/div[2]/div/div/div/div/div/div/div[" + (idxExist + 1).ToString() + "]/a";

                // 상세 주문으로 이동
                element = driver.FindElementByXPath(strXPath);
                element.Click();
                Thread.Sleep(4000);

                // 제품이미지 확대 화면이 갯수 리스트를 가리므로 마우스를 이동시켜서 확대화면 없앰
                arg.seleMgr.MouseMoveToElement(By.XPath("/html/body/div[2]/div/header/div[2]/div/div/a"));

                // 기존에 장바구니에 담겨있던 제품 갯수
                int cntExistCartItem = 0;
                if (arg.seleMgr.ExistElement(By.XPath("/html/body/div[2]/div/header/div[2]/div/div/nav/ul/li[4]/a/span")))
                {
                    element = driver.FindElementByXPath("/html/body/div[2]/div/header/div[2]/div/div/nav/ul/li[4]/a/span");
                    cntExistCartItem = int.Parse(element.Text);
                }

                // 개수만큼 장바구니에 담기
                // 리스트에 출력된 갯수들의 리스트에서 가장 최소한의 클릭으로 담을수 있을만큼 담음
                listElem = driver.FindElementsByXPath("/html/body/div[2]/div/div[5]/div[2]/div/div[2]/div[1]/div[3]/div[2]/div[2]/div[1]/select/option");

                // 1,2,4,10,15 같은 개수의 리스트 인데                    
                List<int> listAmount = new List<int>();
                for (int i = 0; i < listElem.Count; i++)
                {
                    listAmount.Add(int.Parse(listElem[i].Text));
                }

                // 여기서 출력 개수 리스트가 없다는 것은 재고가 없다는 이야기임
                if (0 == listAmount.Count)
                {
                    ProcessAfterOrder(arg, serialNum, cntBuy);
                    return;
                }

                // 최소한의 루프를 돌아야 하므로 100회면 충분히 돌것으로 판단됨.
                for (int i = 0; i < 100; i++)
                {

                    // 리스트에 포함된 최대개수부터 나누었을때, 1 이상이 나오면 해당 갯수로 담을수 있게 처리함
                    for (int j = listAmount.Count - 1; j >= 0; j--)
                    {
                        int cntOrder = listAmount[j];
                        if (cntBuy / cntOrder > 0)
                        {

                            SelectElement select = new SelectElement(driver.FindElementByXPath("/html/body/div[2]/div/div[5]/div[2]/div/div[2]/div[1]/div[3]/div[2]/div[2]/div[1]/select"));

                            // 갯수창 선택해서 리스트를 보이게 하고 리스트에서 선택후 장바구니 담기
                            select.SelectByIndex(j);
                            Thread.Sleep(100);

                            element = driver.FindElementByXPath("/html/body/div[2]/div/div[5]/div[2]/div/div[2]/div[1]/div[3]/div[2]/div[2]/div[2]/button");
                            element.Click();
                            Thread.Sleep(4000);

                            // 만일 물건 갯수 만큼 장바구니에서의 개수가 증가하지 않았다면 오류로 보고 처리
                            element = driver.FindElementByXPath("/html/body/div[2]/div/header/div[2]/div/div/nav/ul/li[4]/a/span");
                            int cntAfterCartBuy = int.Parse(element.Text);

                            if ((cntExistCartItem + cntOrder) == cntAfterCartBuy)
                            {
                                // 주문이 제대로 들어갈 경우
                                cntExistCartItem += cntOrder;
                                cntBuy -= cntOrder;
                            }
                            else
                            {
                                // 장바구니에 담기 실패
                                ProcessAfterOrder(arg, serialNum, cntBuy);
                                return;
                            }

                            // 다음 담을 갯수로 넘어가기
                            break;
                        }
                    }

                    if (0 == cntBuy)
                    {
                        // 성공적으로 주문 완료
                        ProcessAfterOrder(arg, serialNum, cntBuy);
                        return;
                    }
                }
            }
            catch (Exception e)
            {
                arg.cbOnErrorWorkNode(m_type, "장바구니에 담기 실패");
                logger.OutputError(e.StackTrace, e.Message);
                return;
            }

        }
    }
}
