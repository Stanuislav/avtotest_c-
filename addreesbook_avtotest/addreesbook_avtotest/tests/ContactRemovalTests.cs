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
                app.Contacts.Create(new ContactData("shurkov"));
            }

            
            app.Contacts.ContactDelete(1);
        }
    }
}
