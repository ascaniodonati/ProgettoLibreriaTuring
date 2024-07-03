using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgettoLIbreriaTuring.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }

        public string ToCSV()
        {
            return $"{Name};{Surname};{Address};{PhoneNumber};{Age}";
        }

        public static Person FromCSV(string csvString)
        {
            string[] csvSplitted = csvString.Split(';');

            //Stringa non valida
            if (csvSplitted.Length < 5)
                throw new FormatException("La stringa contiene meno di 5 proprietà");

            Person p = new Person();
            p.Name = csvSplitted[0];
            p.Surname = csvSplitted[1];
            p.Address = csvSplitted[2];
            p.PhoneNumber = csvSplitted[3];

            if (!int.TryParse(csvSplitted[4], out int age))
            {
                throw new ArgumentException("La proprietà \"Età\" deve essere una cifra numerica");
            }
            else
            {
                p.Age = age;
                return p;
            }
        }
    }
}
