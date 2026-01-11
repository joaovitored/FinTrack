using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace Fintrack.Assets.Converter
{
    public class BoolToPasswordCharConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isVisible)
            {
                return isVisible ? '\0' : '●'; // Exibe nada se visível ou o caractere '●' se não visível
            }
            return '●'; // Valor default caso algo dê errado
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}