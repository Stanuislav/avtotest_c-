using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAdressbokkTests;
using LinqToDB.Mapping;

namespace WebAdressbokkTests
{
    [Table(Name ="group_list")]
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {


        public GroupData(string name)
        {
            Name = name;

        }

        public GroupData()
        {

        }

        public  bool Equals (GroupData other)
        {
            if (Object.ReferenceEquals (this, null))
            {
                 return false;
            }
            if (Object.ReferenceEquals (this, other))
            {
                return true;    
            }
            return Name == other.Name;
        }

        public override int GetHashCode ()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return "name=" + Name + "\nheader " + Header + "\footer " + Footer;
        }

        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }

        [Column(Name = "group_name"), NotNull]
        public string Name { get;  set; }


        [Column(Name = "group_header"), NotNull]
        public string Header { get; set; }

        [Column(Name = "group_footer"), NotNull]
        public string Footer { get; set; }

        [Column(Name = "group_id"), PrimaryKey, Identity]
        public string Id { get; set; }

        public static List<GroupData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Groups select g).ToList();
            }
        }

    }
}
