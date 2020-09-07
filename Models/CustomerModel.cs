using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Activity3Part1.Models
{
    public class CustomerModel
    {
        public CustomerModel(int _ID, string _Name, int _Age)
        {
            this.ID = _ID;
            this.Name = _Name;
            this.Age = _Age;
        }

        public int ID { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }
    }
}