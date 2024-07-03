using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;

namespace ProgettoLIbreriaTuring
{
    public class JavaProperties
    {
        #region Singleton
        private static JavaProperties _instance = null;
        public static JavaProperties Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new JavaProperties();
                return _instance;
            }
        }
        #endregion

        string FilePath;
        Dictionary<string, string> Properties;
        
        /// <summary>
        /// Classe scritta da me per usare su C# i file .properties di Java
        /// </summary>
        private JavaProperties()
        {
            FilePath = Environment.CurrentDirectory + "\\.properties";
            Properties = new Dictionary<string, string>();

            CreateIfNotExist();
            ImportProperties();
        }

        private void CreateIfNotExist()
        {
            if (!File.Exists(FilePath))
                File.Create(FilePath);
        }

        private void ImportProperties()
        {
            using (StreamReader sr = new StreamReader(FilePath))
            {
                while (!sr.EndOfStream)
                {
                    string[] keyValue = sr.ReadLine().Split('=').ToArray();

                    if (keyValue.Length > 1)
                    {
                        string key = keyValue[0].Trim();
                        string value = keyValue[1].Trim();

                        Properties.Add(key, value);
                    }
                }
            }
        }

        public string Get(string key)
        {
            if (Properties.ContainsKey(key))
                return Properties[key];

            return null;
        }

        public void Set(string key, string value)
        {
            Properties[key] = value;
        }

        public void Save()
        {
            CreateIfNotExist();

            using (StreamWriter sw = new StreamWriter(FilePath, false))
            {
                foreach (KeyValuePair<string, string> pair in Properties)
                {
                    sw.WriteLine(pair.Key + "=" + pair.Value);
                }
            }
        }
    }
}
