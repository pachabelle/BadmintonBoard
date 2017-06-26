using System;
using System.Globalization;
using Xamarin.Forms;

namespace BadmintonBoard.Player
{
    public class GradeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var gradeAsInt = (int)value;
            return (PlayerGrade) gradeAsInt;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
