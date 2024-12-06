using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdatrogzitoDoga
{
    internal class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public bool Gender { get; set; }
        public string Comment { get; set; } = "";

        public User(string name, int age, string email, string phoneNumber, string address, bool gender, string comment)
        {
            Name = name;
            Age = age;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            Gender = gender;
            Comment = comment;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Email}";
        }

        public string ToFile()
        {
            string comment = this.Comment != "" ? $",{this.Comment}" : "";
            return $"{this.Name},{this.Age},{this.Email},{this.PhoneNumber},{this.Address},{this.Gender}{comment}";
        }
    }
}
