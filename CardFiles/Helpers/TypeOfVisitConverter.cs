
using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;


namespace CardFiles.Classes
{
    public class TypeofVisitConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string s = "";
            if (int.Parse(value.ToString())==0)
                { s = "Первичный"; }
            if (int.Parse(value.ToString()) == 1)
            { s = "Повторный"; }

            return s;


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