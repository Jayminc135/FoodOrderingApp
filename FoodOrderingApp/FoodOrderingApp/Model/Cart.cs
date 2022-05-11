using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrderingApp.Model
{
    public class Cart
    {
        public Guid CartId { get; set; }
        public string Food_Name { get; set; }
        public string Price { get; set; }
        public string Quantity { get; set; }
        public string TotalAmount { get; set; }
    }
}
