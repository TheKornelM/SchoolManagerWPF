using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SchoolManagerWPF.Converters
{
    public class StringToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string str && !string.IsNullOrWhiteSpace(str))
            {
                return Visibility.Visible;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // ConvertBack is not implemented because it’s not needed for one-way binding
            throw new NotSupportedException("StringToVisibilityConverter does not support ConvertBack.");
        }
    }
}
