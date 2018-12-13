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
    public class PostPage
    {
        public void CreateNewPost(string title, string postVerbiage)
        {
            Browser.WaitForElementDisplayed_byXPath("//span[text()='Write']");
            IWebElement textBoxWriteNewPost = Browser.Driver.FindElement(By.XPath("//span[text()='Write']"));
            textBoxWriteNewPost.Click();

            //Title
            Browser.WaitForElementDisplayed_byXPath("//*[@id='primary']/div/div[3]/div[2]/div/div[3]/div[2]/div/textarea");
            IWebElement textAreaTitle = Browser.Driver.FindElement(By.TagName("textarea"));
           
            textAreaTitle.Click();
            textAreaTitle.SendKeys(title);
           
            //post Content
            Browser.WaitForElementDisplayedByIdWithTimeout("tinymce-1", 30);
            if(Browser.IsElementEnabledById("tinymce-1"))
            {
                IWebElement textAreaPostContent = Browser.GetElementById("tinymce-1");
                textAreaPostContent.Click();
                textAreaPostContent.SendKeys(postVerbiage);
            }
           
            //click Publish... button
            Browser.WaitForElementDisplayedByXPathWithTimeout("//*[@id='primary']/div/div[3]/div[1]/div[4]/div/button", 30);
            if(Browser.WaitForElementVisible_byXPath("//*[@id='primary']/div/div[3]/div[1]/div[4]/div/button"))
            {
                if (Browser.IsElementEnabledByXpath("//*[@id='primary']/div/div[3]/div[1]/div[4]/div/button"))
                {
                    IWebElement buttonInitPublish = Browser.GetElementByXpath("//*[@id='primary']/div/div[3]/div[1]/div[4]/div/button");
                    if (buttonInitPublish.Displayed)
                    {
                        buttonInitPublish.Click();
                    }
                }
            }
            //click Publish! button
            if (Browser.WaitForElementVisible_byXPath("//button[text()='Publish!']"))
            {
                if (Browser.IsElementEnabledByXpath("//button[text()='Publish!']"))
                {
                    IWebElement buttonPublish = Browser.GetElementByXpath("//button[text()='Publish!']");
                    if (buttonPublish.Displayed)
                    {
                        buttonPublish.Click();
                    }
                }
            }
            //click Close Button
            if (Browser.WaitForElementVisible_byXPath("//*[@id='primary']/div/div[3]/div[4]/div/div[1]/button"))
            {
                if (Browser.IsElementEnabledByXpath("//*[@id='primary']/div/div[3]/div[4]/div/div[1]/button"))
                {
                    IWebElement buttonClose = Browser.GetElementByXpath("//*[@id='primary']/div/div[3]/div[4]/div/div[1]/button");
                    if (buttonClose.Displayed)
                    {
                        if(Browser.WaitForElementClickable_byXPath("//*[@id='primary']/div/div[3]/div[4]/div/div[1]/button"))
                        { 
                            buttonClose.Click();
                        }
                    }
                }
            }


            bool presentFlag = false;

            try
            {

                // Check the presence of alert
                IAlert alert = Browser.Driver.SwitchTo().Alert();
                // Alert present; set the flag
                presentFlag = true;
                // if present consume the alert
                alert.Accept();

            }
            catch (NoAlertPresentException ex)
            {
                // Alert not present
              
            }

            

        }

        public bool VerifyNewPost(string postTitle)
        {
            Browser.WaitForElementDisplayed_byClassName("post-type-list");
            IWebElement postPanel = Browser.Driver.FindElement(By.ClassName("post-type-list"));
            IList<IWebElement> linksPosts = postPanel.FindElements(By.TagName("a"));
            if (linksPosts[0].Text.ToString() == postTitle)
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
