using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Assert = NUnit.Framework.Assert;

namespace WebAdressbokkTests.tests
{
    [TestFixture]
    public class ContactModificationTests:TestBase
    {
        [Test]
        public void ContactModificationTest ()
        {
            ContactData newContactData = new ContactData("Olya");
            newContactData.Secondname = "Alex";
            newContactData.Lastname = "Pindur";

            app.Contacts.Modification(1, newContactData);
        }

    }
}
