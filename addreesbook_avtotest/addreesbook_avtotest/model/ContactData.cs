using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAdressbokkTests;

namespace WebAdressbokkTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstname;
        private string secondname = "";
        private string lastname;

        public ContactData(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
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
            return firstname == other.firstname && lastname == other.lastname;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(firstname, lastname); ;
        }

        public override string ToString()
        {
            return $"firstname={firstname} lastname={lastname}";
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            int firstnameCompare = firstname.CompareTo(other.firstname);
            if (firstnameCompare != 0)
            {
                return firstnameCompare;
            }
            return lastname.CompareTo(other.lastname);
        }


        public string Firstname { get { return firstname; } set { firstname = value; } }
        public string Secondname { get { return secondname; } set { secondname = value; } }
        public string Lastname { get { return lastname; } set { lastname = value; } }


    }
}
