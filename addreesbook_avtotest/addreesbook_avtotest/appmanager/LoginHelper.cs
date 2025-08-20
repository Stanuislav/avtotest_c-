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
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(account.Username);
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.Id("LoginForm")).Click();
            driver.FindElement(By.Name("pass")).Click();
            driver.FindElement(By.Id("LoginForm")).Click();
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        public void Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }
    }
}
