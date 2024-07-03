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
        void Add(Person p);
        void Delete(Person p);
        void Update(int idx, Person p);
        int GetMaxIndex();
    }
}
