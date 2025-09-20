using System;
using System.Text;
using System.Text.RegularExpressions;
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
    public class GroupRemovalTests : AuthTestBase
    {


        [Test]
        public void GroupRemovalTest()
        {
            app.Navigation.GoToGroupPage();
            var count = app.Driver.FindElements(By.XPath("//div[@id='content']/form/span"));
           
            if (count.Count < 1)
            {
                app.Groups.Create(new GroupData("111"));
            }

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            GroupData toBeRemoved = oldGroups[0];

            app.Groups.RemoveGrops(0);

            Assert.That(oldGroups.Count - 1, Is.EqualTo(app.Groups.GetGroupCount()));

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.That(oldGroups, Is.EqualTo(newGroups));

            foreach(GroupData group in newGroups)
            {
                Assert.That(group.Id, Is.Not.EqualTo(toBeRemoved.Id));
            }
            //app.Auth.Logout();
        }

    }
}
