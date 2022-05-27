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
    class EmployeesPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        public EmployeesPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        public void ClickSearchField()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@placeholder='Search']"))).Click();
        }

        public void WriteSearchField(string nameSurname)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@placeholder='Search']"))).SendKeys(nameSurname);
        }

        public void ClickEmployeeName()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//app-employee-item[1]"))).Click();
        }
    }
}
