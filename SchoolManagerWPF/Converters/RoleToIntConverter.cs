using SchoolManagerModel.Entities;
using System.Windows.Data;

namespace SchoolManagerWPF.Converters
{
    class RoleToIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (int)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (Role)value;
        }
    }
}