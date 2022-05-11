using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrderingApp.Model
{
    public class Restaurant
    {
        public Guid Restaurant_Id { get; set; }
        public string Restaurant_Name { get; set; }
        public string Imageurl { get; set; }
        public string Rating { get; set; }
        public string Distance { get; set; }
    }
}
