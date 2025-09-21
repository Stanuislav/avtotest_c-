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
        public static IEnumerable<ContactData> RandomGroupDataProvider()
        {
            List<ContactData> contact = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contact.Add(new ContactData(GenerateRandomString(10), GenerateRandomString(10))
                {
                    SecondName = GenerateRandomString(50)
 
                });
            }
            return contact;
        }


        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void ContactCreationTest(ContactData contact)
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            Assert.That(oldContacts.Count+1, Is.EqualTo(app.Contacts.GetContactGount()));

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.That(oldContacts, Is.EqualTo(newContacts));

            //app.Auth.Logout();

        }

        [Test]
        public void ContactCreationTestNoRnd()
        {

            ContactData contacts = new ContactData("Shurk", "stas");
            contacts.SecondName = "vas";

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contacts);

            Assert.That(oldContacts.Count + 1, Is.EqualTo(app.Contacts.GetContactGount()));

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contacts);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.That(oldContacts, Is.EqualTo(newContacts));

            //app.Auth.Logout();

        }



    }
}
