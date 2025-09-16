using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Assert = NUnit.Framework.Assert;
using WebAdressbokkTests;

namespace WebAdressbokkTests
{
    public class LoginHelper : HelperBase
    {


        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }

       
        public void Login(AccountData account)
        {
            if (isLoggedIn())
            {
                if (isLoggedIn(account))
                {
                    return;
                }

                Logout();
            }


            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);


            driver.FindElement(By.Id("LoginForm")).Click();
            driver.FindElement(By.Name("pass")).Click();
            driver.FindElement(By.Id("LoginForm")).Click();
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        public bool isLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }

        public bool isLoggedIn(AccountData account)
        {
            return isLoggedIn()
            && driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text 
                == "(" + account.Username + ")"; 
        }

        public void Logout()
        {
            if (isLoggedIn())
            { 
                driver.FindElement(By.LinkText("Logout")).Click();  
            }
            
        }
    }
}
