using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace WebAdressbokkTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {

    

        [Test]
        public void LoginWithInvalidCreadentials()
        {
            app.Auth.Logout();

            AccountData account = new AccountData("admin", "1234");
            app.Auth.Login(account);
            Thread.Sleep(1000);

            Assert.That(app.Auth.isLoggedIn(), Is.False);

        }

        [Test]
        public void LoginWithValidCreadentials()
        {
            app.Auth.Logout();

            AccountData account = new AccountData("admin", "secret");
            app.Auth.Login(account);

            Assert.That(app.Auth.isLoggedIn(), Is.True);

        }
    }
}

