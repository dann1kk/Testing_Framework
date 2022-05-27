using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumHW.PageObjectModel
{
    class LoginPage
    {
        private  IWebDriver _driver;
        private  WebDriverWait _wait;

        public LoginPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }
        private IWebElement loginButton => _driver.FindElement(By.ClassName("button"));

        public void AccessPage(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public void ClickLogInButton() 
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(loginButton)).Click();
        }
    }
}
