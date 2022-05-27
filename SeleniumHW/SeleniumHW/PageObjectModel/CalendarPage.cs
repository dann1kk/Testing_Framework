using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumHW.PageObjectModel
{
    class CalendarPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        static DateTime now = DateTime.Now;
        private int today = now.Day;
        private int workingDay = 18;

        public CalendarPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }
       
        private IWebElement calendarButton => _driver.FindElement(By.XPath("//a[contains(text(), 'Calendar')]"));
        private IWebElement todayCalendarButton => _driver.FindElement(By.XPath("//span[contains(text(),'"+today+"')]"));
        private IWebElement projectField => _driver.FindElement(By.XPath("(//span[contains(text(), 'Project')])[3]"));
        private IWebElement projectName => _driver.FindElement(By.XPath("//span[contains(text(), 'test DG')]"));
        private IWebElement roleField => _driver.FindElement(By.XPath("//mat-select[@placeholder= 'Role']")); 
        private IWebElement roleName => _driver.FindElement(By.XPath("(//span[contains(text(), 'Associate QA Engineer')])[1]")); 
        private IWebElement submitButton => _driver.FindElement(By.XPath("//button[@type = 'submit']"));
        private IWebElement deleteButton => _driver.FindElement(By.XPath("(((//div[@class='mat-chip-list-wrapper'])["+workingDay+"]//mat-icon[contains(text(), 'cancel')]))"));
        private IWebElement confirmdeleteHours => _driver.FindElement(By.XPath("//button[@attr.ui-automation-id='confirmationPopUpYesButton']"));
        private IWebElement increaseHours => _driver.FindElement(By.XPath("//input[@step = '0.1']"));
        private IWebElement chooseworkingHours => _driver.FindElement(By.XPath("(((//div[@class='mat-chip-list-wrapper'])["+workingDay+"]//span[contains(text(), '7.5 hours')]))"));
        private IWebElement clickuntilPresent => _driver.FindElement(By.XPath("(//div[@class='mat-checkbox-inner-container'])[2]"));
        private IWebElement clickselectAll => _driver.FindElement(By.XPath("(//div[@class='mat-checkbox-inner-container'])[1]"));
        private IWebElement leavesButton => _driver.FindElement(By.Id("mat-tab-label-0-1"));
        private IWebElement clickType => _driver.FindElement(By.XPath("//mat-select[@placeholder='Type']"));
        private IWebElement chooseType => _driver.FindElement(By.XPath("//span[contains(text(), 'Sick')]"));
        private IWebElement chooseAbsence => _driver.FindElement(By.XPath("(((//div[@class='mat-chip-list-wrapper'])["+workingDay+"]//span[contains(text(), 'Sick')]))"));
        private IWebElement changeAbsence => _driver.FindElement(By.XPath("//span[contains(text(), 'Holiday')]"));
        private IWebElement monthyearButton => _driver.FindElement(By.XPath("//mat-icon[.='expand_more']"));
        private IWebElement febButton => _driver.FindElement(By.XPath("//div[contains(text(), 'FEB')]"));
        private IWebElement enddateButton => _driver.FindElement(By.XPath("//input[@placeholder='End Date']"));
        private IWebElement enddayClick => _driver.FindElement(By.XPath("//div[contains(text(),'"+(today-1)+"')]"));
        private By popupMessage => By.XPath("//snack-bar-container");

        public void ClickCalendar()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(calendarButton)).Click();
        }

        public void AddTodayWorkingHours()
        {
            ScrollDownDayButton();
            _wait.Until(ExpectedConditions.ElementToBeClickable(todayCalendarButton)).Click();
            
        }

        public void ClickProject()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(projectField)).Click();
        }

        public void SelectProject()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(projectName)).Click();
        }

        public void ClickRole()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(roleField)).Click();
        }

        public void SelectRole()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(roleName)).Click();
        }
 
        public void ClickApproveButton()
        {
            ScrollDownSubmitButton();
            _wait.Until(ExpectedConditions.ElementToBeClickable(submitButton)).Click();
        }

        public void ClickDeleteHoursButton()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(deleteButton)).Click();
        }

        public void ConfirmDelete()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(confirmdeleteHours)).Click();
        }

        public void CalendarWorkingHours()
        {
            ScrollDownWorkingHours();
            _wait.Until(ExpectedConditions.ElementToBeClickable(chooseworkingHours)).Click();
        } 
        public void IncreaseWorkingHours()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(increaseHours)).Click();
            _wait.Until(ExpectedConditions.ElementToBeClickable(increaseHours)).SendKeys(Keys.Backspace);
            _wait.Until(ExpectedConditions.ElementToBeClickable(increaseHours)).SendKeys("6");
        }

        public void ScrollDownDayButton()
        {
            ((IJavaScriptExecutor)_driver)
             .ExecuteScript("arguments[0].scrollIntoView(true);", todayCalendarButton);

        }

        public void ScrollDownSubmitButton()
        {
            ((IJavaScriptExecutor)_driver)
             .ExecuteScript("arguments[0].scrollIntoView(true);", submitButton);
   
        }
        public void ScrollDownTypeButton()
        {
            ((IJavaScriptExecutor)_driver)
             .ExecuteScript("arguments[0].scrollIntoView(true);", chooseType);

        }

        public void ScrollDownEndDay()
        {
            ((IJavaScriptExecutor)_driver)
          .ExecuteScript("arguments[0].scrollIntoView(true);", enddayClick);
        }

        public void ScrollDownWorkingHours()
        {
            ((IJavaScriptExecutor)_driver)
         .ExecuteScript("arguments[0].scrollIntoView(true);", chooseworkingHours);
        }
        public void ClickSelectUntilPresent()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(clickuntilPresent)).Click();
        }

        public void ClickSelectAll()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(clickselectAll)).Click();
        }

        public void ClickLeavesButton()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(leavesButton)).Click();
        }

        public void ClickType() 
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(clickType)).Click();

        }
        public void ChooseType()
        {
            ScrollDownTypeButton();
            _wait.Until(ExpectedConditions.ElementToBeClickable(chooseType)).Click();
        }

        public void ChooseNewType()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(changeAbsence)).Click();
        }


        public void ChooseAbsence() 
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(chooseAbsence)).Click();
        }
        
        public void ChangeAbsence()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(changeAbsence)).Click();
        }

        public void ClickDeleteAbsence()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(deleteButton)).Click();
        }

        public void ClickMonthYearBox()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(monthyearButton)).Click();
        }

        public void ClickMonthFebruary()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(febButton)).Click();

        }

        public void ClickEndDate()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(enddateButton)).Click();
        }

        public void ChooseEndDate()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(enddayClick)).Click();
        }

        //Asserts(Then)

        public void AllMonthDaysSelected()
        {
            int selectAllCount = _driver.FindElements(By.XPath("//input[@aria-checked='true']")).Count;
            Assert.IsTrue(selectAllCount >= 21);
        }

        public void SelectedUntilCurrent()
        {
            int selectuntilCount = _driver.FindElements(By.XPath("//input[@aria-checked='true']")).Count;
            if(today < 7)
                Assert.IsTrue(selectuntilCount >= today - 2);
            else if(today < 14)
                Assert.IsTrue(selectuntilCount >= today - 4);
            else if (today < 21)
                Assert.IsTrue(selectuntilCount >= today - 6);
            else if(today < 28)
                Assert.IsTrue(selectuntilCount >= today - 8);
            else if(today >= 28)
                Assert.IsTrue(selectuntilCount >= today - 9);

        }
        //Popup Messages
        /*public void MessageHoursAdded()
        {
            string messagehoursAdded = _driver.FindElement(popupMessage).Text;
            StringAssert.AreEqualIgnoringCase("Work hours created successfully", messagehoursAdded);
        }*/

        public void MessageHoursAdded()
        {
            _wait.Until(ExpectedConditions.TextToBePresentInElement(_driver.FindElement(popupMessage), "Work hours created successfully"));
        }

        /*  public void MessageUpdatedHours()
          {
              string messageupdatedHours = _driver.FindElement(popupMessage).Text;
              StringAssert.AreEqualIgnoringCase("Work hours updated successfully", messageupdatedHours);
          }*/

        public void MessageUpdatedHours()
        {
            _wait.Until(ExpectedConditions.TextToBePresentInElement(_driver.FindElement(popupMessage), "Work hours updated successfully"));
        }

        /* public void MessageDeletedHours()
         {
             string messagehoursDeleted = _driver.FindElement(popupMessage).Text;
             StringAssert.AreEqualIgnoringCase("Work hours deleted successfully", messagehoursDeleted);
         }*/
        public void MessageDeletedHours()
        {
            _wait.Until(ExpectedConditions.TextToBePresentInElement(_driver.FindElement(popupMessage), "Work hours deleted successfully"));
        }
     
        /*public void MessageAddedAbsence()
        {
            string messageabsenceAdded = _driver.FindElement(popupMessage).Text;
            StringAssert.AreEqualIgnoringCase("Absence created successfully", messageabsenceAdded);
        }*/

        public void MessageAddedAbsence()
        {
            _wait.Until(ExpectedConditions.TextToBePresentInElement(_driver.FindElement(popupMessage), "Absence created successfully"));
        }

       /* public void MessageUpdatedAbsence()
        {
            string messageabsenceUpdated = _driver.FindElement(popupMessage).Text;
            StringAssert.AreEqualIgnoringCase("Absence updated successfully", messageabsenceUpdated);
        }*/

        public void MessageUpdatedAbsence()
        {
            _wait.Until(ExpectedConditions.TextToBePresentInElement(_driver.FindElement(popupMessage), "Absence updated successfully"));
        }

      /*  public void MessagedDeletedAbsence()
        {
            string messageabsenceDeleted = _driver.FindElement(popupMessage).Text;
            StringAssert.AreEqualIgnoringCase("Absence deleted successfully", messageabsenceDeleted);
        }*/

        public void MessagedDeletedAbsence()
        {
            _wait.Until(ExpectedConditions.TextToBePresentInElement(_driver.FindElement(popupMessage), "Absence deleted successfully"));
        }

        public void WorkingHoursDeleted()
        {
            _wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("(((//div[@class='mat-chip-list-wrapper'])["+workingDay+"]//span[contains(text(), '7.6 hours')]))")));
        }

        public void WorkingHoursSaved()
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(((//div[@class='mat-chip-list-wrapper'])["+workingDay+"]//span[contains(text(), '7.5 hours')]))")));
        }

        public void UpdatedHoursSaved()
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(((//div[@class='mat-chip-list-wrapper'])["+workingDay+"]//span[contains(text(), '7.6 hours')]))")));
        }

        public void AbsenceIsSaved()
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(((//div[@class='mat-chip-list-wrapper'])["+workingDay+"]//span[contains(text(), 'Sick')]))")));
        }

        public void AbsenceUpdatedSaved()
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(((//div[@class='mat-chip-list-wrapper'])["+workingDay+"]//span[contains(text(), 'Holiday')]))")));
        }
      
        public void AbsenceDeleted()
        {
          _wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("(((//div[@class='mat-chip-list-wrapper'])["+workingDay+"]//span[contains(text(), 'Holiday')]))"))); 
        }

        public void WarningMessageDisplayed()
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//mat-error")));
        }

        public void MonthDisplayed()
        {
            _wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[contains(text(),'29')]")));
        }
        
    }
}
