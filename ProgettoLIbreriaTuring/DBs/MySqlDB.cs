using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using ProgettoLIbreriaTuring.Models;
using ProgettoLIbreriaTuring.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgettoLIbreriaTuring.DBs
{
    internal class MySqlDB : IPeopleDB
    {
        MySqlUtils mySql;

        public PersonCollection Load()
        {
            PersonCollection pc = new PersonCollection();
            mySql = MySqlUtils.Instance;

            string query = "SELECT * FROM people";
            MySqlCommand cmd = new MySqlCommand(query, mySql.Connection);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Person p = new Person();
                p.Idx = dr.GetInt16(0);
                p.Name = dr.GetString(1);
                p.Surname = dr.GetString(2);
                p.Address = dr.GetString(3);
                p.PhoneNumber = dr.GetString(4);
                p.Age = dr.GetInt16(5);

                pc.Add(p);
            }

            dr.Close();
            return pc;
        }

        public void Update(int idx, Person p)
        {
            string query = $"UPDATE people " +
                $"SET name='{p.Name}', surname='{p.Surname}', address='{p.Address}', phonenumber='{p.PhoneNumber}', age={p.Age} " +
                $"WHERE id={p.Idx}";

            MySqlCommand cmd = new MySqlCommand(query, mySql.Connection);
            cmd.ExecuteNonQuery();
        }

        public void Add(Person p)
        {
            string query = $"INSERT INTO people" +
                $"(name, surname, address, phoneNumber, age) " +
                $"VALUES ('{p.Name}', '{p.Surname}', '{p.Address}', '{p.PhoneNumber}', {p.Age});";

            MySqlCommand cmd = new MySqlCommand(query, mySql.Connection);
            cmd.ExecuteNonQuery();
        }

        public void Delete(Person p)
        {
            string query = $"DELETE FROM people WHERE id={p.Idx}";

            MySqlCommand cmd = new MySqlCommand(query, mySql.Connection);
            cmd.ExecuteNonQuery();
        }

        public int GetMaxIndex()
        {
            string query = "SELECT MAX(id) FROM people;";
            MySqlCommand cmd = new MySqlCommand(query, mySql.Connection);
            return (int)cmd.ExecuteScalar();
        }
    }
}
