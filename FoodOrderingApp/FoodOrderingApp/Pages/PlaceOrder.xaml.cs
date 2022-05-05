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
    public partial class PlaceOrder : ContentPage
    {
  
        private double _totalPrice;
        public PlaceOrder(double totalPrice)
        {
            InitializeComponent();
            _totalPrice = totalPrice;
        }


        private void BtnPlaceOrder_Clicked(object sender, EventArgs e)
        {
            
        }

        
    }
}