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
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            Preferences.Set("Email", EntEmail.Text);
            Preferences.Set("Password", EntPassword.Text);

            if (string.IsNullOrEmpty(EntEmail.Text) || string.IsNullOrEmpty(EntPassword.Text))
            {
                await DisplayAlert("Failure", "Enter valid data", "Ok");
            }
            else
            {
                SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
                conn.CreateTable<Signupdb>();
                var myquery = conn.Table<Signupdb>().Where(u => u.UserEmail.Equals(EntEmail.Text) && u.UserPassword.Equals(EntPassword.Text)).Any();

                if(myquery)
                {
                    Application.Current.MainPage = new NavigationPage(new HomePage());
                }
                else
                {
                    await DisplayAlert("Error", "Email ID and Password doesn't match", "Ok");
                }
            }
        }

        private void TapBackArrow_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

    }
}