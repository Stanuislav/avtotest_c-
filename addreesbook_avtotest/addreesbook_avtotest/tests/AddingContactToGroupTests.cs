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

            GroupData groupData = new GroupData("fistForttest");
            GroupData newGroupData = new GroupData("fistForttest1");
            ContactData contactData = new ContactData("stas", "shut");

            List<GroupData> groups = GroupData.GetAll();

            if (groups.Count == 0 )
            {
                app.Groups.Create(groupData);
            }

            // GroupData group = groups[0];
            GroupData targetGroup = null;
            ContactData targetContact = null;

            List <ContactData> contacts = ContactData.GetAll();
            if (contacts.Count == 0)
            {
                app.Contacts.Create(contactData);
            }


            foreach (GroupData group in groups)
            {
                List<ContactData> contactsInGroup = group.GetContacts();
                List<ContactData> contactsNotInGroup = contacts.Except(contactsInGroup).ToList();
                
                if (contactsNotInGroup.Count > 0)
                {
                    targetGroup = group;
                    targetContact = contactsNotInGroup.First();
                    break;
                }
            }

            if (targetGroup == null)
            {
                foreach (GroupData group in groups)
                {
                    List<ContactData> contactsInGroup = group.GetContacts();
                    if (contactsInGroup.Count > 0)
                    {
                        targetGroup = group;
                        targetContact = contactsInGroup.First();


                        app.Contacts.RemoveContactToGroup(targetContact, targetGroup);
                        break;
                    }
                }
            }

            if (targetGroup == null)
            {
                app.Groups.Create(newGroupData);
                groups = GroupData.GetAll();
                targetGroup = groups.Last();
                targetContact = contacts.First();
            }


            List<ContactData> odlList = targetGroup.GetContacts();


            //ContactData contact =  ContactData.GetAll().Except(odlList).First();


            app.Contacts.AddContactToGroup(targetContact, targetGroup);

            List<ContactData> newList = targetGroup.GetContacts();
            odlList.Add(targetContact);
            newList.Sort();
            odlList.Sort();
            Assert.That(odlList, Is.EqualTo(newList));
        }
    }
}
