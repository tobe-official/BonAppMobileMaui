using BonAppMobileMaui.enums;
using BonAppMobileMaui.models;
using BonAppMobileMaui.Singletons;

namespace BonAppMobileMaui.screens
{
    public partial class AddPost : ContentPage
    {
        private FileResult _selectedImage;
        private readonly List<Filters> _selectedFilters = new();

        public AddPost()
        {
            InitializeComponent();
            PopulateTimePicker();

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += OnImageTapped;
            Placeholder.GestureRecognizers.Add(tapGestureRecognizer);
        }

        private void PopulateTimePicker()
        {
            foreach (var time in Enum.GetValues(typeof(Time)))
            {
                TimePicker.Items.Add(time.ToString());
            }
        }

        private async void OnImageTapped(object sender, EventArgs e)
        {
            _selectedImage = await PickImageFromGalleryAsync();
            if (_selectedImage != null)
            {
                Placeholder.IsVisible = false;
                PickedImage.IsVisible = true;
                PickedImage.Source = ImageSource.FromFile(_selectedImage.FullPath);
                ValidateForm();
            }
        }

        private async Task<FileResult> PickImageFromGalleryAsync()
        {
            try
            {
                var mediaResult = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
                {
                    Title = "Wählen Sie ein Foto"
                });

                if (mediaResult != null)
                {
                    return mediaResult;
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private async void OnSelectFiltersClicked(object sender, EventArgs e)
        {
            var tempSelectedFilters = new List<Filters>(_selectedFilters);

            var result = await DisplayActionSheet("Select Filters", "Cancel", null,
                Enum.GetNames(typeof(Filters)));

            if (!string.IsNullOrEmpty(result) && result != "Cancel")
            {
                var filter = (Filters)Enum.Parse(typeof(Filters), result);
                if (!_selectedFilters.Contains(filter))
                {
                    _selectedFilters.Add(filter);
                }
            }

            ValidateForm();
        }

        private void ValidateForm()
        {
            PostMealButton.IsEnabled = !string.IsNullOrWhiteSpace(MealNameEntry.Text) &&
                                       TimePicker.SelectedIndex >= 0 &&
                                       _selectedImage != null &&
                                       _selectedFilters.Any() &&
                                       !string.IsNullOrWhiteSpace(IngredientsEditor.Text) &&
                                       !string.IsNullOrWhiteSpace(RecipeEditor.Text);

            if (PostMealButton.IsEnabled)
            {
                PostMealButton.BackgroundColor = Color.FromHex("#123456");
            }
            else
            {
                PostMealButton.BackgroundColor = Color.FromHex("#F3F3E0"); 
            }
        }

        private async void OnPostMealClicked(object sender, EventArgs e)
        {
            try
            {
                var newMeal = new FoodModel(
                    id: (int)(DateTime.Now.Ticks % int.MaxValue), 
                    name: MealNameEntry.Text, 
                    imagePath: _selectedImage.FullPath, 
                    time: (Time)Enum.Parse(typeof(Time), TimePicker.SelectedItem.ToString()), 
                    ingredients: IngredientsEditor.Text, 
                    steps: RecipeEditor.Text, 
                    username: ActiveUserSingleton.Instance.ActiveUser.Username,
                    filters: _selectedFilters  
                );

                FoodListSingleton.Instance.FoodList.Add(newMeal);

                await DisplayAlert("Success", "Meal posted!", "OK");

                ResetForm();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "An error occurred while posting the meal: " + ex.Message, "OK");
            }
        }

        private void ResetForm()
        {
            MealNameEntry.Text = string.Empty;
            IngredientsEditor.Text = string.Empty;
            RecipeEditor.Text = string.Empty;

            TimePicker.SelectedIndex = -1;

            _selectedFilters.Clear();

            _selectedImage = null;
            Placeholder.IsVisible = true;
            PickedImage.IsVisible = false;
        }
    }
}