using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;

namespace TestFramework.PageObjects
{
    public static class Browser
    {
        static IWebDriver webDriver = new ChromeDriver(@"C:\Users\dlim7\Documents\browserDllDrivers");
        static WebDriverWait _wait;

        public static string Title
        {
            get { return webDriver.Title; }

        }

        public static IWebDriver Driver
        {
            get
            { return webDriver; }
         }

        public static void Goto(string url)
        {
            webDriver.Manage().Window.Maximize();
            webDriver.Url = url;
        }

        //public static void WaitForElementDisplayed_byName(string elementName)
        //{
        //    try { _wait.Until(webDriver => webDriver.FindElement(By.Name(elementName)).Displayed); }
        //    catch (StaleElementReferenceException) { WaitForElementDisplayed_byName(elementName); }
        //    catch (NoSuchElementException) { WaitForElementDisplayed_byName(elementName); }


        //}

        public static void WaitForElementDisplayedByIdWithTimeout(string elementId, int timeOut)
        {
            try
            {
                new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeOut)).Until(ExpectedConditions.ElementExists((By.Id(elementId))));
            }
            catch (NoSuchElementException e)
            {
            }
        }

        
        public static void WaitForElementDisplayedByLinkTextWithTimeout(string linkText, int timeOut)
        {
            try
            {
                new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeOut)).Until(ExpectedConditions.ElementExists((By.LinkText(linkText))));
            }
            catch (NoSuchElementException e)
            {
            }
        }

        public static void WaitForElementDisplayedByXPathWithTimeout(string xPath, int timeOut)
        {
            try
            {
                new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeOut)).Until(ExpectedConditions.ElementExists((By.XPath(xPath))));
            }
            catch (NoSuchElementException e)
            {
            }
        }

        public static bool WaitForElementDisplayed_byXPath(string path)
        {
            try
            {
                _wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(30));
                _wait.Until(webDriver => webDriver.FindElement(By.XPath(path)).Displayed);
            }
            catch
            {
                //Browser.TakeScreenshot("Exception");
                //LogFunctions.WriteError("Couldn't find element by Xpath. Throwing No element found exception");
                return false;
            }
            return true;
        }

        public static bool WaitForElementDisplayed_byClassName(string className)
        {
            try
            {
                _wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(30));
                _wait.Until(webDriver => webDriver.FindElement(By.ClassName(className)).Displayed);
            }
            catch
            {
                //Browser.TakeScreenshot("Exception");
                //LogFunctions.WriteError("Couldn't find element by Xpath. Throwing No element found exception");
                return false;
            }
            return true;
        }


        public static bool WaitForElementVisible_byXPath(string path)
        {
            try
            {
                _wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(30));
                _wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(path)));
            }
            catch
            {
                //Browser.TakeScreenshot("Exception");
                //LogFunctions.WriteError("Couldn't find element by Xpath. Throwing No element found exception");
                return false;
            }
            return true;
        }

        public static bool WaitForElementClickable_byXPath(string path)
        {
            try
            {
                _wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(30));
                _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(path)));
            }
            catch
            {
                //Browser.TakeScreenshot("Exception");
                //LogFunctions.WriteError("Couldn't find element by Xpath. Throwing No element found exception");
                return false;
            }
            return true;
        }


        internal static void ClickByXPath(string Xpath)
        {
            throw new NotImplementedException();
        }

        

        public static void WaitForAjax(int timeOutSecs = 30)
        {
            try
            {
                var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeOutSecs));
                wait.Until(d => (bool)(d as IJavaScriptExecutor).ExecuteScript("return (window.jQuery != null) && (jQuery.active == 0)"));
            }
            catch
            {
     
                throw new Exception("Timed out for " + timeOutSecs + " secs waiting for Ajax window");
            }
        }

        public static void HoverOver(IWebElement element)
        {

            try
            {
                Actions actions = new Actions(webDriver);
                actions.MoveToElement(element).Perform();

            }

            catch (NoSuchElementException ex)
            {
                
            }
        }

        public static void ClickAndHold(IWebElement element)
        {
            var actions = new Actions(webDriver);
            actions.MoveToElement(element).ClickAndHold().Build().Perform();
            actions.MoveToElement(element).Release();
        }




        public static void Close()
        {
            webDriver.Close();
        }

        internal static void WaitForElementDisplayedByName()
        {
            throw new NotImplementedException();
        }
   
        public static bool IsElementEnabledById(string id)
        {
            try
            {
                if (Browser.Driver.FindElement(By.Id(id)).Enabled)
                {
                    return true;
                }
                return false;
            }
            catch(NoSuchElementException)
            {
                return false;
            }
        
        }

        public static bool IsElementEnabledByXpath(string xPath)
        {
            try
            {
                if (Browser.Driver.FindElement(By.XPath(xPath)).Enabled)
                {
                    return true;
                }
                return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }

        }
    #region Get Element Methods
        public static IWebElement GetElementById(string id)
        {
           
            try
            {
                new WebDriverWait(webDriver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists((By.Id(id))));
                
            }
            catch (NoSuchElementException e)
            {
            }
            return Browser.Driver.FindElement(By.Id(id));

        }

        public static IWebElement GetElementByXpath(string xPath)
        {

            try
            {
                new WebDriverWait(webDriver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists((By.XPath(xPath))));

            }
            catch (NoSuchElementException e)
            {
            }
            return Browser.Driver.FindElement(By.XPath(xPath));

        }
        #endregion
    }
}