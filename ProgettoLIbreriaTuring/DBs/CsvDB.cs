using ProgettoLIbreriaTuring.Models;
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
                    Person personFromCSV = Person.FromCSV(line);

                    if (personFromCSV != null)
                        pc.Add(personFromCSV);
                }
            }

            return pc;
        }

        public void Save(PersonCollection pc)
        {
            using (StreamWriter sw = new StreamWriter(sourceFile, false))
            {
                foreach (Person person in pc)
                {
                    sw.WriteLine(person.ToCSV());
                }
            }
        }

        public void Update(int index, Person person)
        {
            
        }
    }
}
