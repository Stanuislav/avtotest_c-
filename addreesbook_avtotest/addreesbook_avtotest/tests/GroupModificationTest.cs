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
    public class GroupModificationTests : GroupTestBase
    {

        [Test]
        public void GroupModificationTest ()
        {
            GroupData newData = new GroupData("12");
            newData.Header = "";
            newData.Footer = "";

            app.Navigation.GoToGroupPage();

            var count = app.Driver.FindElements(By.XPath("//div[@id='content']/form/span"));

            if (count.Count < 1)
            {
                app.Groups.Create(new GroupData("111"));
            }

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldData = oldGroups[0];

            app.Groups.Modification(oldData, newData);

            Assert.That(oldGroups.Count, Is.EqualTo(app.Groups.GetGroupCount()));

            List<GroupData> newGroups = GroupData.GetAll();

            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();

            Assert.That(oldGroups, Is.EqualTo(newGroups));

            foreach(GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.That(newData.Name, Is.EqualTo(group.Name));
                }
            }

        }

    }
}
