using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.PageObjects;

namespace TestFramework.PageObjects
{
    public class LoginPage
    {
        static string Url = "https://seleniumc.wordpress.com/";

        public void Login(string userName, string password)
        {
            Browser.WaitForElementDisplayedByLinkTextWithTimeout("Log in here", 30);
            IWebElement buttonLogInHere = Browser.Driver.FindElement(By.LinkText("Log in here"));
            buttonLogInHere.Click();

            Browser.WaitForElementDisplayedByIdWithTimeout("usernameOrEmail", 30);
            IWebElement textBoxUserName = Browser.Driver.FindElement(By.Id("usernameOrEmail"));
            textBoxUserName.SendKeys(userName);

            Browser.WaitForElementDisplayedByXPathWithTimeout("//*[@id='primary']/div/main/div/div[1]/div/form/div[1]/div[2]/button", 30);
            IWebElement buttonContinue = Browser.Driver.FindElement(By.XPath("//*[@id='primary']/div/main/div/div[1]/div/form/div[1]/div[2]/button"));
            buttonContinue.Click();

            System.Threading.Thread.Sleep(5000);
            //Browser.WaitForAjax();
          
            Browser.WaitForElementDisplayedByIdWithTimeout("password", 60);
            IWebElement textBoxPassword = Browser.Driver.FindElement(By.Id("password"));
            textBoxPassword.SendKeys(password);

            //System.Threading.Thread.Sleep(5000);
            
            
            Browser.WaitForElementDisplayed_byXPath("//button[text()='Log In']");
            //Browser.WaitForElementDisplayedByXPathWithTimeout("//*[@id='primary']/div/main/div/div[1]/div/form/div[1]/div[2]/button", 30);
            IWebElement buttonLogin = Browser.Driver.FindElement(By.XPath("//button[text()='Log In']"));
           
            //buttonLogin.Submit();
            buttonLogin.Click();
           
            //Browser.ClickByXPath("//*[@id='primary']/div/main/div/div[1]/div/form/div[1]/div[2]/button");
            //buttonLogin.Click();


        }

        static string PageTitle = "SeleniumC#";

        //[FindsBy(How = How.LinkText, Using = "Business")]
        //private IWebElement linkTextBusiness;

              

        public void GoTo()
        {   
            Browser.Goto(Url);
            
        }

        public bool IsAt()
        {
            return Browser.Title == PageTitle;
        }

      
    }
}
