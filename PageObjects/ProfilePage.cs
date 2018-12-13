using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.ObjectModel;


namespace TestFramework.PageObjects
{
    public class ProfilePage
    {
        [FindsBy(How = How.Id, Using = "first_name")]
        private readonly IWebElement textBoxFirstName = null;

        public void GoTo()
        {
            Browser.WaitForElementDisplayed_byXPath("//*[@id='wp-admin-bar-my-account']/a/img");
            IWebElement profileIcon = Browser.Driver.FindElement(By.XPath("//*[@id='wp-admin-bar-my-account']/a/img"));
            profileIcon.Click();

            Browser.WaitForElementDisplayedByLinkTextWithTimeout("My Profile", 30);
            IWebElement linkMyProfile = Browser.Driver.FindElement(By.LinkText("My Profile"));
            linkMyProfile.Click();
        }

        public void EditProfileFirstNameLastName(string firstName, string lastName)
        {
            Browser.WaitForElementDisplayedByIdWithTimeout("first_name", 30);
          
            textBoxFirstName.Clear();
            textBoxFirstName.SendKeys(firstName);

            Browser.WaitForElementDisplayedByIdWithTimeout("last_name", 30);
            IWebElement textBoxLastName = Browser.Driver.FindElement(By.Id("last_name"));
            textBoxLastName.Clear();
            textBoxLastName.SendKeys(lastName);

            Browser.WaitForElementDisplayed_byXPath("//button[text()='Save Profile Details']");
            IWebElement buttonSaveProfile = Browser.Driver.FindElement(By.XPath("//button[text()='Save Profile Details']"));
            buttonSaveProfile.Click();

        }

        public bool VerifyEditFirstNameLastName(string firstName, string lastName)
        {
            Browser.WaitForElementDisplayedByIdWithTimeout("first_name", 30);
           
           
            Browser.WaitForElementDisplayedByIdWithTimeout("last_name", 30);
            IWebElement textBoxLastName = Browser.Driver.FindElement(By.Id("last_name"));

            if (textBoxFirstName.GetAttribute("value").ToString() == firstName && textBoxLastName.GetAttribute("value").ToString() == lastName)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
