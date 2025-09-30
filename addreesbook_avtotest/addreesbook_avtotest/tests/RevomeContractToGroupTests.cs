using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAdressbokkTests
{
    public class RevomeContractToGroupTests : AuthTestBase
    {
        [Test]
        public void TestRemoveContactToGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> odlList = group.GetContacts();
            ContactData contact = ContactData.GetAll().Intersect(odlList).First();


            app.Contacts.RemoveContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            odlList.Remove(contact);
            newList.Sort();
            odlList.Sort();
            Assert.That(odlList, Is.EqualTo(newList));
        }
    }
}
