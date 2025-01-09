using System.Globalization;
using BonAppMobileMaui.models;

namespace BonAppMobileMaui.imageConverter
{
    public class ImageSourceConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is not string imageSource || parameter is not FoodModel food)
            {
                return null;
            }

            return food.IsResourceImage
                ? ImageSource.FromResource(imageSource)
                : ImageSource.FromFile(imageSource);
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (parameter is null)
            {
                throw new ArgumentNullException(nameof(parameter));
            }
            throw new NotImplementedException();
        }
    }
}