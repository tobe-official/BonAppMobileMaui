using BonAppMobileMaui.enums;
using BonAppMobileMaui.models;
using BonAppMobileMaui.Singletons;

namespace BonAppMobileMaui.screens
{
    public partial class AddPost
    {
        private FileResult? _selectedImage;

        public AddPost()
        {
            InitializeComponent();
            PopulateTimePicker();
            PopulateFilterPicker();

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
        
        private void PopulateFilterPicker()
        {
            foreach (var filter in Enum.GetValues(typeof(Filters)))
            {
                FilterPicker.Items.Add(filter.ToString());
            }
        }

        private async Task<FileResult?> PickImageFromGalleryAsync()
        {
            try
            {
                var mediaResult = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
                {
                    Title = "Choose an image",
                });

                return mediaResult; 
            }
            catch (Exception ex)
            {
                return null; 
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

                ImageFrame.WidthRequest = 300;  
                ImageFrame.HeightRequest = 200; 

                PickedImage.WidthRequest = 300;  
                PickedImage.HeightRequest = 200;
            }
        }

        private bool ValidateForm()
        {
            bool isFormValid = !string.IsNullOrWhiteSpace(MealNameEntry.Text) &&
                               FilterPicker.SelectedIndex >= 0 &&
                               TimePicker.SelectedIndex >= 0 &&
                               _selectedImage != null &&
                               !string.IsNullOrWhiteSpace(IngredientsEditor.Text) &&
                               !string.IsNullOrWhiteSpace(RecipeEditor.Text);
            return isFormValid;
        }

        private async void OnPostMealClicked(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                try
                {
                    var newMeal = new FoodModel(
                        id: (int)(DateTime.Now.Ticks % int.MaxValue), 
                        name: MealNameEntry.Text, 
                        imagePath: _selectedImage!.FullPath, 
                        time: (Time)Enum.Parse(typeof(Time), TimePicker.SelectedItem.ToString()!), 
                        ingredients: IngredientsEditor.Text, 
                        steps: RecipeEditor.Text, 
                        username: ActiveUserSingleton.Instance.ActiveUser.Username,
                        filters: (Filters)Enum.Parse(typeof(Filters), FilterPicker.SelectedItem.ToString()!),
                        isResourceImage: false
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
            else
            {
                await DisplayAlert("Fill all the inputs", "Please fill all the input fields completely and check if the image is selected.", "OK");
            }
        }

        private void ResetForm()
        {
            MealNameEntry.Text = string.Empty;
            IngredientsEditor.Text = string.Empty;
            RecipeEditor.Text = string.Empty;

            TimePicker.SelectedIndex = -1;

            FilterPicker.SelectedIndex = -1;

            _selectedImage = null;
            Placeholder.IsVisible = true;
            PickedImage.IsVisible = false;
        }
    }
}