using BonAppMobileMaui.models;
using Microsoft.Maui.Controls;

namespace BonAppMobileMaui.Views
{
    public partial class MealListProfileFavorite : ContentView
    {
        public MealListProfileFavorite()
        {
            InitializeComponent();
        }

        public void SetFoodList(List<FoodModel> foodList)
        {
            var reversedList = foodList.AsEnumerable().Reverse().ToList();
            MealCollectionView.ItemsSource = reversedList;
        }
    }
}