using BonAppMobileMaui.models;
using BonAppMobileMaui.Singletons;

namespace BonAppMobileMaui.screens;

public partial class SavedMealsPage : ContentPage
{
    private List<FoodModel> _mealsFavored;

    public SavedMealsPage()
    {
        InitializeComponent();

        MessagingCenter.Subscribe<HomePage>(this, "SavedMealsUpdated", (sender) =>
        {
            RefreshData();
        });
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        RefreshData();
    }

    private void RefreshData()
    {
        var activeUser = ActiveUserSingleton.Instance.ActiveUser;
        List<FoodModel>? meals = FoodListSingleton.Instance.FoodList;
        _mealsFavored = meals.Where(food => activeUser?.FavoredMeals.Contains(food.Id) ?? false).ToList() ?? new List<FoodModel>();

        InitUI();
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