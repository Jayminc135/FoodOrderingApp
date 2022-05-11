using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrderingApp.Model
{
    public class FoodItem
    {
        public Guid Food_ID { get; set; }
        public string Food_Name { get; set; }
        public string Imageurl { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Restaurant_Name { get; set; }
    }
}
