using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAdressbokkTests;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace WebAdressbokkTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public string allPhons;
        public string fio;

        public ContactData(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }

        public ContactData()
        {

        }
        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(this, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return FirstName == other.FirstName && LastName == other.LastName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName); ;
        }

        public override string ToString()
        {
            return $"firstname={FirstName} lastname={LastName}";
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            int firstnameCompare = FirstName.CompareTo(other.FirstName);
            if (firstnameCompare != 0)
            {
                return firstnameCompare;
            }
            return FirstName.CompareTo(other.FirstName);
        }

        [Column(Name = "id"), PrimaryKey]
        public string Id { get; set; }

        [Column(Name = "firstname"), NotNull]
        public string FirstName { get; set; }

        [Column(Name = "middlename"), NotNull]
        public string SecondName { get; set; }

        [Column(Name = "lastname"), NotNull]
        public string LastName { get; set; }

        [Column(Name = "address"), NotNull]
        public string Address { get; set; }

        [Column(Name = "home"), NotNull]
        public string HomePhone { get; set; }

        [Column(Name = "mobile"), NotNull]
        public string MobilePhone { get; set; }

        [Column(Name = "work"), NotNull]
        public string WorkPhone { get; set; }

        [Column(Name = "email"), NotNull]
        public string Email1 { get; set; }

        [Column(Name = "email2"), NotNull]
        public string Email2 { get; set; }

        [Column(Name = "email3"), NotNull]
        public string Email3 { get; set; }

        public string AllPhons {
            get 
            { 
                if(allPhons != null)
                {
                    return allPhons;
                }
                else
                {
                    return (ClenUp(HomePhone) + ClenUp(MobilePhone) + ClenUp(WorkPhone)).Trim();
                }
            }
            set 
            { 
                allPhons = value;
            }
        }

        public string ClenUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }

        public string Fio
        {
            get
            {
                if (fio != null)
                {
                    return fio;
                }
                else
                {
                    return (ClenUpFio(FirstName) + ClenUpFio(SecondName) + ClenUpFio(LastName)).Trim();
                }
            }
            set
            {
                fio = value;
            }
        }

        private string ClenUpFio(string fio)
        {
            if (fio == null || fio == "")
            {
                return "";
            }
            return fio + " ";
        }


        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Contacts select g).ToList();
            }
        }
    }
}
