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
    public partial class FoodItems : ContentPage
    {
        public ObservableCollection<FoodItem> FoodItemcollection;
        public FoodItems(string RestaurantName)
        {
            InitializeComponent();
            FoodItemcollection = new ObservableCollection<FoodItem>();
            Restaurant_name.Text = RestaurantName;
            GetFoodItems(RestaurantName);

            var assembly = typeof(FoodItems);
            backarrow.Source = ImageSource.FromResource("FoodOrderingApp.Assets.Images.backarrow.png", assembly);
        }

        private void GetFoodItems(string name)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<FoodItem>();
                var fooditem = conn.Table<FoodItem>().Where(u => u.Restaurant_Name == name).ToList();
                foreach (var item in fooditem)
                {
                    FoodItemcollection.Add(item);
                }
                CvFoods.ItemsSource = FoodItemcollection;
            }
        }
        private void TapBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void CvFoods_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentSelection = e.CurrentSelection.FirstOrDefault() as FoodItem;
            if (currentSelection == null) return;
            Navigation.PushModalAsync(new FoodItemDetails(currentSelection.Food_Name));
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}