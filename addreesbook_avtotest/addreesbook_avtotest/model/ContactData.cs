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
        public string fullAddress;
        public string fullPhome;
        public string fullEmail;
        public string fullText;


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


        public string FullAddress
        {
            get
            {
                if (fullAddress != null)
                {
                    return fullAddress;
                }
                else
                {
                    return ClenUpAddress(Address).Trim();
                }
            }
            set
            {
                fullAddress = value;
            }
        }


        private string ClenUpAddress(string address)
        {
            if (address == null || address == "")
            {
                return "";
            }
            return address + "";
        }







        public string FullText
        {
            get
            {
                if (fullText != null)
                {
                    return fullText;
                }
                else
                {
                    var parts = new List<string>();

                    
                    if (!string.IsNullOrEmpty(FirstName) || !string.IsNullOrEmpty(LastName))
                        parts.Add($"{FirstName} {LastName}".Trim());

                    
                    if (!string.IsNullOrEmpty(Address))
                        parts.Add(Address.Trim());

                    
                    var phones = new List<string>();
                    if (!string.IsNullOrEmpty(HomePhone))
                        phones.Add($"H: {HomePhone}");
                    if (!string.IsNullOrEmpty(MobilePhone))
                        phones.Add($"M: {MobilePhone}");
                    if (!string.IsNullOrEmpty(WorkPhone))
                        phones.Add($"W: {WorkPhone}");

                    if (phones.Count > 0)
                        parts.AddRange(phones);

                    
                    var emails = new List<string>();
                    if (!string.IsNullOrEmpty(Email1))
                        emails.Add(Email1);
                    if (!string.IsNullOrEmpty(Email2))
                        emails.Add(Email2);
                    if (!string.IsNullOrEmpty(Email3))
                        emails.Add(Email3);

                    if (emails.Count > 0)
                        parts.AddRange(emails);

                    return string.Join("\r\n", parts);
                }
            }
            set
            {
                fullText = value;
            }
        }


        private string ClenUpFullText(string address)
        {
            if (address == null || address == "")
            {
                return "";
            }
            return address + "";
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
