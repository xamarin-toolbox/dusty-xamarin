using Dusty.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Dusty.Views.Converters
{
    public class VintageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            var cellar = (CellarDto)value;
            var year = cellar.Vintage != null
                ? cellar.Vintage
                : cellar.DateProduced?.Year;

            if (year == null)
                return null;

            return "‘" + year.ToString().Substring(2);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
