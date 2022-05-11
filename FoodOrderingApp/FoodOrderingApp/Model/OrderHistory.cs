using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrderingApp.Model
{
    public class OrderHistory
    {
        [PrimaryKey, AutoIncrement]
        public int OrderId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string OrderTotal { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
