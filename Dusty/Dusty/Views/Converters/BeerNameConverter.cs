using Dusty.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Dusty.Views.Converters
{
    public class BeerNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || !(value is CellarDto))
                return null;

            var cellar = (CellarDto)value;

            return TryIncrementalReplace(cellar.Beer.Name, cellar.Beer.BreweryName);
        }

        private string TryIncrementalReplace(string name, string breweryName)
        {
            var words = breweryName.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                var wordSet = String.Join(" ", words.Take(words.Length - i));

                if (name.StartsWith(wordSet, StringComparison.OrdinalIgnoreCase))
                    name = name.Substring(wordSet.Length, name.Length - wordSet.Length).Trim();

                if (name.StartsWith("/"))
                    name = name.Substring(1, name.Length - 1).Trim();
            }

            return name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
