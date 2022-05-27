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
    class PasswordPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        private By passwordField => By.XPath("//input[@type='password']");
        private IWebElement submitButton => _driver.FindElement(By.XPath("//input[@type='submit']"));
        public PasswordPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        public void WritePassword(string password)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(passwordField)).SendKeys(password);
        }

        public void ClickEnterButton()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(submitButton)).Click();
        }
    }
}
