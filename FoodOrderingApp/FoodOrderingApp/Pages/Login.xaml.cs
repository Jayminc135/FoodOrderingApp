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
            var assembly = typeof(Login);
            backarrow.Source = ImageSource.FromResource("FoodOrderingApp.Assets.Images.backarrow.png", assembly);
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EntEmail.Text) || string.IsNullOrEmpty(EntPassword.Text))
            {
                await DisplayAlert("Failure", "Enter valid data", "Ok");
            }
            else
            {
                Preferences.Set("Email", EntEmail.Text);
                Preferences.Set("Password", EntPassword.Text);

                SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
                conn.CreateTable<Signupdb>();
                var myname = conn.Table<Signupdb>().Where(u => u.UserEmail.Equals(EntEmail.Text) && u.UserPassword.Equals(EntPassword.Text)).ToList();
                var myquery = conn.Table<Signupdb>().Where(u => u.UserEmail.Equals(EntEmail.Text) && u.UserPassword.Equals(EntPassword.Text)).Any();
                conn.Close();

                if (myquery)
                {
                    Preferences.Set("Name", myname.FirstOrDefault().UserName);
                    //Preferences.Set("loggedin", 1);

                    SQLiteConnection conn2 = new SQLiteConnection(App.DatabaseLocation);
                    conn2.CreateTable<Logindb>();
                    var login = new Logindb
                    {
                        UserLoggedin = 1
                    };
                    int res = conn2.Insert(login);
                    conn2.Close();

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