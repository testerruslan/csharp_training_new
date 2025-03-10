﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase

    {
               protected string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
                       this.baseURL = baseURL;
        }

    
        public void GoToHomePage()
        {
            if (driver.Url == baseURL + "/addressbook/")
                
            {
                return;
            }
            driver.Navigate().GoToUrl("http://localhost/addressbook/addressbook/");
        }


        public void GoToGroupsPage()
        {
            if (driver.Url == baseURL + "/addressbook/group.php"
                && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void GoToContactsPage()
        {
            if (driver.Url == baseURL + "/addressbook/"
                && IsElementPresent(By.Name("Send e-Mail")))
            {
                return;
            }
            driver.FindElement(By.LinkText("add new")).Click();
        }

        public void GoToContactsPageDelit()
        {
            if (driver.Url == baseURL + "/addressbook/"
               && IsElementPresent(By.Name("Send e-Mail")))
            {
                return;
            }
            driver.FindElement(By.LinkText("home")).Click();
        }
    
    }

}
