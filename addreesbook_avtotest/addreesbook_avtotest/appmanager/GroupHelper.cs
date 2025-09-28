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

        public GroupHelper Create(GroupData group)
        {
            manager.Navigation.GoToGroupPage();

            InitNweGroupCreation();
            FilGroupForm(group);
            SumbitGroupCreation();
            ReturnGroupPage();
            return this;
        }

        

        public GroupHelper RemoveGrops(int p)
        {
            manager.Navigation.GoToGroupPage();
            SelectGroup(p);
            RemoveGrops();
            ReturnGroupPage();
            return this;
        }


        public GroupHelper RemoveGrops(GroupData group)
        {
            manager.Navigation.GoToGroupPage();
            SelectGroup(group.Id);
            RemoveGrops();
            ReturnGroupPage();
            return this;
        }


        public GroupHelper Modification(int index, GroupData newData)
        {
            manager.Navigation.GoToGroupPage();
            SelectGroup(index);
            EditGroups();
            FilGroupForm(newData);
            UpdateGroup();
            ReturnGroupPage();
            return this;
        }

        public GroupHelper Modification(GroupData group, GroupData newData)
        {
            manager.Navigation.GoToGroupPage();
            SelectGroup(group.Id);
            EditGroups();
            FilGroupForm(newData);
            UpdateGroup();
            ReturnGroupPage();
            return this;
        }

        private List<GroupData> groupCache = null;


        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigation.GoToGroupPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCache.Add(new GroupData(element.Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }

            return new List<GroupData>(groupCache);
        }

        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count();
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[ " + (index+1) + "]/input")).Click();
            return this;
        }

        public GroupHelper SelectGroup(string id)
        {
            driver.FindElement(By.XPath("//input[@name='selected[]' and @value='"+id+"']")).Click();
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
            groupCache = null;
            return this;
        }

        public GroupHelper FilGroupForm(GroupData groupData)
        {
            Type(By.Name("group_name"), groupData.Name);
            Type(By.Name("group_header"), groupData.Header);
            Type(By.Name("group_footer"), groupData.Footer);
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
            groupCache = null;
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
            groupCache = null;
            return this;
        }
     
    }


}
