using System.Windows.Input;
using BonAppMobileMaui.models;
using BonAppMobileMaui.Singletons;
using Microsoft.Maui.Controls.Shapes;

namespace BonAppMobileMaui.screens
{
    public partial class HomePage : ContentPage
    {
        private readonly User _activeUser = ActiveUserSingleton.Instance.ActiveUser!;
        private readonly List<FoodModel> _meals = FoodListSingleton.Instance.FoodList;
        private bool _isFoodCourt = true;
        private int _currentMealIndex = 0;

        public HomePage()
        {
            InitializeComponent();
            BindingContext = this;
            InitializeData();
        }

        public ICommand ToggleCommand => new Command(ToggleFoodCourt);

        public string CurrentSection => _isFoodCourt ? "Food Court" : "Following";

        private void InitializeData()
        {
            LoadMealCards();
        }

        private void ToggleFoodCourt()
        {
            _isFoodCourt = !_isFoodCourt;
            LoadMealCards();
        }

        private void LoadMealCards()
        {
            MealCardContainer.Children.Clear();

            var filteredFood = _isFoodCourt
                ? _meals.Where(food => food.Username != _activeUser.Username && !_activeUser.SwipedMeals.Contains(food.Id)).ToList()
                : _meals.Where(food => food.Username != _activeUser.Username && !_activeUser.SwipedMeals.Contains(food.Id) && _activeUser.FollowingUsernames.Contains(food.Username)).ToList();

            if (_currentMealIndex >= filteredFood.Count)
            {
                // No more meals to display
                var noMoreMealsLabel = new Label
                {
                    Text = "No more meals to show!",
                    FontSize = 24,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                };
                MealCardContainer.Children.Add(noMoreMealsLabel);
                return;
            }

            var nextMeal = filteredFood[_currentMealIndex];
            var mealCard = CreateMealCard(nextMeal);
            MealCardContainer.Children.Add(mealCard);
        }

        private SwipeView CreateMealCard(FoodModel food)
        {
            var mealCard = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Margin = new Thickness(10),
                Children =
                {
                    new Label 
                    { 
                        Text = $"By {food.Username}", 
                        FontSize = 16, 
                        HorizontalOptions = LayoutOptions.Center 
                    },
                    new Border
                    {
                        StrokeShape = new RoundRectangle()
                        {
                            CornerRadius = new CornerRadius(20)
                        },
                        WidthRequest = 350,
                        HeightRequest = 450,
                        Stroke = Colors.Transparent,
                        Content = new Image
                        {
                            Source = food.ImagePath,
                            Aspect = Aspect.AspectFill,
                            WidthRequest = 300,
                            HeightRequest = 400
                        }
                    },
                    new Label 
                    { 
                        Text = food.Name, 
                        FontSize = 20, 
                        FontAttributes = FontAttributes.Bold 
                    },
                    CreateIconRow(food)
                }
            };

            var swipeView = new SwipeView
            {
                Content = mealCard,
                LeftItems = new SwipeItems
                {
                    new SwipeItem
                    {
                        IconImageSource = "like_icon.png",
                        Command = new Command(() => OnSwipeMeal(food))
                    }
                },
                RightItems = new SwipeItems
                {
                    new SwipeItem
                    {
                        IconImageSource = "report_icon.png",
                        Command = new Command(() => OnSwipeMeal(food))
                    }
                }
            };

            swipeView.SwipeEnded += async (sender, args) =>
            {
                if (args.IsOpen)
                {
                    OnSwipeMeal(food);

                    await Task.Delay(500);
                    swipeView.Close();
                }
            };

            return swipeView;
        }

        private void OnSwipeMeal(FoodModel food)
        {
            _activeUser.SwipedMeals.Add(food.Id);
            _currentMealIndex++;
            LoadMealCards();
        }

        private StackLayout CreateIconRow(FoodModel food)
        {
            // Icon Row with Like, Save, Report
            return new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Margin = new Thickness(0, 5),
                Children =
                {
                    new Button { Text = "Like", Command = new Command(() => OnLikeButtonClicked(food)) },
                    new Button { Text = "Save", Command = new Command(() => OnSaveButtonClicked(food)) },
                    new Button { Text = "Report", Command = new Command(() => OnReportButtonClicked(food)) }
                }
            };
        }

        private void OnSaveButtonClicked(FoodModel food)
        {
            if (!_activeUser.FavoredMeals.Contains(food.Id))
            {
                _activeUser.FavoredMeals.Add(food.Id);
            }
            else
            {
                _activeUser.FavoredMeals.Remove(food.Id);
            }

            FoodListSingleton.Instance.SetFoodList(_meals); 
        }

        private void OnLikeButtonClicked(FoodModel food)
        {
            if (!_activeUser.LikedMeals.Contains(food.Id))
            {
                _activeUser.LikedMeals.Add(food.Id);
            }
            else
            {
                _activeUser.LikedMeals.Remove(food.Id);
            }
        }

        private void OnReportButtonClicked(FoodModel food)
        {
            DisplayAlert("Report", "Reported: " + food.Name, "OK");
        }
    }
}