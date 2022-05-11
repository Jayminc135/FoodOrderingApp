using FoodOrderingApp.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodOrderingApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Payment : ContentPage
    {
        private double _totalPrice;
        public Payment(double totalPrice)
        {
            InitializeComponent();
            _totalPrice = totalPrice;

            var assembly = typeof(Payment);
            backarrow.Source = ImageSource.FromResource("FoodOrderingApp.Assets.Images.backarrow.png", assembly);
        }

        private void TapBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private async void BtnPlaceOrder_Clicked(object sender, EventArgs e)
        {
            var order = new OrderHistory();
            order.FullName = EntName.Text;
            order.Phone = EntPhone.Text;
            order.Address = EntAddress.Text;
            order.OrderTotal = _totalPrice.ToString();
            order.CreatedDate = DateTime.Now;

            SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
            conn.CreateTable<OrderHistory>();
            var row = conn.Insert(order);
            var item = conn.Table<OrderHistory>().ToList();
            conn.Close();
            if (row > 0)
            {
                await DisplayAlert("", "Your Order Id is " + order.OrderId, "Alright");
                Application.Current.MainPage = new NavigationPage(new HomePage());
            }
            else
            {
                await DisplayAlert("Oops", "Something went wrong", "Cancel");
            }
        }
    }
}