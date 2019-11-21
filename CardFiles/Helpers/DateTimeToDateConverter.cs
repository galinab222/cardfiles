
using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;


namespace CardFiles.Classes
{
    public class DateTimeToDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((DateTime)value).ToString("dd.MM.yyyy");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            { return DateTime.Parse(value.ToString());}
            catch
            {
                MessageBox.Show("Неверная дата"); 
                return null; }
             
        }

    }
}