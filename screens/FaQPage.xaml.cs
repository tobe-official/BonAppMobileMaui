using Microsoft.Maui.Controls;

namespace BonAppMobileMaui.screens;

public partial class FaQPage : ContentPage
{
    public FaQPage()
    {
        InitializeComponent();

        InitializeFaqBehavior();
    }

    private void InitializeFaqBehavior()
    {
        Answer1Button.Clicked += (_, __) => { Answer1.IsVisible = !Answer1.IsVisible; };
        Answer2Button.Clicked += (_, __) => { Answer2.IsVisible = !Answer2.IsVisible; };
        Answer3Button.Clicked += (_, __) => { Answer3.IsVisible = !Answer3.IsVisible; };
        Answer4Button.Clicked += (_, __) => { Answer4.IsVisible = !Answer4.IsVisible; };
        Answer5Button.Clicked += (_, __) => { Answer5.IsVisible = !Answer5.IsVisible; };
    }
}