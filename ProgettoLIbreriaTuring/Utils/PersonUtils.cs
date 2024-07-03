using ProgettoLIbreriaTuring.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms.VisualStyles;

namespace ProgettoLIbreriaTuring.Utils
{
    internal class PersonUtils
    {
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

        public static Person FromTxtFile(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Il file {filePath} non è stato trovato");

            string fileContent;
            using (StreamReader sr = new StreamReader(filePath))
            {
                fileContent = sr.ReadToEnd();
            }

            string[] data = fileContent.Split('\n');

            if (data.Length < 5)
                return null;

            Person p = new Person();
            if (int.TryParse(Path.GetFileNameWithoutExtension(filePath).Replace("Persona", ""), out int idx))
            {
                p.Idx = idx;
            }
            p.Name = data[0];
            p.Surname = data[1];
            p.Address = data[2];
            p.PhoneNumber = data[3];

            if (!int.TryParse(data[4], out int age))
            {
                return null;
            }
            else
            {
                p.Age = age;
                return p;
            }
        }

        public static void SaveToFile(Person p, string path)
        {
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                sw.WriteLine(p.Name);
                sw.WriteLine(p.Surname);
                sw.WriteLine(p.Address);
                sw.WriteLine(p.PhoneNumber);
                sw.WriteLine(p.Age);
            }
        }
    }
}
