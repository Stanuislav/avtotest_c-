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
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        { }


        public ContactHelper Create(ContactData data)
        {

            ButtonNewContact();
            FillContactForm(data);
            SumbitContactCreation();

            manager.Navigation.ReturnHomePage();

            return this;
        }

        public ContactHelper Modification(int index, ContactData newData)
        {
            manager.Navigation.OpenHomePage();
            SelectModificationContact(index);
            FillContactForm(newData);
            UpdateContact();
            return this;
        }

        public ContactHelper ContactDelete(int index)
        {
            manager.Navigation.OpenHomePage();
            SelectDeleteContact(index);
            SumbitDeleteContact();
            manager.Navigation.OpenHomePage();
            return this;
        }

        public ContactHelper SelectDeleteContact(int indexd)
        {
            indexd += 1;
            driver.FindElement(By.XPath("//div[@id='content']/form[@name='MainForm']/table/tbody/tr[" + indexd  + "]/td/input[@type='checkbox']")).Click();
            driver.FindElement(By.XPath("//div[@id='content']/form[@name='MainForm']/div/input[@value='Delete']")).Click();

            return this;
        }

        public ContactHelper SumbitDeleteContact()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper UpdateContact()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper SelectModificationContact (int index)
        {
            index += 1;
            driver.FindElement(By.XPath("//div[@id='content']/form[@name='MainForm']/table/tbody/tr[" + index  +"]/td/a/img[@title='Edit']")).Click();
            return this;
        }

        public ContactHelper SumbitContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contactData)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contactData.Firstname);
            driver.FindElement(By.Name("middlename")).Click();
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(contactData.Secondname);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contactData.Lastname);
            return this;
        }

        public ContactHelper ButtonNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

       

    }
}
