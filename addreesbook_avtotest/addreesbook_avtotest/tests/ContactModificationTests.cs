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
            ContactData newContactData = new ContactData("Olya");
            newContactData.Secondname = "Alex";
            newContactData.Lastname = "Pindur";

            app.Navigation.OpenHomePage();

            var count = app.Driver.FindElements(By.XPath("//div[@id='content']/form/table/tbody/tr"));

            if (count.Count < 2)
            {
                app.Contacts.Create(new ContactData("shurkov"));
            }

            app.Contacts.Modification(1, newContactData);
        }

    }
}
