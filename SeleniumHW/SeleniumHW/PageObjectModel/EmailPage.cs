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
    class EmailPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;


        public EmailPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        private By emailField => By.XPath("//input[@type='email']");
        private IWebElement nextButton => _driver.FindElement(By.XPath("//input[@type='submit']"));

        public void WriteEmail(string email)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(emailField)).SendKeys(email);
        }

        public void ClickNextButton()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(nextButton)).Click();
        }
    }
}
