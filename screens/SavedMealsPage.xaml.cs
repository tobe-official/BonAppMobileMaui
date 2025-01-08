using BonAppMobileMaui.models;
using BonAppMobileMaui.Singletons;
using Microsoft.Maui.Controls;
using System.Linq;

namespace BonAppMobileMaui.screens;

public partial class SavedMealsPage : ContentPage
{
    private List<FoodModel> _mealsFavored;

    public SavedMealsPage()
    {
        InitializeComponent();

        // Lade aktive User- und Mahlzeitdaten
        var activeUser = ActiveUserSingleton.Instance.ActiveUser;
        List<FoodModel>? meals = FoodListSingleton.Instance.FoodList;
        _mealsFavored = meals?.Where(food => activeUser?.FavoredMeals.Contains(food.Id) ?? false).ToList() ?? new List<FoodModel>();

        // Initialisiere UI
        InitUI();

        // Setze den Event-Listener für Änderungen der gespeicherten Mahlzeiten
        MessagingCenter.Subscribe<HomePage>(this, "SavedMealsUpdated", (sender) =>
        {
            // Aktualisiere die Liste der favorisierten Mahlzeiten
            _mealsFavored = meals?.Where(food => activeUser?.FavoredMeals.Contains(food.Id) ?? false).ToList() ?? new List<FoodModel>();
            InitUI(); // UI neu laden
        });
    }

    private void InitUI()
    {
        // Zeige entweder die leere Nachricht oder die gespeicherten Mahlzeiten
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