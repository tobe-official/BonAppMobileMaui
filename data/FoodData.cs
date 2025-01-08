using BonAppMobileMaui.enums;
using BonAppMobileMaui.models;

namespace BonAppMobileMaui.data;

public static class FoodData
{
    public static List<FoodModel> Foods => new List<FoodModel>
    {
        new FoodModel(
            1, 
            "Lasagne", 
            "resource://BonAppMobileMaui.Resources.Images.lasagna.jpg", 
            Time.Slow, 
            "Pasta, Tomato Sauce, Cheese", 
            "Cook pasta, Layer ingredients, Bake", 
            "DummyUser", 
            new List<Filters> { Filters.Italian, Filters.Baked }
        ),
        new FoodModel(
            2, 
            "Spaghetti Bolognese", 
            "resource://BonAppMobileMaui.Resources.Images.spaghetti_bolognese.avif", 
            Time.HalfSlow, 
            "Spaghetti, Ground Meat, Tomato Sauce", 
            "Boil pasta, Cook sauce, Serve", 
            "user", 
            new List<Filters> { Filters.Italian, Filters.Healthy }
        ),
        new FoodModel(
            3, 
            "Pizza Margherita", 
            "resource://BonAppMobileMaui.Resources.Images.pizza_margheritta.jpg", 
            Time.HalfSlow, 
            "Pizza Dough, Tomato Sauce, Cheese", 
            "Prepare dough, Add toppings, Bake", 
            "user2", 
            new List<Filters> { Filters.Italian, Filters.Baked }
        )
    };
}