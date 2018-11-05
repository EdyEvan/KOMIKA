using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KOMIKA.Models;

namespace KOMIKA.DAL
{
    public class DALLogin : Shared
    {
        public bool passwordistrue(Login get)
        {
            string SQL = "Select Count(*) from Adminlogin ";
            SQL += "where username = '" + get.username + "' ";
            SQL += "and password = '" + get.password + "'";
            return (getint(SQL) > 0);
        }
    }
}