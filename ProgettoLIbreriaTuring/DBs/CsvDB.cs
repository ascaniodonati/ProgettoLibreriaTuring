using ProgettoLIbreriaTuring.Models;
using ProgettoLIbreriaTuring.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProgettoLIbreriaTuring.DBs
{
    public class CsvDB : IPeopleDB
    {
        string sourceFile = "Informazioni.txt";

        public PersonCollection Load()
        {
            PersonCollection pc = new PersonCollection();

            if (!File.Exists(sourceFile))
                throw new FileNotFoundException($"Il file {sourceFile} non è stato trovato");

            using (StreamReader sr = new StreamReader(sourceFile))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    Person personFromCSV = PersonUtils.FromCSV(line);

                    if (personFromCSV != null)
                        pc.Add(personFromCSV);
                }
            }

            return pc;
        }

        public void Add(Person p)
        {
            using (StreamWriter sw = new StreamWriter(sourceFile, true))
            {
                sw.WriteLine(p.ToCSV());
            }
        }

        public void Delete(Person p)
        {
            PersonCollection pc = Load();
            pc.Remove(p);

            Save(pc);
        }

        public void Update(int idx, Person p)
        {
            PersonCollection pc = Load();
            pc.RemoveAt(idx);
            pc.Insert(idx, p);

            Save(pc);
        }

        public void Save(PersonCollection pc)
        {
            using (StreamWriter sw = new StreamWriter(sourceFile, false))
            {
                foreach (Person p in pc)
                {
                    sw.WriteLine(p.ToCSV());
                }
            }
        }

        public int GetMaxIndex()
        {
            return 10;
        }
    }
}
