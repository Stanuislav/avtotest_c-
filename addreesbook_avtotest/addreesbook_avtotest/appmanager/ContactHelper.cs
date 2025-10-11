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

        public void RemoveContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigation.OpenHomePage();
            SelectGroup(group.Name);
            SelectContact(contact.Id);
            RemoveContactFromGroup();

        }

        

        public ContactHelper AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigation.OpenHomePage();
            ClearGroupFilter();
            SelectContact(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
            return this;
        }

        

        public ContactHelper Modification(int index, ContactData newData)
        {
            //manager.Navigation.OpenHomePage();

            SelectModificationContact(index);
            FillContactForm(newData);
            UpdateContact();
            manager.Navigation.ReturnHomePage();

            return this;
        }

        public ContactHelper Modification(ContactData contact, ContactData newData)
        {
            //manager.Navigation.OpenHomePage();

            SelectModificationContact(contact.Id);
            FillContactForm(newData);
            UpdateContact();
            manager.Navigation.ReturnHomePage();

            return this;
        }

        public ContactHelper ContactDelete(int index)
        {
            //manager.Navigation.OpenHomePage();
            SelectDeleteContact(index);
            SumbitDeleteContact();
            manager.Navigation.OpenHomePage();
            return this;
        }

        public ContactHelper ContactDelete(ContactData contact)
        {
            //manager.Navigation.OpenHomePage();
            SelectDeleteContact(contact.Id);
            SumbitDeleteContact();
            manager.Navigation.OpenHomePage();
            return this;
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigation.OpenHomePage();
            SelectModificationContact(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string secondName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string email1 = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");


            return new ContactData(firstName, lastName)
            {
                SecondName = secondName,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email1 = email1,
                Email2 = email2,
                Email3 = email3,
                Address = address,

            };
        }

        public ContactData GetContactInformationFromTable(int index)
        {
          
            manager.Navigation.OpenHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allPhons = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhons = allPhons,
            };
        }

        public ContactData GetContactDetailsInformationsForm1(int index)
        {
            manager.Navigation.OpenHomePage();
            SelectModificationContact(index);
            string addressM = driver.FindElement(By.Name("address")).GetAttribute("value");
            string email1M = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2M = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3M = driver.FindElement(By.Name("email3")).GetAttribute("value");


            manager.Navigation.OpenHomePage();
            SelectDetailsContact(index);

            string homePhone = string.Empty;
            string mobilePhone = string.Empty;
            string workPhone = string.Empty;
            string address = string.Empty;
            string email1 = string.Empty;
            string email2 = string.Empty;
            string email3 = string.Empty;

            string fullText = driver.FindElement(By.Id("content")).Text;

            string[] lines = fullText.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(line => line.Trim())
                .Where(line => !string.IsNullOrEmpty(line))
                .ToArray();

            string fio = driver.FindElement(By.XPath("//div[@id='content']/b")).Text;
            
            
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith("H:"))
                {
                    homePhone = lines[i].Replace("H:", "").Trim();
                }
                else if (lines[i].StartsWith("M:"))
                {
                    mobilePhone = lines[i].Replace("M:", "").Trim();
                }
                else if (lines[i].StartsWith("W:"))
                {
                    workPhone = lines[i].Replace("W:", "").Trim();
                }
                else if (lines[i] == addressM)
                {
                    address = addressM;
                }
                else if (lines[i]== email1M)
                {
                    email1 = email1M;
                }
                else if (lines[i] == email2M)
                {
                    email2 = email2M;
                }
                else if (lines[i] == email3M)
                {
                    email3 = email3M;
                }
            }

           

            return new ContactData("", "")
            {
                Fio = fio,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email1 = email1,
                Email2 = email2,
                Email3 = email3,
                Address = address
            };
        }



        public ContactData GetContactDetailsInformationsForm(int index)
        {
            manager.Navigation.OpenHomePage();
            SelectDetailsContact(index);

            

            string fullText = driver.FindElement(By.Id("content")).Text;


            return new ContactData()
            {
                FullText = fullText,

            };
        }


        private string GetEmailText(string emailValue)
        {
            var elements = driver.FindElements(By.XPath($"//div[@id='content']/a[@href='mailto:{emailValue}']"));
            return elements.Count > 0 ? elements[0].Text : string.Empty;
        }

        private List<ContactData> contactCash = null;

        public List<ContactData> GetContactList()
        {
            if (contactCash == null)
            {
                contactCash = new List<ContactData>();
                manager.Navigation.OpenHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//div[@id='content']/form[@name='MainForm']/table/tbody/tr[@name='entry']"));
                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> td = element.FindElements(By.TagName("td"));
                    string lastName = td[2].Text;
                    string firstName = td[1].Text;

                    contactCash.Add(new ContactData(lastName, firstName)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("id")
                    }) ;
                }
            }

            return new List<ContactData>(contactCash);
        }

        public int GetContactGount()
        {

            return driver.FindElements(By.XPath("//div[@id='content']/form[@name='MainForm']/table/tbody/tr[@name='entry']")).Count();
        }

        public ContactHelper SelectDeleteContact(int indexd)
        {
            indexd += 1;
            driver.FindElement(By.XPath("//div[@id='content']/form[@name='MainForm']/table/tbody/tr[" + (indexd+1)  + "]/td/input[@type='checkbox']")).Click();
            driver.FindElement(By.XPath("//div[@id='content']/form[@name='MainForm']/div/input[@value='Delete']")).Click();

            return this;
        }

        public ContactHelper SelectDeleteContact(string id)
        {
            driver.FindElement(By.XPath("//input[@name='selected[]' and @id='" + id + "']")).Click();
            driver.FindElement(By.XPath("//div[@id='content']/form[@name='MainForm']/div/input[@value='Delete']")).Click();

            return this;
        }

        public ContactHelper SumbitDeleteContact()
        {
            driver.SwitchTo().Alert().Accept();
            contactCash = null;
            return this;
        }

        public ContactHelper UpdateContact()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCash = null;
            return this;
        }

        public ContactHelper SelectModificationContact (int index)
        {
            index += 1;
            driver.FindElement(By.XPath("//div[@id='content']/form[@name='MainForm']/table/tbody/tr[" + (index+1)  +"]/td/a/img[@title='Edit']")).Click();
            return this;
        }

        public ContactHelper SelectModificationContact(string id)
        {
            driver.FindElement(By.XPath("//a[@href='edit.php?id=" + id + "']")).Click();
            return this;
        }

        public ContactHelper SumbitContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            contactCash = null;
            return this;
        }

        public ContactHelper FillContactForm(ContactData contactData)
        {
            Type(By.Name("firstname"), contactData.FirstName);
            Type(By.Name("middlename"), contactData.SecondName);
            Type(By.Name("lastname"), contactData.LastName);
            return this;
        }

        public ContactHelper ButtonNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }


        public ContactHelper SelectDetailsContact(int index)
        {
            manager.Navigation.OpenHomePage();
            driver.FindElement(By.XPath("//div[@id='content']/form[@name='MainForm']/table/tbody/tr[" + (index + 2) + "]/td/a/img[@title='Details']")).Click();
            return this;
        }

        public void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }

        public void SelectContact(string contactId)
        {
            driver.FindElement(By.Id(contactId)).Click();
        }

        public void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        public void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        public void SelectGroup(string name)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(name);
        }

        public void RemoveContactFromGroup()
        {
            driver.FindElement(By.Name("remove")).Click();
        }

        
    }
}
