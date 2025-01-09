using BonAppMobileMaui.models;
using BonAppMobileMaui.Singletons;
namespace BonAppMobileMaui.screens;

public partial class SavedMealsPage : ContentPage
{
    private List<FoodModel> _mealsFavored;

    public SavedMealsPage()
    {
        InitializeComponent();

        var activeUser = ActiveUserSingleton.Instance.ActiveUser;
        List<FoodModel>? meals = FoodListSingleton.Instance.FoodList;
        _mealsFavored = meals?.Where(food => activeUser?.FavoredMeals.Contains(food.Id) ?? false).ToList() ?? new List<FoodModel>();

        InitUI();

        MessagingCenter.Subscribe<HomePage>(this, "SavedMealsUpdated", (sender) =>
        {
            _mealsFavored = meals?.Where(food => activeUser?.FavoredMeals.Contains(food.Id) ?? false).ToList() ?? new List<FoodModel>();
            InitUI(); // UI neu laden
        });
    }

    private void InitUI()
    {
        if (_mealsFavored.Count == 0)
        {
            NoMealsLabel.IsVisible = true;
            MealList.IsVisible = false;
        }
        else
        {
            NoMealsLabel.IsVisible = false;
            MealList.IsVisible = true;
            MealList.SetFoodList(_mealsFavored);
        }
    }
}