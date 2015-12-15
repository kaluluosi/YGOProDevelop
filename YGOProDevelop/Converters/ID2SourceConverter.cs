using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace YGOProDevelop.Converters {
    public class ID2SourceConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            string imgPath = @"pics\" + value.ToString() + ".jpg";
            string fullPath = Path.GetFullPath(imgPath);

            if (File.Exists(fullPath)) {
                return fullPath;
            }
            else {
                return @"Resources\0000.png";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return null;
        }
    }
}
