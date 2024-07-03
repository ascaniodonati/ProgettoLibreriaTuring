using MySql.Data.MySqlClient;
using ProgettoLIbreriaTuring.Models;
using ProgettoLIbreriaTuring.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProgettoLIbreriaTuring.Dialogs
{
    public partial class dlgLogin : Form
    {
        UserCollection AllowedUsers;
        MySqlUtils mySql;

        public dlgLogin()
        {
            InitializeComponent();
            mySql = MySqlUtils.Instance;

            AllowedUsers = new UserCollection();

            AddDefaultUser();
            TryToConnectToMySql();

            if (mySql.Connected)
            {
                AllowedUsers.FillFromDB(mySql.Connection);
            }

            txtUser.Focus();
        }

        private void AddDefaultUser()
        {
            JavaProperties properties = JavaProperties.Instance;
            string userName = properties.Get("DefaultUser");
            string password = properties.Get("DefaultPassword");

            if (userName != null && password != null)
            {
                AllowedUsers.Add(new User {
                    Username = userName,
                    Password = password,
                    UserType = UserType.Default
                });
            }
        }

        private void TryToConnectToMySql()
        {
            MySqlConnectState state = mySql.TryToConnect();
            
            switch (state)
            {
                case MySqlConnectState.Connected:
                    lblMySqlState.Text = "Connesso al database MySQL";
                    break;
                case MySqlConnectState.Failed:
                    lblMySqlState.Text = $"Connessione fallita: {mySql.Error}";
                    break;
                case MySqlConnectState.IncompleteInfo:
                    lblMySqlState.Text = "Le informazioni nel file .properties sono incomplete";
                    break;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            User u = AllowedUsers.FirstOrDefault(
                x => x.Username == txtUser.Text &&
                x.Password == txtPassword.Text
            );

            if (u != null)
            {
                this.Hide();
                dlgMain main = new dlgMain(u);
                main.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Username o password incorretti", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtUser.Text = "";
                txtPassword.Text = "";
                txtUser.Focus();
            }
        }
    }
}
