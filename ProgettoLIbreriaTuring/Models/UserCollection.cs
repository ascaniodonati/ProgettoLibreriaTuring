using MySql.Data.MySqlClient;
using ProgettoLIbreriaTuring.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoLIbreriaTuring.Models
{
    public class UserCollection : List<User>
    {
        public void FillFromDB(MySqlConnection connection)
        {
            string query = "SELECT * FROM users";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                User u = new User
                {
                    Username = dr.GetString(1),
                    Password = dr.GetString(2),
                    UserType = UserType.DbSaved
                };

                Add(u);
            }

            dr.Close();
        }
    }
}
