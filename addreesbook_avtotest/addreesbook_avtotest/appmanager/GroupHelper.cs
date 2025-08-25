using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Assert = NUnit.Framework.Assert;
using WebAdressbokkTests;

namespace WebAdressbokkTests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[ " + index + "]/input")).Click();
            return this;
        }

        public GroupHelper InitNweGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper RemoveGrops()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[5]")).Click();
            return this;
        }

        public GroupHelper FilGroupForm(GroupData groupData)
        {
            driver.FindElement(By.Name("group_name")).Click();
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(groupData.Name);
            driver.FindElement(By.Name("group_header")).Click();
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(groupData.Header);
            driver.FindElement(By.Name("group_footer")).Click();
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(groupData.Footer);
            return this;
        }

        public GroupHelper ReturnGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper SumbitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper Create (GroupData group)
        {
            manager.Navigation.GoToGroupPage();

            InitNweGroupCreation();
            FilGroupForm(group);
            SumbitGroupCreation();
            ReturnGroupPage();
            return this;
        }

        public GroupHelper RemoveGrops (int p)
        {
            manager.Navigation.GoToGroupPage();
            SelectGroup(p);
            RemoveGrops();
            ReturnGroupPage();
            return this;
        }

        public GroupHelper Modification (int index, GroupData newData )
        {
            manager.Navigation.GoToGroupPage();
            SelectGroup(index);
            EditGroups();
            FilGroupForm(newData);
            UpdateGroup();
            ReturnGroupPage();
            return this;
        }

        public GroupHelper EditGroups()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper UpdateGroup()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }
    }
}
