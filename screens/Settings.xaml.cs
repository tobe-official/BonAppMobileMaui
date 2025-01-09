using BonAppMobileMaui.models;
using BonAppMobileMaui.Singletons;
using Microsoft.Maui.Controls;

namespace BonAppMobileMaui.screens
{
    public partial class Settings : ContentPage
    {
        public Settings()
        {
            InitializeComponent();
            BindingContext = new SettingsViewModel();
        }

        private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            Console.WriteLine($"Slider value changed to: {e.NewValue}");
        }

        private async void OnLogoutTapped(object sender, EventArgs e)
        {
            var emptyUser = new User("", "", "", new List<int>(), new List<string>(), new List<string>(),
                new List<int>(), new List<int>());
            // Reset the active user
            ActiveUserSingleton.Instance.SetUser(emptyUser);

            // Navigate to the login screen
            await Navigation.PushAsync(new LoginPage());
        }
        
    }

    public class SettingsViewModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public bool EnableNotifications { get; set; }

        // RadioButton Bindings
        public bool IsVegetarian { get; set; }
        public bool IsNonVegetarian { get; set; }
        public bool IsVegan { get; set; }

        // Slider Binding
        public double MealPrepTime { get; set; }

        // Picker Binding
        public string FavoriteCuisine { get; set; }

        // DatePicker Binding
        public DateTime Birthdate { get; set; }

        // TimePicker Binding
        public TimeSpan PreferredMealTime { get; set; }

        // Command to save settings
        public Command SaveCommand { get; set; }

        public SettingsViewModel()
        {
            // Initialize the data using ActiveUserSingleton
            var activeUser = ActiveUserSingleton.Instance.ActiveUser;

            Username = activeUser.Username;
            Email = activeUser.Email;
            EnableNotifications = false; // Default value or fetch from user preferences
            IsVegetarian = false; // Default or fetch from user data
            IsNonVegetarian = true; // Default or fetch from user data
            IsVegan = false; // Default or fetch from user data
            MealPrepTime = 30; // Default value
            FavoriteCuisine = "Italian"; // Default or fetch from user data
            Birthdate = DateTime.Now; // Default or fetch from user data
            PreferredMealTime = new TimeSpan(12, 0, 0); // Default value

            SaveCommand = new Command(SaveSettings);
        }

        private void SaveSettings()
        {
            // Implement logic to save the settings
            Console.WriteLine("Settings saved!");

            // Optionally update ActiveUserSingleton with new settings
            ActiveUserSingleton.Instance.ActiveUser.Username = Username;
            ActiveUserSingleton.Instance.ActiveUser.Email = Email;
        }
    }
}