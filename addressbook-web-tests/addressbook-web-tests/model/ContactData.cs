using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == other.Firstname && Lastname == other.Lastname;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Lastname.CompareTo(other.Lastname);// +(Firstname.CompareTo(other.Firstname));
        }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode()+Lastname.GetHashCode(); //return 0; if you don't require optimization
        }

        public override string ToString()
        {
            return Lastname+" "+Firstname;
        }

        public string Id { get; set; }

        public string Firstname { get; set; }

        public string Middlename { get; set; }
        
        public string Lastname { get; set; }
        
        public string Nickname { get; set; }
        
        public string Tittle { get; set; }
       
        public string Company { get; set; }
        
        public string Address { get; set; }
        
        public string Home { get; set; }
        
        public string Mobile { get; set; }
        
        public string Work { get; set; }
        
        public string Fax { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string Homepage { get; set; }

        public string Bday { get; set; }

        public string Bmonth { get; set; }

        public string Aday { get; set; }
        
        public string Amonth { get; set; }
        
        public string Byear { get; set; }

        public string Ayear { get; set; }

        public string Address2 { get; set; }

        public string Phone2 { get; set; }
       
        public string Notes { get; set; }

    }
}
