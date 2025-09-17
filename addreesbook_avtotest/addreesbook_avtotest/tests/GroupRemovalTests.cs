using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using WebAdressbokkTests;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Assert = NUnit.Framework.Assert;

namespace WebAdressbokkTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {


        [Test]
        public void GroupRemovalTest()
        {
            app.Navigation.GoToGroupPage();
            var count = app.Driver.FindElements(By.XPath("//div[@id='content']/form/span"));
           
            if (count.Count < 1)
            {
                app.Groups.Create(new GroupData("111"));
            }

            app.Groups.RemoveGrops(1);
            
            //app.Auth.Logout();
        }

    }
}
