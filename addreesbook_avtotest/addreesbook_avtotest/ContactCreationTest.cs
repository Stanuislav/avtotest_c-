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
    public class ContactCreationTests : TestBase
    {
        
        [Test]
        public void ContactCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            ButtonNewContact();
            ContactData contactData = new ContactData("stasca");
            contactData.Secondname = "Vesta";
            contactData.Lastname = "Shurk";
            FillContactForm(contactData);
            SumbitContactCreation();
            ReturnHomePage();
            Logout(); 

        }



 
      
    }
}
