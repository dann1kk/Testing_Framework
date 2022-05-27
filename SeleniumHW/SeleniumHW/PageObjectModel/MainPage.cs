using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumHW.PageObjectModel
{
   public class MainPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        public MainPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }
        private IWebElement employeeButton => _driver.FindElement(By.XPath("//a[@href='/employees']"));

        public void ClickEmployeeButton() 
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(employeeButton)).Click();
        }
    }
}
