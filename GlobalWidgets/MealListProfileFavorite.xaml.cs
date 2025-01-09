using BonAppMobileMaui.models;
using Microsoft.Maui.Controls;

namespace BonAppMobileMaui.GlobalWidgets
{
    public partial class MealListProfileFavorite
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