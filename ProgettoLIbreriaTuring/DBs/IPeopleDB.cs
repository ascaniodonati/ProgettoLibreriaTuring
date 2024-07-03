using ProgettoLIbreriaTuring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgettoLIbreriaTuring.DBs
{
    public interface IPeopleDB
    {
        PersonCollection Load();
        void Save(PersonCollection pc);
        void Update(int index, Person person);
    }
}
