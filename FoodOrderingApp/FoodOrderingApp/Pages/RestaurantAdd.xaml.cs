using FoodOrderingApp.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodOrderingApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestaurantAdd : ContentPage
    {
        public RestaurantAdd()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Restaurant Item1 = new Restaurant()
            {
                Restaurant_Name = "BurgerDi",
                Imageurl = "https://mir-s3-cdn-cf.behance.net/project_modules/1400/dc9cf566811953.5b22ce31f3821.jpg",
                Rating = "4.4",
                Distance = "1 Km"
            };

            Restaurant Item2 = new Restaurant()
            {
                Restaurant_Name = "The Orchid",
                Imageurl = "https://b.zmtcdn.com/data/pictures/4/18937844/b9ddc804cfb040ba1c0b8d416bf72f94.jpg",
                Rating = "4.2",
                Distance = "2.5 Km"
            };

            Restaurant Item3 = new Restaurant()
            {
                Restaurant_Name = "Jugaadi Adda",
                Imageurl = "https://b.zmtcdn.com/data/reviews_photos/a04/2eb0257dae7a05b401c0277c276e0a04_1594293745.jpg",
                Rating = "4.2",
                Distance = "2 Km"
            };

            Restaurant Item4 = new Restaurant()
            {
                Restaurant_Name = "The Belgian Waffle Co.",
                Imageurl = "https://lh3.googleusercontent.com/p/AF1QipPRhTz5X1QE6f2eKBHlN1j9GfFI06mMrCbb49Ex=w1080-h608-p-no-v0",
                Rating = "4.4",
                Distance = "4 Km"
            };

            Restaurant Item5 = new Restaurant()
            {
                Restaurant_Name = "Bhagyoday Restaurant",
                Imageurl = "https://media-cdn.tripadvisor.com/media/photo-s/21/e9/b4/12/hotel-bhagyoday.jpg",
                Rating = "4.3",
                Distance = "3.5 Km"
            };

            Restaurant Item6 = new Restaurant()
            {
                Restaurant_Name = "Jay Bahavani vadapav",
                Imageurl = "https://www.jbvfoods.com/wp-content/uploads/2021/08/interior-2.jpg",
                Rating = "4.2",
                Distance = "1 Km"
            };

            Restaurant Item7 = new Restaurant()
            {
                Restaurant_Name = "Dheemi Aanch Restaurant",
                Imageurl = "https://10619-2.s.cdn12.com/rests/original/102_506184619.jpg",
                Rating = "3.6",
                Distance = "4.5 Km"
            };

            Restaurant Item8 = new Restaurant()
            {
                Restaurant_Name = "The Biryani Life",
                Imageurl = "https://pbs.twimg.com/media/EmDaOEXWkAMrD8C.jpg",
                Rating = "4.0",
                Distance = "5 Km"
            };

            SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
            conn.CreateTable<Restaurant>();
            int rows1 = conn.Insert(Item1);
            int rows2 = conn.Insert(Item2);
            int rows3 = conn.Insert(Item3);
            int rows4 = conn.Insert(Item4);
            int rows5 = conn.Insert(Item5);
            int rows6 = conn.Insert(Item6);
            int rows7 = conn.Insert(Item7);
            int rows8 = conn.Insert(Item8);

            var ans = conn.Table<Restaurant>().ToList();
            conn.Close();
        }
    }
}