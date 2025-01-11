using System;
using Microsoft.Maui.Controls;

namespace BonAppMobileMaui.screens;

public partial class FaQPage : ContentPage
{
    public FaQPage()
    {
        InitializeComponent();

        // Toggle visibility for each FAQ answer when the respective button is clicked
        //InitializeFaqBehavior();
    }

    /*private void InitializeFaqBehavior()
    {
        // Retrieve FAQ buttons and labels by their names
        var answer1Button = FindByName<Button>("Answer1Button");
        var answer1Label = FindByName<Label>("Answer1");

        var answer2Button = FindByName<Button>("Answer2Button");
        var answer2Label = FindByName<Label>("Answer2");

        var answer3Button = FindByName<Button>("Answer3Button");
        var answer3Label = FindByName<Label>("Answer3");

        var answer4Button = FindByName<Button>("Answer4Button");
        var answer4Label = FindByName<Label>("Answer4");

        var answer5Button = FindByName<Button>("Answer5Button");
        var answer5Label = FindByName<Label>("Answer5");

        // Attach Clicked event handlers to toggle visibility of each answer
        answer1Button.Clicked += (_, __) => { answer1Label.IsVisible = !answer1Label.IsVisible; };
        answer2Button.Clicked += (_, __) => { answer2Label.IsVisible = !answer2Label.IsVisible; };
        answer3Button.Clicked += (_, __) => { answer3Label.IsVisible = !answer3Label.IsVisible; };
        answer4Button.Clicked += (_, __) => { answer4Label.IsVisible = !answer4Label.IsVisible; };
        answer5Button.Clicked += (_, __) => { answer5Label.IsVisible = !answer5Label.IsVisible; };
    }*/
}