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
    public partial class FoodItemDetails : ContentPage
    {
        public FoodItemDetails(string ItemName)
        {
            InitializeComponent();
            GetItemDetails(ItemName);

            var assembly = typeof(HomePage);
            plus.Source = ImageSource.FromResource("FoodOrderingApp.Assets.Images.plus.png", assembly);
            minus.Source = ImageSource.FromResource("FoodOrderingApp.Assets.Images.minus.png", assembly);
            close.Source = ImageSource.FromResource("FoodOrderingApp.Assets.Images.close.png", assembly);
        }

        private void GetItemDetails(string name)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<FoodItem>();
                var product = conn.Table<FoodItem>().Where(u => u.Food_Name == name).ToList();
                LblName.Text = product.FirstOrDefault().Food_Name;
                LblDetail.Text = product.FirstOrDefault().Description;
                ImgProduct.Source = product.FirstOrDefault().Imageurl;
                LblPrice.Text = product.FirstOrDefault().Price;
                LblTotalPrice.Text = LblPrice.Text;
            }
        }

        private void TapBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void TapDecrement_Tapped(object sender, EventArgs e)
        {
            var i = Convert.ToDouble(LblQty.Text);
            i--;
            if (i < 1)
            {
                return;
            }
            LblQty.Text = i.ToString();
            LblTotalPrice.Text = (Convert.ToDouble(LblQty.Text) * Convert.ToDouble(LblPrice.Text)).ToString();
        }

        private void TapIncrement_Tapped(object sender, EventArgs e)
        {
            var i = Convert.ToDouble(LblQty.Text);
            i++;
            LblQty.Text = i.ToString();
            LblTotalPrice.Text = (Convert.ToDouble(LblQty.Text) * Convert.ToDouble(LblPrice.Text)).ToString();
        }

        private async void BtnAddToCart_Clicked(object sender, EventArgs e)
        {
            var addToCart = new Cart();
            addToCart.Quantity = LblQty.Text;
            addToCart.Price = LblPrice.Text;
            addToCart.TotalAmount = LblTotalPrice.Text;
            addToCart.Food_Name = LblName.Text;

            SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
            conn.CreateTable<Cart>();
            var row = conn.Insert(addToCart);
            var item = conn.Table<Cart>().ToList();
            conn.Close();
            if (row > 0)
            {
                await DisplayAlert("", "Your items has been added to the cart", "Alright");
            }
            else
            {
                await DisplayAlert("Oops", "Something went wrong", "Cancel");
            }
        }
    }
}