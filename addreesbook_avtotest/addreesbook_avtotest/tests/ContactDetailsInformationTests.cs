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
    public class ContactDetailsInformationTests : ContactTestBase
    {
        [Test]

        public void TestDetailsInformationTest ()
        {
            

            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);
            


            ContactData detailsForm = app.Contacts.GetContactDetailsInformationsForm(0);



            var expectedLines = fromForm.FullText.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            var actualLines = detailsForm.FullText.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);




            //Assert.That(detailsForm.AllPhons, Is.EqualTo(fromForm.AllPhons));

            //Assert.That(detailsForm.Fio, Is.EqualTo(fromForm.Fio));
            Assert.That(actualLines, Is.EqualTo(expectedLines));




            //Assert.That(detailsForm.Email1, Is.EqualTo(fromForm.Email1));
            //Assert.That(detailsForm.Email2, Is.EqualTo(fromForm.Email2));
            //Assert.That(detailsForm.Email3, Is.EqualTo(fromForm.Email3));
            //Assert.That(detailsForm.Address, Is.EqualTo(fromForm.Address));
        }

    }
}
