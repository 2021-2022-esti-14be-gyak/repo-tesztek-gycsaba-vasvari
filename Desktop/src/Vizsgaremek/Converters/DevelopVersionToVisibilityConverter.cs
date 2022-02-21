using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Data;
using System.Configuration;
using System.Windows;

namespace Vizsgaremek.Converters
{
    class DevelopVersionToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Save
            // Properties.Settings.Default.keyName = value;
            // Properties.Settings.Default.Save();

            bool developVersion = Properties.Settings.Default.developVersion;

            if (developVersion == true)
                return Visibility.Visible;
            else
                return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
