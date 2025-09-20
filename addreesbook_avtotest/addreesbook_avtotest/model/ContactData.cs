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

        private string secondname = "";


        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
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
            return Firstname == other.Firstname && Lastname == other.Lastname;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Firstname, Lastname); ;
        }

        public override string ToString()
        {
            return $"firstname={Firstname} lastname={Lastname}";
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            int firstnameCompare = Firstname.CompareTo(other.Firstname);
            if (firstnameCompare != 0)
            {
                return firstnameCompare;
            }
            return Firstname.CompareTo(other.Firstname);
        }


        public string Firstname { get; set; }
        public string Secondname { get; set; }
        public string Lastname { get; set; }
        public string Id { get; set; }

    }
}
