using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodOrderingApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodOrderingApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Add : ContentPage
    {
        public Add()
        {
            InitializeComponent();
        }

        private void BtnAdd_Clicked(object sender, EventArgs e)
        {
            PopularItem Item1 = new PopularItem()
            {
                Food_Name = "Pizza",
                Imageurl = "https://b.zmtcdn.com/data/o2_assets/d0bd7c9405ac87f6aa65e31fe55800941632716575.png"
            };

            PopularItem Item2 = new PopularItem()
            {
                Food_Name = "Burger",
                Imageurl = "https://b.zmtcdn.com/data/dish_images/ccb7dc2ba2b054419f805da7f05704471634886169.png"
            };

            PopularItem Item3 = new PopularItem()
            {
                Food_Name = "Thali",
                Imageurl = "https://b.zmtcdn.com/data/o2_assets/52eb9796bb9bcf0eba64c643349e97211634401116.png"
            };

            PopularItem Item4 = new PopularItem()
            {
                Food_Name = "Biryani",
                Imageurl = "https://b.zmtcdn.com/data/dish_photos/e10/49ba1093270d34297edc809b1139ee10.jpg"
            };

            PopularItem Item5 = new PopularItem()
            {
                Food_Name = "Sandwich",
                Imageurl = "https://b.zmtcdn.com/data/o2_assets/fc641efbb73b10484257f295ef0b9b981634401116.png"
            };

            PopularItem Item6 = new PopularItem()
            {
                Food_Name = "Pasta",
                Imageurl = "https://b.zmtcdn.com/data/o2_assets/9cf8166717d81ec3212d0707a06749f91634401116.png"
            };

            PopularItem Item7 = new PopularItem()
            {
                Food_Name = "Chinese",
                Imageurl = "https://b.zmtcdn.com/data/o2_assets/2e6d86cd3b90906845c02b3eabf7bc141632716603.png"
            };

            PopularItem Item8 = new PopularItem()
            {
                Food_Name = "Milkshake",
                Imageurl = "https://b.zmtcdn.com/data/dish_photos/516/4d7dea42b94a2f68c8b295699ca28516.jpg"
            };

            SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
            conn.CreateTable<PopularItem>();
            int rows1 = conn.Insert(Item1);
            int rows2 = conn.Insert(Item2);
            int rows3 = conn.Insert(Item3);
            int rows4 = conn.Insert(Item4);
            int rows5 = conn.Insert(Item5);
            int rows6 = conn.Insert(Item6);
            int rows7 = conn.Insert(Item7);
            int rows8 = conn.Insert(Item8);

            var ans = conn.Table<PopularItem>().ToList();
            conn.Close();
        }
    }
}