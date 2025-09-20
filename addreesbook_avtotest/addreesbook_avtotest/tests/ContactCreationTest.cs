using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAdressbokkTests
{ 
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            
            ContactData contacts = new ContactData("Shurk", "stas");
            contacts.Secondname = "vas";

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contacts);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contacts);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.That(oldContacts, Is.EqualTo(newContacts));

            //app.Auth.Logout();

        }





    }
}
