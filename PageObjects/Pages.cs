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
    public static class Pages
    {
        public static LoginPage LoginPage
        {
            get
            {
                var loginPage = new LoginPage();
                //PageFactory.InitElements(Browser.Driver, loginPage);
                return loginPage;
            }
        }

        public static HomePage HomePage
        {
            get
            {
                var homePage = new HomePage();
                //PageFactory.InitElements(Browser.Driver, loginPage);
                return homePage;
            }
        }

        public static PostPage PostPage
        {
            get
            {
                var postPage = new PostPage();
                //PageFactory.InitElements(Browser.Driver, loginPage);
                return postPage;
            }
        }

        public static ProfilePage ProfilePage
        {
            get
            {
                var profilePage = new ProfilePage();
                PageFactory.InitElements(Browser.Driver, profilePage);
                return profilePage;
            }
        }
    }
}
