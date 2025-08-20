using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAdressbokkTests;

namespace WebAdressbokkTests
{
    public class ContactData
    {
        private string firstname;
        private string secondname = "";
        private string lastname = "";

        public ContactData(string firstname)
        {
            this.firstname = firstname;
        }


        public string Firstname { get { return firstname; } set { firstname = value; } }
        public string Secondname { get { return secondname; } set { secondname = value; } }
        public string Lastname { get { return lastname; } set { lastname = value; } }


    }
}
