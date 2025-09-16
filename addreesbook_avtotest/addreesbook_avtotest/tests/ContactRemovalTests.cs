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
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Contacts.ContactDelete(1);
        }
    }
}
