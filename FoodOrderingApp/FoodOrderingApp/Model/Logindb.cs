using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrderingApp.Model
{
    public class Logindb
    {
        [PrimaryKey, AutoIncrement]
        public int LoginID { get; set; }
        public int UserLoggedin { get; set; }
    }
}
