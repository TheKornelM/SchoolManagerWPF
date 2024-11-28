using System.Collections;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SchoolManagerWPF.Converters;


public class CollectionCountToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is ICollection collection) // Check for any collection type
        {
            return collection.Count > 0 ? Visibility.Visible : Visibility.Collapsed;
        }

        return Visibility.Collapsed; // Safeguard for null or non-collection types
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
