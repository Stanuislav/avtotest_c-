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
    [TestFixture]
    public class GroupCreationTests : TestBase
    {


        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("11c");
            group.Header = "Class";
            group.Footer = "Peter";

            app.Groups.Create(group);

            app.Auth.Logout();
        }


        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            app.Groups.Create(group);
 
            app.Auth.Logout();
        }















    }
}
