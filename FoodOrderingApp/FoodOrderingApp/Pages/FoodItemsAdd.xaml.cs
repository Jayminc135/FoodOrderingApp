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
    public partial class FoodItemsAdd : ContentPage
    {
        public FoodItemsAdd()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            FoodItem Item1 = new FoodItem()
            {
                Food_Name = "Fix Dinner Thali",
                Imageurl = "https://b.zmtcdn.com/data/dish_photos/728/24ad377edcbbab56c66272fa3dde3728.jpg",
                Description = "Paneer Sabji+Mix Veg Sabji+3 Butter Roti/4 Butter Tawa Roti+Dal+Rice+Gulab Jamun [2 Pieces]+Buttermilk [200 ml]",
                Price = "185",
                Restaurant_Name = "The Orchid"
            };

            FoodItem Item2 = new FoodItem()
            {
                Food_Name = "Paneer Butter Masala",
                Imageurl = "https://b.zmtcdn.com/data/dish_photos/853/6cc43be4f0587f8bcae3e9a8be09b853.jpg",
                Description = "",
                Price = "249",
                Restaurant_Name = "The Orchid"
            };

            FoodItem Item3 = new FoodItem()
            {
                Food_Name = "Paneer Lababdar",
                Imageurl = "https://b.zmtcdn.com/data/dish_photos/782/53e2cf1d041ad8e05f662162e7b98782.jpg",
                Description = "Roasted finger cutting cottage cheese with makhana red gravy and Indian masala flavors.",
                Price = "269",
                Restaurant_Name = "The Orchid",
            };

            FoodItem Item4 = new FoodItem()
            {
                Food_Name = "Dal Khichdi",
                Imageurl = "https://b.zmtcdn.com/data/dish_photos/172/644ca6cf7d38521a8dbdac9a79720172.jpg",
                Description = "",
                Price = "189",
                Restaurant_Name = "The Orchid"
            };

            FoodItem Item5 = new FoodItem()
            {
                Food_Name = "Orchid Special Paneer Combo",
                Imageurl = "https://b.zmtcdn.com/data/dish_photos/cff/8e846f16ea53f0969cba664d2a6d4cff.jpg",
                Description = "Karari Corn Tikki [2 Pieces]+Paneer Masala [200 grams]+3 Tandoori Butter Roti/4 Tawa Butter Roti+Buttermilk [200 ml]+Salad+Papad+Pickle+Mukhwas",
                Price = "239",
                Restaurant_Name = "The Orchid"
            };

            FoodItem Item6 = new FoodItem()
            {
                Food_Name = "Veg Tawa Pulao",
                Imageurl = "https://b.zmtcdn.com/data/dish_photos/a31/a44a722d8f37a92b8444ccbb51fe7a31.jpg",
                Description = "A vegetable pulao prepared with Indian spices.",
                Price = "189",
                Restaurant_Name = "The Orchid"
            };

            FoodItem Item7 = new FoodItem()
            {
                Food_Name = "Cheese Butter Masala",
                Imageurl = "https://b.zmtcdn.com/data/dish_photos/87a/9cc05ad81a60c067d0fde1b55b86e87a.jpg",
                Description = "",
                Price = "299",
                Restaurant_Name = "The Orchid"
            };

            FoodItem Item8 = new FoodItem()
            {
                Food_Name = "Paneer Kadai",
                Imageurl = "https://b.zmtcdn.com/data/dish_photos/9fa/f0c348d1a77133c13f888a29e3d099fa.jpg",
                Description = "",
                Price = "249",
                Restaurant_Name = "The Orchid"
            };


            FoodItem Item9 = new FoodItem()
            {
                Food_Name = "Jungli Vada Pav",
                Imageurl = "https://b.zmtcdn.com/data/dish_photos/b05/2f4bde3cf1dc260a1757c0e04fda7b05.jpg",
                Description = "",
                Price = "35",
                Restaurant_Name = "Jugaadi Adda",
            };

            FoodItem Item10 = new FoodItem()
            {
                Food_Name = "Vip Samosa Pav",
                Imageurl = "https://b.zmtcdn.com/data/dish_photos/b46/e5cb4e831adb0de258fc4ac5436efb46.jpg",
                Description = "A proper blend of orange cheese with tandoori base and a hint of bbq with veggie like iceberg, Tomato capsicumand onion.",
                Price = "45",
                Restaurant_Name = "Jugaadi Adda",
            };

            FoodItem Item11 = new FoodItem()
            {
                Food_Name = "Cheese Vada Pav",
                Imageurl = "https://b.zmtcdn.com/data/dish_photos/79f/e41ea692a2db4419913907a2fa8d579f.jpg",
                Description = "Vada pav with liquid orange cheese and liquid with cheese.",
                Price = "30",
                Restaurant_Name = "Jugaadi Adda",
            };

            FoodItem Item12 = new FoodItem()
            {
                Food_Name = "Jain GODFATHER Vada Pav",
                Imageurl = "https://b.zmtcdn.com/data/dish_photos/6e0/68ea30979d123988b41b539e1228d6e0.jpg",
                Description = "The Cheesiest vada pav but spicy at same time. combination of chilli, tandoori & orange cheese",
                Price = "50",
                Restaurant_Name = "Jugaadi Adda",
            };

            FoodItem Item13 = new FoodItem()
            {
                Food_Name = "Jantar Mantar Bhajji",
                Imageurl = "https://b.zmtcdn.com/data/dish_photos/000/8ed43d32b0779fcafc883a2d8d3be000.jpg",
                Description = "Iceberg,tomato,capsicum,onion topped with 3 secret sauses and orange cheese with bbq.",
                Price = "40",
                Restaurant_Name = "Jugaadi Adda",
            };

            FoodItem Item14 = new FoodItem()
            {
                Food_Name = "Jain INDI-ITALIA Vada Pav",
                Imageurl = "https://b.zmtcdn.com/data/dish_photos/24a/ae6c0b0826bb8d6d54c8314273bfb24a.jpg",
                Description = "Pizza flavoured vada pav (tomato, capsicum) blended liquid cheese with hint of jalapenos",
                Price = "55",
                Restaurant_Name = "Jugaadi Adda",
            };

            FoodItem Item15 = new FoodItem()
            {
                Food_Name = "Peri Peri Vada Pav",
                Imageurl = "https://b.zmtcdn.com/data/dish_photos/65e/76957c14132fbf7806ae31c79c40165e.jpg",
                Description = "Flavourful peri peri blend in vada pav",
                Price = "35",
                Restaurant_Name = "Jugaadi Adda",
            };

            FoodItem Item16 = new FoodItem()
            {
                Food_Name = "Mayo Vada Pav",
                Imageurl = "https://b.zmtcdn.com/data/dish_photos/605/e0ca4a36e56260e06747d25406fe6605.jpg",
                Description = "Vada pav with Mayo blend",
                Price = "35",
                Restaurant_Name = "Jugaadi Adda",
            };


            FoodItem Item17 = new FoodItem()
            {
                Food_Name = "Naked Nutella Waffle",
                Imageurl = "https://b.zmtcdn.com/data/dish_photos/3f3/abeeaa6c5c4ca8f8f4f3402d511273f3.jpg",
                Description = "Classic crispy waffle, premium European chocolate hazelnut spread.",
                Price = "172.40",
                Restaurant_Name = "The Belgian Waffle Co."
            };

            FoodItem Item18 = new FoodItem()
            {
                Food_Name = "Triple Chocolate Waffle",
                Imageurl = "https://b.zmtcdn.com/data/dish_photos/659/295afd575281e4ce63d7578c806ad659.jpg",
                Description = "Signature dark chocolate batter, 3 layers of white, milk and dark melted Belgian chocolate.",
                Price = "165.70",
                Restaurant_Name = "The Belgian Waffle Co."
            };

            FoodItem Item19 = new FoodItem()
            {
                Food_Name = "Red Velvet Waffle",
                Imageurl = "https://b.zmtcdn.com/data/dish_photos/c8b/0b182a9bf320d755a88c350ad1280c8b.jpg",
                Description = "Original red velvet waffle and Philadelphia style cream cheese and melted Belgian white chocolate. A true original! [Hygiene Packaging]",
                Price = "155.20",
                Restaurant_Name = "The Belgian Waffle Co."
            };

            FoodItem Item20 = new FoodItem()
            {
                Food_Name = "Chocolate Mini Waffle Combo Pack Of 4",
                Imageurl = "https://b.zmtcdn.com/data/dish_photos/24b/435d902535f1bffda1a95756849ae24b.jpg",
                Description = "Try a carefully curated assortment of our bestseller chocolate favorites. Includes our naked nutella, Belgian chocolate, chocolate overload and dark & white fantasy mini waffles all in one combo pack.",
                Price = "309.52",
                Restaurant_Name = "The Belgian Waffle Co."
            };

            FoodItem Item21 = new FoodItem()
            {
                Food_Name = "Dark Chocolate Overload Waffle",
                Imageurl = "https://b.zmtcdn.com/data/dish_photos/ce0/d718286ce4d0051aabfed72f30c4dce0.jpg",
                Description = "Signature dark chocolate batter and melted Belgian dark chocolate. Double the chocolate! [Hygiene Packaging]",
                Price = "155.20",
                Restaurant_Name = "The Belgian Waffle Co."
            };

            FoodItem Item22 = new FoodItem()
            {
                Food_Name = "Belgian Dark Chocolate Waffle",
                Imageurl = "https://b.zmtcdn.com/data/dish_photos/35c/e0eea82e211730cad39f29b30ee1035c.jpg",
                Description = "Classic crispy waffle and melted Belgian dark chocolate. Darker simplicity! [Hygiene Packaging]",
                Price = "145.70",
                Restaurant_Name = "The Belgian Waffle Co."
            };

            FoodItem Item23 = new FoodItem()
            {
                Food_Name = "Happiness in Mini Version + 1 Free Delight",
                Imageurl = "https://b.zmtcdn.com/data/dish_photos/4df/5b86ece3e773b119db978b7f5a9bc4df.jpg",
                Description = "Buy Chocolate Mini Waffle Combo pack of 6 and select 1 FREE waffle or pancake from our top picks",
                Price = "456",
                Restaurant_Name = "The Belgian Waffle Co."
            };

            FoodItem Item24 = new FoodItem()
            {
                Food_Name = "Death by Chocolate Cake [Single Layer]",
                Imageurl = "https://b.zmtcdn.com/data/dish_photos/d75/722ed70e2ae4c865a04f649e7ab84d75.jpg",
                Description = "Signature dark chocolate double layer waffle cake layered inside and out with creamy white, milk and dark melted Belgian chocolate.",
                Price = "330.50",
                Restaurant_Name = "The Belgian Waffle Co."
            };


            FoodItem Item25 = new FoodItem()
            {
                Food_Name = "Lucknowi Chicken Dum Biryani (Boneless)",
                Imageurl = "https://b.zmtcdn.com/data/dish_photos/5fe/56fd867a9a75c60e349afcd4ae27c5fe.jpg",
                Description = "[100% Safely Cooked Chicken] [Served with Raita] Indian spices marinate juicy boneless chicken with a warm blanket of slow cooked, dum style fragrant basmati rice.",
                Price = "279",
                Restaurant_Name = "The Biryani Life"
            };

            FoodItem Item26 = new FoodItem()
            {
                Food_Name = "Lucknowi Mutton Dum Biryani (Boneless)",
                Imageurl = "https://b.zmtcdn.com/data/dish_photos/7a4/a703dbb93ae82b59350e9dd2ea3677a4.jpg",
                Description = "[Served with Raita] If biryanis had a king, Mutton Biryani would always rule! spiced boneless mutton married with fragrant basmati , slow cooked to create what biryani dreams are made of.",
                Price = "359",
                Restaurant_Name = "The Biryani Life"
            };

            FoodItem Item27 = new FoodItem()
            {
                Food_Name = "Hyderabadi Dum Chicken Biryani (Boneless)",
                Imageurl = "https://b.zmtcdn.com/data/dish_photos/b2b/f4f0318162393149cb8e038b8ce9bb2b.jpg",
                Description = "[Serves 1][Served with raita]Just like Charminar’s secret tunnels, this biryani is made with a secret Hyderabadi spice mix that soaks the succulent chicken that is layered with mint infused basmati rice",
                Price = "279",
                Restaurant_Name = "The Biryani Life"
            };

            FoodItem Item28 = new FoodItem()
            {
                Food_Name = "Lucknowi Veg Dum Biryani",
                Imageurl = "https://b.zmtcdn.com/data/dish_photos/1a0/658817c5c1ab77af587c03861c74b1a0.jpg",
                Description = "[Served with Raita] No argument here, this is a Biryani and not a pulao. Dum cooked long-grain basmati rice layered in with all the vegetables that mom said are good for you",
                Price = "229",
                Restaurant_Name = "The Biryani Life"
            };

            FoodItem Item29 = new FoodItem()
            {
                Food_Name = "Hyderabadi chicken Dum biryani combo meal",
                Imageurl = "https://b.zmtcdn.com/data/dish_photos/6db/05070e6393b1ca8f025166ed6a7686db.jpg",
                Description = "[Serves 1][Served with raita]Enjoy a delicious Hyderabadi Chicken Biryani along with a Starter and a Beverage of Your Choice at great discounts.",
                Price = "339",
                Restaurant_Name = "The Biryani Life"
            };

            FoodItem Item30 = new FoodItem()
            {
                Food_Name = "Hyderabadi Dum Paneer Biryani",
                Imageurl = "https://b.zmtcdn.com/data/dish_photos/825/46cac7a570568708c7d7b25228999825.jpg",
                Description = "(Contains Onion and garlic) [Serves 1][Served with raita]Just the way you like it, long grain basmati rice is cooked with paneer that is marinated with a spice mix straight from the Bazaars of Hyderabad. Every bite leaves you wanting more",
                Price = "259",
                Restaurant_Name = "The Biryani Life"
            };

            FoodItem Item31 = new FoodItem()
            {
                Food_Name = "Chicken Dum Biryani Feast (Hyderabadi)",
                Imageurl = "https://b.zmtcdn.com/data/dish_photos/7f7/048b118249d4770af724d31215f257f7.jpg",
                Description = "[Serves 2][100% Safely Cooked Chicken] [Served with Raita] Indian spices marinate juicy boneless chicken with a warm blanket of slow cooked, dum style hyderabadi basmati rice served along with double serving of chicken kofta, 2 mint chaas and 4 gulab jamuns",
                Price = "689",
                Restaurant_Name = "The Biryani Life"
            };

            FoodItem Item32 = new FoodItem()
            {
                Food_Name = "Potato Wedges and Thums up (by Faasos)",
                Imageurl = "https://b.zmtcdn.com/data/dish_photos/b75/7876fe0d37c4ee47618f30d463b10b75.jpg",
                Description = "Potato Wedges (Medium) and Thums up (250ml)",
                Price = "119",
                Restaurant_Name = "The Biryani Life"
            };


            SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
            conn.CreateTable<FoodItem>();
            conn.Table<FoodItem>().Delete(u => u.Restaurant_Name == "The Orchid");
            conn.Table<FoodItem>().Delete(u => u.Restaurant_Name == "Jugaadi Adda");
            conn.Table<FoodItem>().Delete(u => u.Restaurant_Name == "The Belgian Waffle Co.");
            conn.Table<FoodItem>().Delete(u => u.Restaurant_Name == "The Biryani Life");
            int rows1 = conn.Insert(Item1);
            int rows2 = conn.Insert(Item2);
            int rows3 = conn.Insert(Item3);
            int rows4 = conn.Insert(Item4);
            int rows5 = conn.Insert(Item5);
            int rows6 = conn.Insert(Item6);
            int rows7 = conn.Insert(Item7);
            int rows8 = conn.Insert(Item8);
            int rows9 = conn.Insert(Item9);
            int rows10 = conn.Insert(Item10);
            int rows11 = conn.Insert(Item11);
            int rows12 = conn.Insert(Item12);
            int rows13 = conn.Insert(Item13);   
            int rows14 = conn.Insert(Item14);
            int rows15 = conn.Insert(Item15);
            int rows16 = conn.Insert(Item16);
            int rows17 = conn.Insert(Item17);
            int rows18 = conn.Insert(Item18);
            int rows19 = conn.Insert(Item19);
            int rows20 = conn.Insert(Item20);
            int rows21 = conn.Insert(Item21);
            int rows22 = conn.Insert(Item22);
            int rows23 = conn.Insert(Item23);
            int rows24 = conn.Insert(Item24);
            int rows25 = conn.Insert(Item25);
            int rows26 = conn.Insert(Item26);
            int rows27 = conn.Insert(Item27);
            int rows28 = conn.Insert(Item28);
            int rows29 = conn.Insert(Item29);
            int rows30 = conn.Insert(Item30);
            int rows31 = conn.Insert(Item31);
            int rows32 = conn.Insert(Item32);


            var ans = conn.Table<FoodItem>().ToList();
            conn.Close();
        }
    }
}