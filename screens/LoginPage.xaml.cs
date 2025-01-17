using BonAppMobileMaui.data;
using BonAppMobileMaui.models;
using BonAppMobileMaui.Singletons;

namespace BonAppMobileMaui.screens
{
    public partial class LoginPage : ContentPage
    {

        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Error", "Please fill in both fields.", "OK");
                return;
            }

            try
            {
                User? activeUser = UserData.Users.FirstOrDefault(user => user.Username == username && user.Password == password);
                if (activeUser != null)
                {
                    ActiveUserSingleton.Instance.SetUser(activeUser);

                    FoodListSingleton.Instance.SetFoodList(FoodData.Foods);

                    await Shell.Current.GoToAsync("///HomePage");
                }
                else
                {
                    await DisplayAlert("Error", "Invalid credentials.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "An error occurred during login.", "OK");
            }
        }
    }
}