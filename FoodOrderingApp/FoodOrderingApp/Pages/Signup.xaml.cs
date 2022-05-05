using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodOrderingApp.Model;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodOrderingApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Signup : ContentPage
    {
        public Signup()
        {
            InitializeComponent();
        }

        private async void BtnSignup_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EntName.Text) || string.IsNullOrWhiteSpace(EntEmail.Text) || string.IsNullOrWhiteSpace(EntPassword.Text) || string.IsNullOrWhiteSpace(EntConfirmPassword.Text))
            {
                await DisplayAlert("Failure", "Enter valid data", "Ok");
            }
            else if (!EntPassword.Text.Equals(EntConfirmPassword.Text))
            {
                await DisplayAlert("Password mismatch", "Please check your confirm password", "Ok");
            }
            else
            {
                Signupdb signupdb = new Signupdb()
                {
                    UserName = EntName.Text,
                    UserEmail = EntEmail.Text,
                    UserPassword = EntPassword.Text
                };

                SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
                conn.CreateTable<Signupdb>();
                int rows = conn.Insert(signupdb);
                var ans = conn.Table<Signupdb>().ToList();
                conn.Close();

                if (rows > 0)
                {
                    await DisplayAlert("Hi", "Your account has been created", "Alright");
                    await Navigation.PushModalAsync(new Login());
                }
                else
                {
                    await DisplayAlert("Oops", "Something went wrong", "Cancel");
                }
            }
        }

        private void BtnLogin_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Login());
        }
    }
}