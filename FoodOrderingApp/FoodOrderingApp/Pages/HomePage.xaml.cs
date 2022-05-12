using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodOrderingApp.Model;
using SQLite;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodOrderingApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public ObservableCollection<Restaurant> RestaurantsCollection;
        public ObservableCollection<PopularItem> PopularItemsCollection;
        public HomePage()
        {
            InitializeComponent();
            RestaurantsCollection = new ObservableCollection<Restaurant>();
            PopularItemsCollection = new ObservableCollection<PopularItem>();
            GetPopularItems();
            GetRestaurants();
            AddPopularItems();
            AddRestaurants();
            AddFoodItems();
            Username.Text = Preferences.Get("Name", string.Empty);

            var assembly = typeof(HomePage);
            banner.Source = ImageSource.FromResource("FoodOrderingApp.Assets.Images.banner.png", assembly);
            menu.Source = ImageSource.FromResource("FoodOrderingApp.Assets.Images.menu.png", assembly);
            cart.Source = ImageSource.FromResource("FoodOrderingApp.Assets.Images.cart.png", assembly);
            AppIcon.Source = ImageSource.FromResource("FoodOrderingApp.Assets.Images.AppIcon.png", assembly);
            Appicon.Source = ImageSource.FromResource("FoodOrderingApp.Assets.Images.AppIcon.png", assembly);
            order.Source = ImageSource.FromResource("FoodOrderingApp.Assets.Images.order.png", assembly);
            shopping_cart.Source = ImageSource.FromResource("FoodOrderingApp.Assets.Images.cart2.png", assembly);
            profile.Source = ImageSource.FromResource("FoodOrderingApp.Assets.Images.profile.png", assembly);
            logout.Source = ImageSource.FromResource("FoodOrderingApp.Assets.Images.logout.png", assembly);
        }

        private void GetPopularItems()
        {
            SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
            conn.CreateTable<PopularItem>();
            var PopularItems = conn.Table<PopularItem>().ToList();
            conn.Close();

            foreach(var item in PopularItems)
            {
                PopularItemsCollection.Add(item);
            }
            CvPopularItems.ItemsSource = PopularItemsCollection;
        }

        private void GetRestaurants()
        {
            SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
            conn.CreateTable<Restaurant>();
            var Restaurants = conn.Table<Restaurant>().ToList();
            conn.Close();

            foreach (var item in Restaurants)
            {
                RestaurantsCollection.Add(item);
            }
            CvRestaurants.ItemsSource = RestaurantsCollection;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
            conn.CreateTable<Cart>();
            var row = conn.Table<Cart>().Count();
            conn.Close();

            LblTotalItems.Text = row.ToString();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            CloseHamBurgerMenu();
        }
        private void CvRestaurants_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentSelection = e.CurrentSelection.FirstOrDefault() as Restaurant;
            if (currentSelection == null)   return;
            Navigation.PushModalAsync(new FoodItems(currentSelection.Restaurant_Name));
            ((CollectionView)sender).SelectedItem = null;
        }

        private async void ImgMenu_Tapped(object sender, EventArgs e)
        {
            GridOverlay.IsVisible = true;
            await SlMenu.TranslateTo(0, 0, 400, Easing.Linear);
        }

        private void TapCartIcon_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MyCart());
        }

        private void TapOrders_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MyOrders());
        }

        private void TapCart_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MyCart());
        }

        private void TapProfile_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MyProfile());
        }

        private void TapLogout_Tapped(object sender, EventArgs e)
        {
            Preferences.Set("Email", String.Empty);
            Preferences.Set("Password", String.Empty);
            //Preferences.Set("loggedin", 0);
            SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
            conn.CreateTable<Logindb>();
            var res = conn.DeleteAll<Logindb>();
            conn.Close();

            Application.Current.MainPage = new NavigationPage(new Signup());
        }

        private void TapCloseMenu_Tapped(object sender, EventArgs e)
        {
            CloseHamBurgerMenu();
        }

        private async void CloseHamBurgerMenu()
        {
            await SlMenu.TranslateTo(-250, 0, 400, Easing.Linear);
            GridOverlay.IsVisible = false;
        }

        private void AddPopularItems()
        {
            SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
            conn.CreateTable<PopularItem>();
            var rows = conn.Table<PopularItem>().ToList();

            if (rows.Count > 0)
            {
                return;
            }
            else
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

                int rows1 = conn.Insert(Item1);
                int rows2 = conn.Insert(Item2);
                int rows3 = conn.Insert(Item3);
                int rows4 = conn.Insert(Item4);
                int rows5 = conn.Insert(Item5);
                int rows6 = conn.Insert(Item6);
                int rows7 = conn.Insert(Item7);
                int rows8 = conn.Insert(Item8);
            }
            conn.Close();
        }

        private void AddRestaurants()
        {
            SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
            conn.CreateTable<Restaurant>();
            var ans = conn.Table<Restaurant>().ToList();

            if (ans.Count > 0)
            {
                return;
            }
            else
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

                int rows1 = conn.Insert(Item1);
                int rows2 = conn.Insert(Item2);
                int rows3 = conn.Insert(Item3);
                int rows4 = conn.Insert(Item4);
                int rows5 = conn.Insert(Item5);
                int rows6 = conn.Insert(Item6);
                int rows7 = conn.Insert(Item7);
                int rows8 = conn.Insert(Item8);
            }
            conn.Close();
        }

        private void AddFoodItems()
        {
            SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
            conn.CreateTable<FoodItem>();
            var ans = conn.Table<FoodItem>().ToList();

            if (ans.Count > 0)
            {
                return;
            }
            else
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

                FoodItem Item33 = new FoodItem()
                {
                    Food_Name = "Aloo tikki burger",
                    Imageurl = "https://b.zmtcdn.com/data/dish_photos/931/0b53a0c341aa499fcb882988e09a6931.jpg",
                    Description = "Mouthwatering combination of shredded potatoes, chilli flakes and herbs [aloo patty], with fresh tomato & onion",
                    Price = "59",
                    Restaurant_Name = "BurgerDi",
                };

                FoodItem Item34 = new FoodItem()
                {
                    Food_Name = "Paneer Masala Subwich",
                    Imageurl = "https://b.zmtcdn.com/data/dish_photos/b13/15018968daa8a23b3b813519c5cd6b13.jpg",
                    Description = "",
                    Price = "159",
                    Restaurant_Name = "BurgerDi",
                };

                FoodItem Item35 = new FoodItem()
                {
                    Food_Name = "French Fries",
                    Imageurl = "https://b.zmtcdn.com/data/dish_photos/7b0/2767228b95d884c476545ae299a577b0.jpg",
                    Description = "",
                    Price = "70",
                    Restaurant_Name = "BurgerDi",
                };

                FoodItem Item36 = new FoodItem()
                {
                    Food_Name = "Spicy Schezwan Wrap",
                    Imageurl = "https://b.zmtcdn.com/data/dish_photos/5de/d50bc6fb13064b9a304542c484d5b5de.jpg",
                    Description = "",
                    Price = "125",
                    Restaurant_Name = "BurgerDi",
                };

                FoodItem Item37 = new FoodItem()
                {
                    Food_Name = "Cheese Chilli Corn Burger",
                    Imageurl = "https://b.zmtcdn.com/data/dish_photos/e9c/b62c96a3bb8a6202da056347164e0e9c.jpg",
                    Description = "A crispy veg jumbo patty with grated cheese, corn, green chilli covered in creamy liquid cheese.",
                    Price = "109",
                    Restaurant_Name = "BurgerDi",
                };

                FoodItem Item38 = new FoodItem()
                {
                    Food_Name = "Veggie Fantasy Burger Meal [Medium]",
                    Imageurl = "https://b.zmtcdn.com/data/dish_photos/869/270c465b4d3a6882a09c55b734312869.jpg",
                    Description = "Veggie Fantasy Burger+French Fries [Medium]+Soft Beverage [Medium]",
                    Price = "169",
                    Restaurant_Name = "BurgerDi",
                };

                FoodItem Item39 = new FoodItem()
                {
                    Food_Name = "Oreo Milkshake",
                    Imageurl = "https://b.zmtcdn.com/data/dish_photos/96b/2e6a8b6ff0795ed42d51e0d961f9496b.jpg",
                    Description = "",
                    Price = "129",
                    Restaurant_Name = "BurgerDi",
                };

                FoodItem Item40 = new FoodItem()
                {
                    Food_Name = "Blue Sky Mojito",
                    Imageurl = "https://b.zmtcdn.com/data/dish_photos/ee2/cbb351722633ac1a64c655187c425ee2.jpg",
                    Description = "[Non Alcoholic]",
                    Price = "89",
                    Restaurant_Name = "BurgerDi",
                };

                FoodItem Item41 = new FoodItem()
                {
                    Food_Name = "Fix Lunch/Dinner",
                    Imageurl = "https://b.zmtcdn.com/data/dish_photos/86d/8077067ec2a8ccb0eaf6891af7ab786d.jpg",
                    Description = "Paneer Sabji+Veg Sabji+4 Butter Chapati+Dal Fried+Jeera Rice+Salad +1 Sweet+Butter Milk+ Pickle",
                    Price = "240",
                    Restaurant_Name = "Bhagyoday Restaurant",
                };

                FoodItem Item42 = new FoodItem()
                {
                    Food_Name = "Veg Hot and Sour Soup",
                    Imageurl = "https://b.zmtcdn.com/data/dish_photos/0bb/06ed8d362bdb63f68a8bfda6945450bb.jpg",
                    Description = "",
                    Price = "100",
                    Restaurant_Name = "Bhagyoday Restaurant",
                };

                FoodItem Item43 = new FoodItem()
                {
                    Food_Name = "Cream of Tomato Soup",
                    Imageurl = "https://b.zmtcdn.com/data/dish_photos/a50/30e76c0847c0a63adf40663ca1586a50.jpg",
                    Description = "",
                    Price = "90",
                    Restaurant_Name = "Bhagyoday Restaurant",
                };

                FoodItem Item44 = new FoodItem()
                {
                    Food_Name = "Paneer Tikka",
                    Imageurl = "https://b.zmtcdn.com/data/dish_photos/fea/7bdb044d51d641152e901e23b94fffea.jpg",
                    Description = "",
                    Price = "280",
                    Restaurant_Name = "Bhagyoday Restaurant",
                };

                FoodItem Item45 = new FoodItem()
                {
                    Food_Name = "Kaju Masala (Brown)",
                    Imageurl = "https://b.zmtcdn.com/data/dish_photos/e55/c7325701671062f984573a291d9a1e55.jpg",
                    Description = "",
                    Price = "235",
                    Restaurant_Name = "Bhagyoday Restaurant",
                };

                FoodItem Item46 = new FoodItem()
                {
                    Food_Name = "Butter Chapati",
                    Imageurl = "https://www.comesum.com/wp-content/uploads/2020/01/butter-tawa-roti.jpg",
                    Description = "",
                    Price = "28",
                    Restaurant_Name = "Bhagyoday Restaurant",
                };

                FoodItem Item47 = new FoodItem()
                {
                    Food_Name = "Dal Tadka",
                    Imageurl = "https://b.zmtcdn.com/data/dish_photos/369/7d2a07500ef5068652239ecf5543b369.jpg",
                    Description = "",
                    Price = "150",
                    Restaurant_Name = "Bhagyoday Restaurant",
                };

                FoodItem Item48 = new FoodItem()
                {
                    Food_Name = "Jeera Rice",
                    Imageurl = "https://b.zmtcdn.com/data/dish_photos/589/991e70efb0ebd7e19de157f72730d589.jpg",
                    Description = "",
                    Price = "125",
                    Restaurant_Name = "Bhagyoday Restaurant",
                };

                FoodItem Item49 = new FoodItem()
                {
                    Food_Name = "Non Veg Pack Lunch/Dinner",
                    Imageurl = "https://b.zmtcdn.com/data/dish_photos/b4a/4c59cee6ed24b9f5ec7b3cef84013b4a.jpg",
                    Description = "Chicken Tikka+Fish Tikka+Mutton Seekh Kabab+Chicken Biryani+Raita+ Mint Chutney+Masala Peanuts+Gulab Jamun",
                    Price = "310",
                    Restaurant_Name = "Dheemi Aanch Restaurant",
                };

                FoodItem Item50 = new FoodItem()
                {
                    Food_Name = "Egg Bhurji",
                    Imageurl = "https://b.zmtcdn.com/data/dish_photos/9f0/8ce4ef97b28fc2c530eef792ca84e9f0.jpg",
                    Description = "",
                    Price = "100",
                    Restaurant_Name = "Dheemi Aanch Restaurant",
                };

                FoodItem Item51 = new FoodItem()
                {
                    Food_Name = "Tandoori Chicken",
                    Imageurl = "https://b.zmtcdn.com/data/dish_photos/0fb/315714ddbe673eeaaf0c405b5cdaa0fb.jpg",
                    Description = "",
                    Price = "210",
                    Restaurant_Name = "Dheemi Aanch Restaurant",
                };

                FoodItem Item52 = new FoodItem()
                {
                    Food_Name = "Egg Curry",
                    Imageurl = "https://b.zmtcdn.com/data/dish_photos/6d3/0344ae1a9c7c9f92d3e762edb102c6d3.jpg",
                    Description = "",
                    Price = "150",
                    Restaurant_Name = "Dheemi Aanch Restaurant",
                };

                FoodItem Item53 = new FoodItem()
                {
                    Food_Name = "Boneless Butter Chicken",
                    Imageurl = "https://b.zmtcdn.com/data/dish_photos/3b3/52e0b052c2baa556bd74b1f7046e13b3.jpg",
                    Description = "",
                    Price = "360",
                    Restaurant_Name = "Dheemi Aanch Restaurant",
                };

                FoodItem Item54 = new FoodItem()
                {
                    Food_Name = "Fish Curry",
                    Imageurl = "https://b.zmtcdn.com/data/dish_photos/5ba/7fe2fd95f1b45207758520024d94b5ba.jpg",
                    Description = "Homemade style",
                    Price = "330",
                    Restaurant_Name = "Dheemi Aanch Restaurant",
                };

                FoodItem Item55 = new FoodItem()
                {
                    Food_Name = "Chicken Dum Biryani",
                    Imageurl = "https://b.zmtcdn.com/data/dish_photos/86f/ab9c3c57fdd86c72090fd7634616c86f.jpg",
                    Description = "Made with whole spices, cooked on low flame.",
                    Price = "250",
                    Restaurant_Name = "Dheemi Aanch Restaurant",
                };

                FoodItem Item56 = new FoodItem()
                {
                    Food_Name = "Omelette Masala",
                    Imageurl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRdopgK4mswxo-3OOvgBT9wztfILByLcRP8Pw&usqp=CAU",
                    Description = "",
                    Price = "80",
                    Restaurant_Name = "Dheemi Aanch Restaurant",
                };

                FoodItem Item57 = new FoodItem()
                {
                    Food_Name = "Vadapav Oil",
                    Imageurl = "https://b.zmtcdn.com/data/dish_photos/4e2/a0b8676d25ef023ae50d604b07c0a4e2.jpg",
                    Description = "Oil vadapav",
                    Price = "45",
                    Restaurant_Name = "Jay Bahavani vadapav",
                };

                FoodItem Item58 = new FoodItem()
                {
                    Food_Name = "Jain Vadapav Butter",
                    Imageurl = "https://b.zmtcdn.com/data/dish_photos/03b/9007b1b48c3a4c13525b51b2f434303b.jpg",
                    Description = "",
                    Price = "70",
                    Restaurant_Name = "Jay Bahavani vadapav",
                };

                FoodItem Item59 = new FoodItem()
                {
                    Food_Name = "Club Grilled Sandwich [3 Layer]",
                    Imageurl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQj1eXpSCRIU5ZcbhUGZM1BPavEWjQE2N6bvg&usqp=CAU",
                    Description = "Grilled sandwich with 3 layer of bread and full of vegetable and mayonnaise.",
                    Price = "150",
                    Restaurant_Name = "Jay Bahavani vadapav",
                };

                FoodItem Item60 = new FoodItem()
                {
                    Food_Name = "Vegetable Hot Dog Regular",
                    Imageurl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQHfqTQAPzchL5XTNr5701e3WvL_wWiovCM4w&usqp=CAU",
                    Description = "",
                    Price = "100",
                    Restaurant_Name = "Jay Bahavani vadapav",
                };

                FoodItem Item61 = new FoodItem()
                {
                    Food_Name = "Dabeli Butter",
                    Imageurl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcST3iAV7rKzqJghlH9KMqhnrL6NZjWIfe3_Zw&usqp=CAU",
                    Description = "",
                    Price = "55",
                    Restaurant_Name = "Jay Bahavani vadapav",
                };

                FoodItem Item62 = new FoodItem()
                {
                    Food_Name = "Butter Pav Bhaji",
                    Imageurl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSsRMA-TLX6zr5BB4bMXftkJpuebfIHXMoGDw&usqp=CAU",
                    Description = "One plate pavbhaji with 2 butter pav",
                    Price = "110",
                    Restaurant_Name = "Jay Bahavani vadapav",
                };

                FoodItem Item63 = new FoodItem()
                {
                    Food_Name = "Jam Musk Bun",
                    Imageurl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcToooiXWCws9iFQx8B0qbCzPH-psCjNYm2lRw&usqp=CAU",
                    Description = "",
                    Price = "60",
                    Restaurant_Name = "Jay Bahavani vadapav",
                };

                FoodItem Item64 = new FoodItem()
                {
                    Food_Name = "Sevpuri Cheese",
                    Imageurl = "https://b.zmtcdn.com/data/dish_photos/4d3/4402bc8419d5b00f9b3d6430cdeb64d3.jpg",
                    Description = "",
                    Price = "80",
                    Restaurant_Name = "Jay Bahavani vadapav",
                };

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
                int rows33 = conn.Insert(Item33);
                int rows34 = conn.Insert(Item34);
                int rows35 = conn.Insert(Item35);
                int rows36 = conn.Insert(Item36);
                int rows37 = conn.Insert(Item37);
                int rows38 = conn.Insert(Item38);
                int rows39 = conn.Insert(Item39);
                int rows40 = conn.Insert(Item40);
                int rows41 = conn.Insert(Item41);
                int rows42 = conn.Insert(Item42);
                int rows43 = conn.Insert(Item43);
                int rows44 = conn.Insert(Item44);
                int rows45 = conn.Insert(Item45);
                int rows46 = conn.Insert(Item46);
                int rows47 = conn.Insert(Item47);
                int rows48 = conn.Insert(Item48);
                int rows49 = conn.Insert(Item49);
                int rows50 = conn.Insert(Item50);
                int rows51 = conn.Insert(Item51);
                int rows52 = conn.Insert(Item52);
                int rows53 = conn.Insert(Item53);
                int rows54 = conn.Insert(Item54);
                int rows55 = conn.Insert(Item55);
                int rows56 = conn.Insert(Item56);
                int rows57 = conn.Insert(Item57);
                int rows58 = conn.Insert(Item58);
                int rows59 = conn.Insert(Item59);
                int rows60 = conn.Insert(Item60);
                int rows61 = conn.Insert(Item61);
                int rows62 = conn.Insert(Item62);
                int rows63 = conn.Insert(Item63);
                int rows64 = conn.Insert(Item64);
            }
            conn.Close();
        }
    }
}