using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgettoLIbreriaTuring.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }
    }

    public enum UserType
    {
        Default,
        MySql,
        DbSaved
    }
}
