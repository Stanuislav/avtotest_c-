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
            contacts.SecondName = "vas";

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contacts);

            Assert.That(oldContacts.Count+1, Is.EqualTo(app.Contacts.GetContactGount()));

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contacts);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.That(oldContacts, Is.EqualTo(newContacts));

            //app.Auth.Logout();

        }





    }
}
