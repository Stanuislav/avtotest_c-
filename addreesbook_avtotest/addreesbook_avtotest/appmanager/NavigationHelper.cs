using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Assert = NUnit.Framework.Assert;
using WebAdressbokkTests;

namespace WebAdressbokkTests
{
    public class NavigationHelper : HelperBase
    {

        private string baseURL;


        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }

        public void GoToGroupPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void ReturnHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
        }
    }
}
