using BonAppMobileMaui.models;
using Microsoft.Maui.Controls;
using System.Diagnostics;

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
            foreach (var food in reversedList)
            {
                var imageSource = GetImageSource(food); 
                Console.WriteLine($"Image source for {food.Name}: {imageSource}");
            }
        }

        public static ImageSource GetImageSource(FoodModel food)
        {
            var imageSource = food.IsResourceImage
                ? ImageSource.FromResource(food.ImagePath)
                : ImageSource.FromFile(food.ImagePath);

            return imageSource;
        }
    }
}