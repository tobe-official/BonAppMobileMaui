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
            "lasagna.jpg", 
            Time.Slow, 
            "Pasta, Tomato Sauce, Cheese", 
            "Cook pasta, Layer ingredients, Bake", 
            "User1", 
            Filters.Italian,
            isResourceImage: true
        ),
        new FoodModel(
            2, 
            "Spaghetti Bolognese", 
            "spaghetti_bolognese.jpg", 
            Time.HalfSlow, 
            "Spaghetti, Ground Meat, Tomato Sauce", 
            "Boil pasta, Cook sauce, Serve", 
            "User1", 
            Filters.Healthy,
            isResourceImage: true   
            ),
        new FoodModel(
            3, 
            "Pizza Margherita", 
            "pizza_margherita.jpg", 
            Time.HalfSlow, 
            "Pizza Dough, Tomato Sauce, Cheese", 
            "Prepare dough, Add toppings, Bake", 
            "User1", 
            Filters.Baked,
            isResourceImage: true
        )
    };
}