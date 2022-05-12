using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FoodOrderingApp.Pages;
using SQLite;
using FoodOrderingApp.Model;

namespace FoodOrderingApp
{
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;
        public App()
        {
            InitializeComponent();

            SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
            conn.CreateTable<Logindb>();
            int res = conn.Table<Logindb>().Count();
            conn.Close();

            if (res > 0)
            {
                MainPage = new NavigationPage(new HomePage());
            }
            else
            {
                MainPage = new NavigationPage(new Signup());
            }
        }

        public App(string databaseLocation)
        {
            InitializeComponent();

            SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
            conn.CreateTable<Logindb>();
            int res = conn.Table<Logindb>().Count();
            conn.Close();

            if (res > 0)
            {
                MainPage = new NavigationPage(new HomePage());
            }
            else
            {
                MainPage = new NavigationPage(new Signup());
            }

            DatabaseLocation = databaseLocation;
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
