using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAdressbokkTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {

        [Test]
        public void TestAddingContactToGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> odlList = group.GetContacts();
            ContactData contact =  ContactData.GetAll().Except(odlList).First();


            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            odlList.Add(contact);
            newList.Sort();
            odlList.Sort();
            Assert.That(odlList, Is.EqualTo(newList));
        }
    }
}
