using System;
using TechTalk.SpecFlow;
using SeleniumHW.Hooks;
using SeleniumHW.PageObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumHW.CalendarSteps
{
    [Binding]
    public class CalendarSteps : Hook
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        [Given(@"I logged in successfully")]
        public void GivenILoggedInSuccessfully()
        {
            LoginPage loginPage = new LoginPage(GetDriver(), GetWait());
            loginPage.AccessPage("https://projectplanappweb-stage.azurewebsites.net/login");
            loginPage.ClickLogInButton();

            EmailPage emailPage = new EmailPage(GetDriver(), GetWait());
            emailPage.WriteEmail("AUTOMATION.PP@AMDARIS.COM");
            emailPage.ClickNextButton();

            PasswordPage passwordPage = new PasswordPage(GetDriver(), GetWait());
            passwordPage.WritePassword("10704-observe-MODERN-products-STRAIGHT-69112");
            passwordPage.ClickEnterButton();

            KeepLoggedInPage keepLoggedInPage = new KeepLoggedInPage(GetDriver(), GetWait());
            keepLoggedInPage.clickDontShowButton();
            keepLoggedInPage.clickYesButton();

            log.Info("Successfully logged in!");
        }

        [Given(@"I am on my personal Advance Calendar page")]
        public void GivenIAmOnMyPersonalAdvanceCalendarPage()
        {
            MainPage mainPage = new MainPage(GetDriver(), GetWait());
            mainPage.ClickEmployeeButton();

            EmployeesPage employeesPage = new EmployeesPage(GetDriver(), GetWait());
            employeesPage.ClickSearchField();
            employeesPage.WriteSearchField("Daniel Pogorevici");
            employeesPage.ClickEmployeeName();

            CalendarPage calendarPage = new CalendarPage(GetDriver(), GetWait());
            calendarPage.ClickCalendar();

            log.Info("Successfully accessed my personal calendar!");
        }

        [When(@"I click on today's day box")]
        public void WhenIClickOnTodaySDayBox()
        {
            CalendarPage calendarPage = new CalendarPage(GetDriver(), GetWait());
            calendarPage.AddTodayWorkingHours();

            log.Info("Clicked on today's box!");
        }

        [When(@"I click project field")]
        public void WhenIClickProjectField()
        {
            CalendarPage calendarPage = new CalendarPage(GetDriver(), GetWait());
            calendarPage.ClickProject();

            log.Info("Clicked on project field!");
        }

        [When(@"I choose project")]
        public void WhenIChooseProject(Table table)
        {
            CalendarPage calendarPage = new CalendarPage(GetDriver(), GetWait());
            calendarPage.SelectProject();

            log.Info("Chosen project!");
        }

        [When(@"I click role field")]
        public void WhenIClickRoleField()
        {
            CalendarPage calendarPage = new CalendarPage(GetDriver(), GetWait());
            calendarPage.ClickRole();

            log.Info("Clicked role field!");
        }

        [When(@"I choose role")]
        public void WhenIChooseRole(Table table)
        {
            CalendarPage calendarPage = new CalendarPage(GetDriver(), GetWait());
            calendarPage.SelectRole();

            log.Info("Chosen role!");
        }

        [When(@"I click approve button")]
        public void WhenIClickApproveButton()
        {
            CalendarPage calendarPage = new CalendarPage(GetDriver(), GetWait());
            calendarPage.ClickApproveButton();

            log.Info("Clicked approve button!");
        }

        [When(@"I click on working hours")]
        public void WhenIClickOnWorkingHours()
        {
            CalendarPage calendarPage = new CalendarPage(GetDriver(), GetWait());
            calendarPage.CalendarWorkingHours();

            log.Info("Clicked on working hours!");
        }

        [When(@"I increase working hours")]
        public void WhenIIncreaseWorkingHours(Table table)
        {
            CalendarPage calendarPage = new CalendarPage(GetDriver(), GetWait());
            calendarPage.IncreaseWorkingHours();

            log.Info("Increased working hours!");
        }

        [When(@"I click ok button")]
        public void WhenIClickOkButton()
        {
            CalendarPage calendarPage = new CalendarPage(GetDriver(), GetWait());
            calendarPage.ClickApproveButton();

            log.Info("Clicked ok button!");
        }

        [When(@"I click on delete button on my working hours")]
        public void WhenIClickOnDeleteButtonOnMyWorkingHours()
        {
            CalendarPage calendarPage = new CalendarPage(GetDriver(), GetWait());
            calendarPage.ClickDeleteHoursButton();

            log.Info("Clicked delete working hours!");
        }

        [When(@"I click Yes button")]
        public void WhenIClickYesButton()
        {
            CalendarPage calendarPage = new CalendarPage(GetDriver(), GetWait());
            calendarPage.ConfirmDelete();

            log.Info("Clicked yes button!");
        }

        [When(@"I click on select until current date")]
        public void WhenIClickOnSelectUntilCurrentDate()
        {
            CalendarPage calendarPage = new CalendarPage(GetDriver(), GetWait());
            calendarPage.ClickSelectUntilPresent();

            log.Info("Clicked on select until current date!");
        }

        [When(@"I click on select all")]
        public void WhenIClickOnSelectAll()
        {
            CalendarPage calendarPage = new CalendarPage(GetDriver(), GetWait());
            calendarPage.ClickSelectAll();

            log.Info("Clicked on select all!");
        }

        [When(@"I click leaves")]
        public void WhenIClickLeaves()
        {
            CalendarPage calendarPage = new CalendarPage(GetDriver(), GetWait());
            calendarPage.ClickLeavesButton();

            log.Info("Clicked leaves!");
        }

        [When(@"I click type category")]
        public void WhenIClickTypeCategory()
        {
            CalendarPage calendarPage = new CalendarPage(GetDriver(), GetWait());
            calendarPage.ClickType();

            log.Info("Clicked Type category!");
        }

        [When(@"I choose type category")]
        public void WhenIChooseTypeCategory(Table table)
        {
            CalendarPage calendarPage = new CalendarPage(GetDriver(), GetWait());
            calendarPage.ChooseType();

            log.Info("Chosen type category!");
        }

        [When(@"I click on absence box in the calendar")]
        public void WhenIClickOnAbsenceBoxInTheCalendar()
        {
            CalendarPage calendarPage = new CalendarPage(GetDriver(), GetWait());
            calendarPage.ChooseAbsence();

            log.Info("Clicked on absence box!");
        }

        [When(@"I change type category")]
        public void WhenIChangeTypeCategory(Table table)
        {
            CalendarPage calendarPage = new CalendarPage(GetDriver(), GetWait());
            calendarPage.ChangeAbsence();

            log.Info("Changed type category!");
        }

        [When(@"I click on delete button on absence")]
        public void WhenIClickOnDeleteButtonOnAbsence()
        {
            CalendarPage calendarPage = new CalendarPage(GetDriver(), GetWait());
            calendarPage.ClickDeleteAbsence();

            log.Info("Clicked on delete absence!");
        }

        [When(@"I click on month and year box")]
        public void WhenIClickOnMonthAndYearBox()
        {
            CalendarPage calendarPage = new CalendarPage(GetDriver(), GetWait());
            calendarPage.ClickMonthYearBox();

            log.Info("Clicked on month and year!");
        }

        [When(@"I click february button")]
        public void WhenIClickFebruaryButton()
        {
            CalendarPage calendarPage = new CalendarPage(GetDriver(), GetWait());
            calendarPage.ClickMonthFebruary();

            log.Info("Clicked on february!");
        }

        [When(@"I choose a new type category")]
        public void WhenIChooseANewTypeCategory(Table table)
        {
            CalendarPage calendarPage = new CalendarPage(GetDriver(), GetWait());
            calendarPage.ChooseNewType();

            log.Info("Chosen new type category!");
        }

        [When(@"I click end date field")]
        public void WhenIClickEndDateField()
        {
            CalendarPage calendarPage = new CalendarPage(GetDriver(), GetWait());
            calendarPage.ClickEndDate();

            log.Info("Clicked end date field!");
        }

        [When(@"I choose end date")]
        public void WhenIChooseEndDate(Table table)
        {
            CalendarPage calendarPage = new CalendarPage(GetDriver(), GetWait());
            calendarPage.ChooseEndDate();

            log.Info("Chosen end date!");
        }

        [Then(@"a pop up message of successfully added hours is displayed")]
        public void ThenAPopUpMessageOfSuccessfullyAddedHoursIsDisplayed()
        {
            CalendarPage calendarPage = new CalendarPage(GetDriver(), GetWait());
            calendarPage.MessageHoursAdded();

            log.Info("Pop Up of successfully added hours displayed!");
        }

        [Then(@"the working hours are saved")]
        public void ThenTheWorkingHoursAreSaved()
        {
            CalendarPage calendarPage = new CalendarPage(GetDriver(), GetWait());
            calendarPage.WorkingHoursSaved();

            log.Info("Working hours saved!");
        }
        
        [Then(@"a pop up message of successfully updated hours is displayed")]
        public void ThenAPopUpMessageOfSuccessfullyUpdatedHoursIsDisplayed()
        {
            CalendarPage calendarPage = new CalendarPage(GetDriver(), GetWait());
            calendarPage.MessageUpdatedHours();

            log.Info("Pop Up of successfully updated hours displayed!");
        }
        
        [Then(@"new working hours are saved")]
        public void ThenNewWorkingHoursAreSaved()
        {
            CalendarPage calendarPage = new CalendarPage(GetDriver(), GetWait());
            calendarPage.UpdatedHoursSaved();

            log.Info("Updated working hours saved!");
        }
        
        [Then(@"a pop up message of successfully deleted hours is displayed")]
        public void ThenAPopUpMessageOfSuccessfullyDeletedHoursIsDisplayed()
        {
            CalendarPage calendarPage = new CalendarPage(GetDriver(), GetWait());
            calendarPage.MessageDeletedHours();

            log.Info("Pop Up of successfully deleted hours displayed!");
        }
        
        [Then(@"working hours are deleted")]
        public void ThenWorkingHoursAreDeleted()
        {
            CalendarPage calendarPage = new CalendarPage(GetDriver(), GetWait());
            calendarPage.WorkingHoursDeleted();

            log.Info("Working hours deleted!");
        }
        
        [Then(@"all days until current are selected")]
        public void ThenAllDaysUntilCurrentAreSelected()
        {
            CalendarPage calendarPage = new CalendarPage(GetDriver(), GetWait());
            calendarPage.SelectedUntilCurrent();

            log.Info("All days until current selected!");
        }
        
        [Then(@"all month days are selected")]
        public void ThenAllMonthDaysAreSelected()
        {
            CalendarPage calendarPage = new CalendarPage(GetDriver(), GetWait());
            calendarPage.AllMonthDaysSelected();

            log.Info("All days selected!");
        }
        
        [Then(@"a pop up message of successfully added absence is displayed")]
        public void ThenAPopUpMessageOfSuccessfullyAddedAbsenceIsDisplayed()
        {
            CalendarPage calendarPage = new CalendarPage(GetDriver(), GetWait());
            calendarPage.MessageAddedAbsence();

            log.Info("Pop Up of successfully deleted hours displayed!");
        }
        
        [Then(@"the absence is saved in calendar")]
        public void ThenTheAbsenceIsSavedInCalendar()
        {
            CalendarPage calendarPage = new CalendarPage(GetDriver(), GetWait());
            calendarPage.AbsenceIsSaved();

            log.Info("Absence saved in calendar!");
        }
        
        [Then(@"a pop up message of successfully updated absence is displayed")]
        public void ThenAPopUpMessageOfSuccessfullyUpdatedAbsenceIsDisplayed()
        {
            CalendarPage calendarPage = new CalendarPage(GetDriver(), GetWait());
            calendarPage.MessageUpdatedAbsence();

            log.Info("Pop Up of successfully updated absence displayed!");
        }
        
        [Then(@"updated absence is saved")]
        public void ThenUpdatedAbsenceIsSaved()
        {
            CalendarPage calendarPage = new CalendarPage(GetDriver(), GetWait());
            calendarPage.AbsenceUpdatedSaved();

            log.Info("Updated Absence Saved!");
        }
        
        [Then(@"a pop up message of successfully deleted absence is displayed")]
        public void ThenAPopUpMessageOfSuccessfullyDeletedAbsenceIsDisplayed()
        {
            CalendarPage calendarPage = new CalendarPage(GetDriver(), GetWait());
            calendarPage.MessagedDeletedAbsence();

            log.Info("Pop Up of successfully deleted absence displayed!");
        }
        
        [Then(@"absence is deleted")]
        public void ThenAbsenceIsDeleted()
        {
            CalendarPage calendarPage = new CalendarPage(GetDriver(), GetWait());
            calendarPage.AbsenceDeleted();

            log.Info("Absence deleted!");
        }
        
        [Then(@"the calendar for february month is displayed")]
        public void ThenTheCalendarForAprilMonthIsDisplayed()
        {
            CalendarPage calendarPage = new CalendarPage(GetDriver(), GetWait());
            calendarPage.MonthDisplayed();

            log.Info("Calendar for february month displayed!");
        }
        
        [Then(@"a warning message is displayed")]
        public void ThenAWarningMessageIsDisplayed()
        {
            CalendarPage calendarPage = new CalendarPage(GetDriver(), GetWait());
            calendarPage.WarningMessageDisplayed();

            log.Info("Warning message displayed!");
        }
    }
}
