using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Activity2Part1.Models
{
    public class UserModel
    {
        public UserModel(string Name, string Email, string Phone) 
        {
            this.Name = Name; 
            this.EmailAddress = Email;
            this.PhoneNumber = Phone;
        }

        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
    }
}