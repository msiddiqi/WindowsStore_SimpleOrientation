namespace SimpleOrientationEx.Converters
{
    using System;
    using Windows.UI.Xaml.Data;

    public class AppOrientationStateEnumConverter : IValueConverter
    {   public object Convert(object value, System.Type targetType, object parameter, string language)
        {
            return value.ToString();
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
