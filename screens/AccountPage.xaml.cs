using BonAppMobileMaui.models;
using BonAppMobileMaui.Singletons;

namespace BonAppMobileMaui.screens
{
    public partial class AccountPage : ContentPage
    {
        private User _activeUser = ActiveUserSingleton.Instance.ActiveUser;
        public AccountPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadUserData();
        }

        private void LoadUserData()
        {
            var user = ActiveUserSingleton.Instance.ActiveUser;
            
            UsernameLabel.Text = user.Username;
            MealsCountLabel.Text = $"{GetMealsMadeCount()} Meals";
            FollowersCountLabel.Text = $"{user.FollowersUsernames.Count} Followers";
            FollowingCountLabel.Text = $"{user.FollowingUsernames.Count} Following";

            var mealsMade = GetMealsMade();

            if (mealsMade.Count == 0)
            {
                NoMealsLabel.Text = "You have not posted a meal yet...";
                NoMealsLabel.IsVisible = true;
                MealsList.IsVisible = false;
            }
            else
            {
                NoMealsLabel.IsVisible = false;
                MealsList.IsVisible = true;
                MealsList.SetFoodList(mealsMade);
            }
        }

        private List<FoodModel> GetMealsMade()
        {
            return FoodListSingleton.Instance.FoodList.Where((food) => _activeUser.Username == food.Username).ToList();
        }

        private int GetMealsMadeCount()
        {
            return GetMealsMade().Count;
        }

        private async void OnSettingsTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Settings());
        }
    }
}