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
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            var assembly = typeof(HomePage);

            banner.Source = ImageSource.FromResource("FoodOrderingApp.Assets.Images.banner.png", assembly);
            menu.Source = ImageSource.FromResource("FoodOrderingApp.Assets.Images.menu.png", assembly);
            cart.Source = ImageSource.FromResource("FoodOrderingApp.Assets.Images.cart.png", assembly);
            kfc.Source = ImageSource.FromResource("FoodOrderingApp.Assets.Images.kfc.png", assembly);
            Kfc.Source = ImageSource.FromResource("FoodOrderingApp.Assets.Images.kfc.png", assembly);
            order.Source = ImageSource.FromResource("FoodOrderingApp.Assets.Images.order.png", assembly);
            shopping_cart.Source = ImageSource.FromResource("FoodOrderingApp.Assets.Images.shopping_cart.png", assembly);
            contact.Source = ImageSource.FromResource("FoodOrderingApp.Assets.Images.contact.png", assembly);
            logout.Source = ImageSource.FromResource("FoodOrderingApp.Assets.Images.logout.png", assembly);
        }

        private void CvProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CvCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ImgMenu_Tapped(object sender, EventArgs e)
        {

        }

        private void TapCartIcon_Tapped(object sender, EventArgs e)
        {

        }

        private void TapOrders_Tapped(object sender, EventArgs e)
        {

        }

        private void TapCart_Tapped(object sender, EventArgs e)
        {

        }

        private void TapContact_Tapped(object sender, EventArgs e)
        {

        }

        private void TapLogout_Tapped(object sender, EventArgs e)
        {

        }

        private void TapCloseMenu_Tapped(object sender, EventArgs e)
        {

        }
    }
}