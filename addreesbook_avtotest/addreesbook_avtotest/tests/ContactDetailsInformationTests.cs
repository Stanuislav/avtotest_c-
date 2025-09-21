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
    public class ContactDetailsInformationTests : AuthTestBase
    {
        [Test]

        public void TestDetailsInformationTest ()
        {
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);
            ContactData detailsForm = app.Contacts.GetContactDetailsInformationsForm(0);

            Assert.That(detailsForm.Address, Is.EqualTo(fromForm.Address));
            Assert.That(detailsForm.AllPhons, Is.EqualTo(fromForm.AllPhons));
            Assert.That(detailsForm.Fio, Is.EqualTo(fromForm.Fio));
        }

    }
}
