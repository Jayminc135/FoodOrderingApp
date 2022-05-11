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
    }
}