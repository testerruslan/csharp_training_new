﻿using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace WebAddressbookTests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;


        protected LoginHelper loginHelper;
        protected NavigationHelper navigationHelper;
        protected GroupHelper groupHelper;

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook/addressbook/";
            loginHelper = new LoginHelper(this);
            navigationHelper = new NavigationHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
        }

         ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                app.Value = new ApplicationManager();
                newInstance.Navigator.GoToHomePage();
            }
            return app.Value; 
        }



        public IWebDriver Driver
        { 
            get
            {
                return driver;
            }
        }

       

        public LoginHelper Auth
        {
            get 
            { 
                return loginHelper;
            } 
        }

        public NavigationHelper Navigator 
        {
            get 
            {
                return navigationHelper;
            }
        }

        public GroupHelper Groups 
        {
            get 
            {
                return groupHelper;
            }
        }

       
    }
}
