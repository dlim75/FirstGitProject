using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.PageObjects;
using TestFramework.PageObjects;

namespace TestFramework
{
    public class HomePage
    {
        string titleHomePage = "SeleniumC#";

        public bool IsAt()
        {
            System.Threading.Thread.Sleep(5000);
            return Browser.Title == titleHomePage;
        }
    }
}
