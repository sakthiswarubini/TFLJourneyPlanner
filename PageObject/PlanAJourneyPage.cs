using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFLJourneyPlanner.PageObject
{
    public class PlanAJourneyPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public PlanAJourneyPage(IWebDriver driver)
        {
        this.driver = driver;
         wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        private IWebElement OriginInput => driver.FindElement(By.XPath("//input[@placeholder = 'From']"));

        private IWebElement DestinationInput => driver.FindElement(By.XPath("//input[@placeholder = 'To']"));

        private IWebElement PlanMyJourneyButton => driver.FindElement(By.XPath("//input[@id = 'plan-journey-button']"));

        private IWebElement InputFromErrorMessage => driver.FindElement(By.XPath("//span[@data-valmsg-for = 'InputFrom']/child::span"));

        private IWebElement InputToErrorMessage => driver.FindElement(By.XPath("//span[@data-valmsg-for = 'InputTo']/child::span"));

        private IWebElement ChangeTimeLink => driver.FindElement(By.XPath("//a[@class = 'change-departure-time']"));

        private IWebElement ArrivingLabel => driver.FindElement(By.XPath("//div[@class='change-time-options']/child::div/child::ul/child::li[2]/child::label"));

        private IWebElement ArrivingButton => driver.FindElement(By.XPath("//div[@class='change-time-options']/child::div/child::ul/child::li[2]/child::input[@id = 'arriving']"));
        public void EnterOrigin(string location, string origin)
        {
            if (location.Equals("valid", StringComparison.OrdinalIgnoreCase))
            {
                OriginInput.SendKeys(origin);
                IWebElement selectFromValidOption = wait.Until(driver => driver.FindElement(By.XPath("//span[@id = 'InputFrom-dropdown']/child::div[2]/child::span[2]/child::div/child::span")));
                selectFromValidOption.Click();
            }
            else if (location.Equals("invalid", StringComparison.OrdinalIgnoreCase))
            {
                OriginInput.SendKeys(origin);
                IWebElement selectFromInValidOption = wait.Until(driver => driver.FindElement(By.XPath("//span[@class='tt-suggestions']/child::div/child::span[@class= 'stop-name']")));
                selectFromInValidOption.Click();

            }
        }

        public void EnterDestination(string location, string destination)
        {
            if (location.Equals("valid", StringComparison.OrdinalIgnoreCase))
            {
                DestinationInput.SendKeys(destination);
                IWebElement selectToValidOption = wait.Until(driver => driver.FindElement(By.XPath("//span[@id = 'InputTo-dropdown']/child::div[2]/child::span[2]/child::div/child::span")));
                selectToValidOption.Click();
            }
            else if (location.Equals("invalid", StringComparison.OrdinalIgnoreCase))
            {
                DestinationInput.SendKeys(destination);
                IWebElement selectToInvalidOption = wait.Until(driver => driver.FindElement(By.XPath("//span[@class='tt-suggestions']/child::div/child::span[@class= 'stop-name']")));
                selectToInvalidOption.Click();
            }
        }

        public JourneyResultsPage PlanMyJourney()
        {
            PlanMyJourneyButton.Click();
            return new JourneyResultsPage(driver);
        }

        public string GetFromErrorMessage()
        {
            return InputFromErrorMessage.Text;

        }

        public string GetToErrorMessage()
        {
            return InputToErrorMessage.Text;

        }

        public void ClickChangeTimeLink()
        {
            ChangeTimeLink.Click();
        }

        public string verifyArrivingDisplays()
        {
            ArrivingButton.Click();
            return ArrivingLabel.Text;
        }

        public IWebElement VerifyRecentTabRecords()
        {
            IWebElement RecentTabRecords = wait.Until(driver => driver.FindElement(By.XPath("//div[@id = 'jp-recent-content-jp-']")));
            return RecentTabRecords;
        }
    }
}
