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
            app.Navigation.OpenHomePage();

            var count = app.Driver.FindElements(By.XPath("//div[@id='content']/form/table/tbody/tr")) ;

            if (count.Count < 2)
            {
                app.Contacts.Create(new ContactData("shurkov", "stas"));
            }

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData toBeContactRevome = oldContacts[0];

            app.Contacts.ContactDelete(0);
            

            Assert.That(oldContacts.Count - 1, Is.EqualTo(app.Contacts.GetContactGount()));

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.That(oldContacts, Is.EqualTo(newContacts));

            foreach(ContactData contact in newContacts)
            {
                Assert.That(contact.Id, Is.Not.EqualTo(toBeContactRevome.Id));
            }
        }
    }
}
