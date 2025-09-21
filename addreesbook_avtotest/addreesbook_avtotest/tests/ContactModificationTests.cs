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
    public class ContactModificationTests: AuthTestBase
    {
        [Test]
        public void ContactModificationTest ()
        {
            ContactData newContactData = new ContactData("Olya", "Pindur");
            newContactData.SecondName = "Alex";


            app.Navigation.OpenHomePage();

            var countContact = app.Driver.FindElements(By.XPath("//div[@id='content']/form/table/tbody/tr"));

            if (countContact.Count < 2)
            {
                app.Contacts.Create(new ContactData("shurkov", "stas"));
            }

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData toBeContactModify = oldContacts[0];

           
            app.Contacts.Modification(0, newContactData);
            
            Assert.That(oldContacts.Count, Is.EqualTo(app.Contacts.GetContactGount()));

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].FirstName = newContactData.FirstName;
            oldContacts[0].LastName = newContactData.LastName;
            oldContacts.Sort();
            newContacts.Sort();

            Assert.That(oldContacts, Is.EqualTo(newContacts));

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == toBeContactModify.Id)
                {
                    Assert.That(newContactData.FirstName, Is.EqualTo(contact.FirstName));
                    Assert.That(newContactData.LastName, Is.EqualTo(contact.LastName));
                }
            }
        }

    }
}
