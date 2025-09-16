using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Assert = NUnit.Framework.Assert;
using WebAdressbokkTests;

namespace WebAdressbokkTests
{ 
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            
            ContactData contactData = new ContactData("stasca");
            contactData.Secondname = "Vesta";
            contactData.Lastname = "Shurk";

            app.Contacts.Create(contactData);
            
            //app.Auth.Logout();

        }





    }
}
