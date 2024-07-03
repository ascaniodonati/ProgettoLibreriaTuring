using ProgettoLIbreriaTuring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgettoLIbreriaTuring.DBs
{
    internal class MySqlDB : IPeopleDB
    {
        public PersonCollection Load()
        {
            PersonCollection pc = new PersonCollection
            {
                new Person { Name = "Sucaa"}
            };

            return pc;
        }

        public void Save(PersonCollection pc)
        {

        }

        public void Update(int index, Person person)
        {

        }
    }
}
