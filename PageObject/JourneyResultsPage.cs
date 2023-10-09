using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFLJourneyPlanner.PageObject
{
    public class JourneyResultsPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public JourneyResultsPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
        }

        private IWebElement OriginField => driver.FindElement(By.XPath("//input[@id = 'InputFrom' and @placeholder = 'From']"));
        //private IWebElement selectOption  => driver.FindElement(By.XPath("//span[@class='tt-suggestions']/child::div/child::span[@class= 'stop-name']"));
        private IWebElement DestinationField => driver.FindElement(By.XPath("//input[@id = 'InputTo' and @placeholder = 'To']"));
       // private IWebElement selectDestinationOption => driver.FindElement(By.XPath("//span[@class='tt-suggestions']/child::div/child::span[@class= 'stop-name']"));

        private IWebElement UpdateJourneyButton  => driver.FindElement(By.XPath("//input[@id= 'plan-journey-button']"));
        private IWebElement ClearContent =>  driver.FindElement(By.LinkText("Clear From location"));
        public IWebElement validateJourneyResult()
        {
            IWebElement ValidLocation = wait.Until(driver => driver.FindElement(By.XPath("//div[@id = 'option-1-heading']")));
            return ValidLocation;
        }

        public IWebElement validateErrorNotification()
        {
            return wait.Until(driver => driver.FindElement(By.XPath("//ul[@class = 'field-validation-errors']")));
        }

        public IWebElement validateArrivalJourney()
        {
            IWebElement ArrivingLocation = wait.Until(driver => driver.FindElement(By.XPath("//div/child::div/child::div[@id = 'option-3-heading']")));
            return ArrivingLocation;
        }

        public void ClickEditJourneyButton()
        {
            IWebElement EditJourneyButton = wait.Until(driver => driver.FindElement(By.XPath("//span[contains(text(), 'Edit journey')]")));
            EditJourneyButton.Click();
        }

        public void EditJourneyDetails()
        {
            IWebElement selectDateOfDeparture = wait.Until(driver => driver.FindElement(By.XPath("//select[@id = 'Date']")));
            SelectElement select = new SelectElement(selectDateOfDeparture);
            select.SelectByText("Tomorrow");

        }

        public void UpdateTheJourneyDetails()
        {
            UpdateJourneyButton.Click();
        }

        public void ClickPlanAJourneyLink()
        {
            Thread.Sleep(1000);
            IWebElement PlanAJourneyLink = wait.Until(driver => driver.FindElement(By.XPath("//a[text()='Plan a journey']")));
            PlanAJourneyLink.Click();
        }

        [Then(@"I validate the recent journey results")]
        public void ThenIValidateTheRecentJourneyResults()
        {
            throw new PendingStepException();
        }

    }
}
