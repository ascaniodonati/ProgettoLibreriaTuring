using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProgettoLIbreriaTuring.Models
{
    public class Person
    {
        public int Idx { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }

        public string ToCSV()
        {
            return $"{Name};{Surname};{Address};{PhoneNumber};{Age}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Person p)
            {
                return
                    Name == p.Name &&
                    Surname == p.Surname &&
                    Address == p.Address &&
                    PhoneNumber == p.PhoneNumber &&
                    Age == p.Age;
            }

            return base.Equals(obj);
        }
    }
}
