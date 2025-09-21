using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAdressbokkTests;
using System.Text.RegularExpressions;

namespace WebAdressbokkTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public string allPhons;

        public ContactData(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
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


        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
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

        public string Id { get; set; }

    }
}
