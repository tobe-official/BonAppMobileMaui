using BonAppMobileMaui.enums;

namespace BonAppMobileMaui.models;

public class FoodModel(
    int id,
    string name,
    string imagePath,
    Time time,
    string ingredients,
    string steps,
    string username,
    List<Filters> filters)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
    public string ImagePath { get; set; } = imagePath;
    public Time Time { get; set; } = time;
    public string Ingredients { get; set; } = ingredients;
    public string Steps { get; set; } = steps;
    public string Username { get; set; } = username;
    public List<Filters> Filters { get; set; } = filters;
}