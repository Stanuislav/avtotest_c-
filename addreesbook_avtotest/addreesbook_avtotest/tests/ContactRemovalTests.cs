using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using WebAdressbokkTests;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Assert = NUnit.Framework.Assert;

namespace WebAdressbokkTests.tests
{
    [TestFixture]
    public class ContactRemovalTests : TestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Contacts.ContactDelete(1);
        }
    }
}
