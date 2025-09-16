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
    public class GroupModificationTests : AuthTestBase
    {

        [Test]
        public void GroupModificationTest ()
        {
            GroupData newData = new GroupData("12");
            newData.Header = "Class12";
            newData.Footer = "Peter12";

            app.Groups.Modification(1, newData);

        }

    }
}
