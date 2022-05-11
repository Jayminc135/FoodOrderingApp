using FoodOrderingApp.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodOrderingApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyCart : ContentPage
    {
        public ObservableCollection<Cart> CartCollection;
        public MyCart()
        {
            InitializeComponent();
            CartCollection = new ObservableCollection<Cart>();
            GetCartItems();
            GetTotalPrice();

            var assembly = typeof(MyCart);
            backarrow.Source = ImageSource.FromResource("FoodOrderingApp.Assets.Images.backarrow.png", assembly);
        }

        private void GetCartItems()
        {
            SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
            conn.CreateTable<Cart>();
            var carts = conn.Table<Cart>().ToList();
            conn.Close();

            foreach (var item in carts)
            {
                CartCollection.Add(item);
            }
            LvShoppingCart.ItemsSource = CartCollection;
        }

        private void GetTotalPrice()
        {
            SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
            conn.CreateTable<Cart>();
            var item = conn.ExecuteScalar<Double> ("SELECT SUM(TotalAmount) FROM Cart WHERE TotalAmount > 0");
            conn.Close();

            LblTotalPrice.Text = item.ToString();
        }

        private void TapBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void BtnProceed_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Payment(Convert.ToDouble(LblTotalPrice.Text)));
        }

        private async void TapClearCart_Tapped(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
            conn.CreateTable<Cart>();
            var row = conn.DeleteAll<Cart>();
            conn.Close();

            if (row > 0)
            {
                await DisplayAlert("", "Your cart has been cleared", "Alright");
                LvShoppingCart.ItemsSource = null;
                LblTotalPrice.Text = "0";
            }
            else
            {
                await DisplayAlert("", "Something went wrong", "Cancel");
            }
        }
    }
}