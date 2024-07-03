using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoLIbreriaTuring.Utils
{
    public class MySqlUtils
    {
        #region Singleton
        private static MySqlUtils _instance = null;
        public static MySqlUtils Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MySqlUtils();

                return _instance;
            }
        }
        #endregion

        public MySqlConnection Connection { get; set; }
        public bool Connected { get; set; }

        public string Error { get; set; }

        public MySqlConnectState TryToConnect()
        {
            JavaProperties props = JavaProperties.Instance;
            string host = props.Get("MySqlHost");
            string port = props.Get("MySqlPort");
            string username = props.Get("MySqlUser");
            string password = props.Get("MySqlPassword");

            bool incompleteInfo = (host == null || port == null || username == null || password == null);
            if (incompleteInfo)
                return MySqlConnectState.IncompleteInfo;

            string connString = $"Server={host}; Port={port}; database=rubrica; UID={username}; password={password}";
            Connection = new MySqlConnection(connString);

            Connected = false;

            try
            {
                Connection.Open();
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return MySqlConnectState.Failed;
            }

            Connected = true;
            return MySqlConnectState.Connected;
        }

    }

    public enum MySqlConnectState
    {
        Connected,
        Failed,
        IncompleteInfo
    }
}
