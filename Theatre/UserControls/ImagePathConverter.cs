using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Theatre.UserControls
{
    public class ImagePathConverter : IValueConverter
    {
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return LoadCover(value);

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }


        private BitmapImage LoadCover(object value)
        {
            string path = value.ToString().Replace("\\", "/");
            path = path.Replace("\"", "");
            BitmapImage bitmap = new BitmapImage(new Uri(path, UriKind.Absolute));

            return bitmap;
        }
    }
}
