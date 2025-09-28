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

        public static IEnumerable<GroupData> ContactDataFromFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.csv");
            foreach (string line in lines)
            {
                string[] part = line.Split(',');
                groups.Add(new GroupData(part[0])
                {
                    Header = part[1],
                    Footer = part[2]
                });
            }
            return groups;
        }


        [Test, TestCaseSource("ContactDataFromFile")]
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
