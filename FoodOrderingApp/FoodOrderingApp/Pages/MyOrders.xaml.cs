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
    public partial class MyOrders : ContentPage
    {
        public ObservableCollection<OrderHistory> OrdersCollection;
        public MyOrders()
        {
            InitializeComponent();
            OrdersCollection = new ObservableCollection<OrderHistory>();
            GetOrderItems();

            var assembly = typeof(MyOrders);
            backarrow.Source = ImageSource.FromResource("FoodOrderingApp.Assets.Images.backarrow.png", assembly);
        }
        private void GetOrderItems()
        {
            SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
            conn.CreateTable<OrderHistory>();
            var orders = conn.Table<OrderHistory>().ToList();
            conn.Close();
            foreach (var order in orders)
            {
                OrdersCollection.Add(order);
            }
            LvOrders.ItemsSource = OrdersCollection;
        }
        private void TapBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}