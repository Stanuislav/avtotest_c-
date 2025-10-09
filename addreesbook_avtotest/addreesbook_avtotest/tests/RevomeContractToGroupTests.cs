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

            GroupData groupData = new GroupData("fistForttest");
            ContactData contactData = new ContactData("stas", "shut");
            List<GroupData> groups = GroupData.GetAll();

            if (groups.Count == 0)
            {
                app.Groups.Create(groupData);
            }

            //GroupData group = groups[0];



            List<ContactData> contacts = ContactData.GetAll();
            if (contacts.Count == 0)
            {
                app.Contacts.Create(contactData);
            }


            GroupData targetGroup = null;
            ContactData targetContact = null;


            foreach (GroupData group in groups)
            {
                List<ContactData> contactsInGroup = group.GetContacts();
                List<ContactData> contactsInGroupList = contacts.Intersect(contactsInGroup).ToList();

                if (contactsInGroupList.Count > 0)
                {
                    targetGroup = group;
                    targetContact = contactsInGroupList.First();
                    break;
                }
            }


            if (targetGroup == null)
            {
                
                targetGroup = groups[0];
                targetContact = contacts[0];

               
                app.Contacts.AddContactToGroup(targetContact, targetGroup);
            }



            List<ContactData> odlList = targetGroup.GetContacts();
            //ContactData contact = ContactData.GetAll().Intersect(odlList).First();


            app.Contacts.RemoveContactToGroup(targetContact, targetGroup);

            List<ContactData> newList = targetGroup.GetContacts();
            odlList.Remove(targetContact);
            newList.Sort();
            odlList.Sort();
            Assert.That(odlList, Is.EqualTo(newList));
        }
    }
}
