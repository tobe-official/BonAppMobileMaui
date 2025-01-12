using BonAppMobileMaui.data;
using BonAppMobileMaui.models;
using BonAppMobileMaui.Singletons;

namespace BonAppMobileMaui.screens;

public partial class Settings : ContentPage
{
    private User _activeUser = ActiveUserSingleton.Instance.ActiveUser;

    public Settings()
    {
        InitializeComponent();
        LoadUserData();
    }

    private void LoadUserData()
    {
        UsernameEntry.Text = _activeUser.Username;
        EmailEntry.Text = _activeUser.Email;
        NotificationsSwitcher.IsToggled = _activeUser.NotificationEnabled;

        VegetarianRadio.IsChecked = _activeUser.IsVegetarian;
        NonVegetarianRadio.IsChecked = _activeUser.IsMeatEater;
        VeganRadio.IsChecked = _activeUser.IsVegan;

        BirthdatePicker.Date = _activeUser.DateOfBirth;
        MealTimePicker.Time = _activeUser.PreferredMealTime;
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        string username = UsernameEntry.Text?.Trim() ?? string.Empty;
        string email = EmailEntry.Text?.Trim() ?? string.Empty;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email))
        {
            await DisplayAlert("Error", "Username and email cannot be empty.", "OK");
            return;
        }

        if (!email.Contains("@"))
        {
            await DisplayAlert("Error", "Invalid email address.", "OK");
            return;
        }
        
        if (UserData.Users.Any(u => u.Username == username && u.Username != _activeUser.Username))
        {
            await DisplayAlert("Error", "Username already exists. Please choose another one.", "OK");
            return;
        }

        if (UserData.Users.Any(u => u.Email == email && u.Email != _activeUser.Email))
        {
            await DisplayAlert("Error", "Email is already registered. Please choose another one.", "OK");
            return;
        }

        _activeUser.Username = username;
        _activeUser.Email = email;
        _activeUser.NotificationEnabled = NotificationsSwitcher.IsToggled;
        _activeUser.IsVegetarian = VegetarianRadio.IsChecked;
        _activeUser.IsMeatEater = NonVegetarianRadio.IsChecked;
        _activeUser.IsVegan = VeganRadio.IsChecked;
        _activeUser.DateOfBirth = BirthdatePicker.Date;
        _activeUser.PreferredMealTime = MealTimePicker.Time;

        ActiveUserSingleton.Instance.SetUser(_activeUser);

        await DisplayAlert("Success", "Settings have been saved.", "OK");
    }

    private async void OnFaQClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FaQPage());
    }

    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        ActiveUserSingleton.Instance.SetUser(new User(
            username: "",
            email: "",
            password: "",
            favoredMeals: new List<int>(),
            followingUsernames: new List<string>(),
            followersUsernames: new List<string>(),
            likedMeals: new List<int>(),
            swipedMeals: new List<int>(),
            preferredMealTime: new TimeSpan(0, 0, 0),
            isVegan: false,
            isVegetarian: false,
            isMeatEater: false,
            dateOfBirth: DateTime.MinValue,
            notificationEnabled: false
        ));

        Application.Current!.MainPage = new AppShell();
        await Shell.Current.GoToAsync("//LoginPage");
    }
}