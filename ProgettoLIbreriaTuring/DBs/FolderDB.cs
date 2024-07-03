using ProgettoLIbreriaTuring.Models;
using ProgettoLIbreriaTuring.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProgettoLIbreriaTuring.DBs
{
    internal class FolderDB : IPeopleDB
    {
        string infoDirPath;

        public FolderDB()
        {
            infoDirPath = Environment.CurrentDirectory + "\\Informazioni";
        }

        public PersonCollection Load()
        {
            if (!Directory.Exists(infoDirPath))
                throw new DirectoryNotFoundException($"La cartella {infoDirPath} non è stata trovata");

            PersonCollection pc = new PersonCollection();

            string[] peoplePaths = Directory
                .GetFiles(infoDirPath)
                .Where(x => Path.GetFileName(x).StartsWith("Persona"))
                .ToArray();

            bool someFilesNotValid = false;
            foreach (string personPath in peoplePaths)
            {
                Person p = PersonUtils.FromTxtFile(personPath);

                if (p != null)
                    pc.Add(p);
                else
                    someFilesNotValid = true;
            }

            if (someFilesNotValid)
                MessageBox.Show("Alcuni file non sono validi");

            return pc;
        }

        public void Update(int index, Person p)
        {
            string newFileName = $"{infoDirPath}\\Persona{index + 1}.txt";
            File.Delete(newFileName);

            Add(p);
        }

        public void Add(Person p)
        {
            string newFileName = $"{infoDirPath}\\Persona{GetMaxIndex() + 1}.txt";

            using (StreamWriter sw = new StreamWriter(newFileName))
            {
                sw.WriteLine(p.Name);
                sw.WriteLine(p.Surname);
                sw.WriteLine(p.Address);
                sw.WriteLine(p.PhoneNumber);
                sw.WriteLine(p.Age);
            }
        }

        public void Delete(Person p)
        {
            string fileToDelete = $"{infoDirPath}\\Persona{p.Idx}.txt";
            File.Delete(fileToDelete);
        }

        public int GetMaxIndex()
        {
            try
            {
                int maxIndex = Directory
                    .GetFiles(infoDirPath)
                    .Where(x => x.Contains("Persona"))
                    .Select(x => int.Parse(Path.GetFileNameWithoutExtension(x).Replace("Persona", "")))
                    .Max();

                return maxIndex;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}
