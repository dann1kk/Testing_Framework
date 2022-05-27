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
    class KeepLoggedInPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        public KeepLoggedInPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }
        private IWebElement dontshowButton => _driver.FindElement(By.Id("KmsiCheckboxField"));
        private IWebElement yesButton => _driver.FindElement(By.XPath("//input[@type='submit']"));

        public void clickDontShowButton()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(dontshowButton)).Click();
        }

        public void clickYesButton()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(yesButton)).Click();
        }
    }
}
