using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace AutoWebOrder.Util
{
    
    class SeleniumManager
    {
        private ChromeDriverService m_chromeDriverService = null;
        private ChromeOptions m_chromeOptions = null;
        private ChromeDriver m_chromeDriver = null;

        public SeleniumManager()
        {
            m_chromeDriverService = ChromeDriverService.CreateDefaultService();
            m_chromeDriverService.HideCommandPromptWindow = true;
            m_chromeOptions = new ChromeOptions();
            m_chromeOptions.AddArgument("disable-gpu");
            m_chromeDriver = new ChromeDriver(m_chromeDriverService, m_chromeOptions);
            
        }

        public ChromeDriver GetDriver()
        {
            return m_chromeDriver;
        }

        public bool ExistElement(By by)
        {
            return m_chromeDriver.FindElements(by).Count > 0;
        }

        public void ScrollPage(int x, int y)
        {
            m_chromeDriver.ExecuteScript("window.scrollTo(" + x.ToString() + "," + y.ToString() + ")");
        }

        // 마우스를 특정 엘리먼트로 이동
        public void MouseMoveToElement(By by)
        {
            var element = m_chromeDriver.FindElement(by);
            Actions move = new Actions(m_chromeDriver);
            move.MoveToElement(element).Perform();
        }
    }
}
