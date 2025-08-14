using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Assert = NUnit.Framework.Assert;

namespace WebAdressbokkTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
       

        [Test]
        public void GroupCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupPage();
            InitNweGroupCreation();
            GroupData group = new GroupData("11c");
            group.Header = "Class";
            group.Footer = "Peter";
            FilGroupForm(group);
            SumbitGroupCreation();
            ReturnGroupPage();
            Logout();
        }









       

       

    


     
    }
}
