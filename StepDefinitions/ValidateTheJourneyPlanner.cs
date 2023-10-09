using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NuGet.Frameworks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TFLJourneyPlanner.PageObject;

namespace TFLJourneyPlanner.StepDefinitions
{
    [Binding]
    public sealed class ValidateTheJourneyPlanner
    {
        private IWebDriver driver;
        private IWebElement journeyResult;
        private IWebElement arrivalLocation;
        private IWebElement RecentResults;
        PlanAJourneyPage planAJourneyPage;
        JourneyResultsPage journeyResultsPage;  

        public ValidateTheJourneyPlanner(IWebDriver driver)
        {
            this.driver = driver;
            planAJourneyPage = new PlanAJourneyPage(driver);
            journeyResultsPage = new JourneyResultsPage(driver);
        }

        [Given(@"I launch the TFL website")]
        public void GivenILaunchTheTFLWebsite()
        {
             driver.Navigate().GoToUrl("https://www.tfl.gov.uk");
            //driver.Manage().Cookies.DeleteAllCookies();
            //driver.Navigate().Refresh();
            IWebElement acceptCookiesButton = null;
             try
            {
            acceptCookiesButton = driver.FindElement(By.XPath("//button[@id = 'CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll']"));
            acceptCookiesButton.Click();
             }
             catch (NoSuchElementException) { 
             }
        }

        [When(@"I enter the '([^']*)' From location as '([^']*)'")]
        public void WhenIEnterTheFromLocationAs(string locationType, string locationValue)
        {
            planAJourneyPage.EnterOrigin(locationType, locationValue);
        }

        [When(@"I enter the '([^']*)' To location as '([^']*)'")]
        public void WhenIEnterTheToLocationAs(string locationType, string locationValue)
        {
            planAJourneyPage.EnterDestination(locationType, locationValue);
        }

        
        [When(@"I click Plan my journey button")]
        public void WhenIClickPlanMyJourneyButton()
        {
            journeyResultsPage = planAJourneyPage.PlanMyJourney();
           
        }

        [Then(@"I should see the journey based on Arrival time")]
        public void ThenIShouldSeeTheJourneyBasedOnArrivalTime()
        {
            arrivalLocation = journeyResultsPage.validateArrivalJourney();
            Assert.IsTrue(arrivalLocation.Displayed, "Valid journey options are not displayed.");
        }

        [Then(@"I should see the valid journey options in Journey results page")]
        public void ThenIShouldSeeTheValidJourneyOptionsInJourneyResultsPage()
        {
            journeyResult = journeyResultsPage.validateJourneyResult();
            Assert.IsTrue(journeyResult.Displayed, "Valid journey options are not displayed.");
        }


        [Then(@"I should see an error notification")]
        public void ThenIShouldSeeAnErrorNotification()
        {
            IWebElement errorNotification = journeyResultsPage.validateErrorNotification();
            Assert.IsTrue(errorNotification.Displayed);
        }
              

        [When(@"I click Plan my journey button without entering From and To location")]
        public void WhenIClickPlanMyJourneyButtonWithoutEnteringFromAndToLocation()
        {
            journeyResultsPage = planAJourneyPage.PlanMyJourney();
        }
               

        [Then(@"I should see an error message saying ""([^""]*)""")]
        public void ThenIShouldSeeAnErrorMessageSaying(string errorMessage)
        {
            string actualErrorMessage = "";
            switch (errorMessage)
            {
                case "The From field is required.":
                    actualErrorMessage = planAJourneyPage.GetFromErrorMessage();
                    break;
                case "The To field is required.":
                    actualErrorMessage = planAJourneyPage.GetToErrorMessage();
                    break;
                default:
                    Assert.Fail($"Unexpected error message: {errorMessage}");
                    break;
            }

            Assert.AreEqual(errorMessage, actualErrorMessage);
        }

        [When(@"I click on change time link")]
        public void WhenIClickOnChangeTimeLink()
        {
            planAJourneyPage.ClickChangeTimeLink();
        }

        [Then(@"I verify '([^']*)' option displays")]
        public void ThenIVerifyOptionDisplays(string inputText)
        {
            string actualText = planAJourneyPage.verifyArrivingDisplays();
            Assert.AreEqual(inputText, actualText);
        }

        [Then(@"I click Plan my journey button")]
        public void ThenIClickPlanMyJourneyButton()
        {
            journeyResultsPage = planAJourneyPage.PlanMyJourney();
        }

                
        [When(@"I click on Edit journey button in journey results page")]
        public void WhenIClickOnEditJourneyButtonInJourneyResultsPage()
        {
            journeyResultsPage.ClickEditJourneyButton(); ;
        }

        [Then(@"I can amend the Journey details")]
        public void ThenICanAmendTheJourneyDetails()
        {
            journeyResultsPage.EditJourneyDetails();
        }

        [Then(@"I can update the changes by clicking Update Journey button")]
        public void ThenICanUpdateTheChangesByClickingUpdateJourneyButton()
        {
            journeyResultsPage.UpdateTheJourneyDetails();
        }

        [When(@"I click Plan a Journey link")]
        public void WhenIClickPlanAJourneyLink()
        {
            journeyResultsPage.ClickPlanAJourneyLink();
        }

        [Then(@"I validate the recent journey results")]
        public void ThenIValidateTheRecentJourneyResults()
        {
            RecentResults = planAJourneyPage.VerifyRecentTabRecords();
            Assert.IsTrue(RecentResults.Displayed, "No recent journeys available");
        }


    }


}
