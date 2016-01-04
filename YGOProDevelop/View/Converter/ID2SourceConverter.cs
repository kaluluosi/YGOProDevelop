using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using YGOProDevelop.CardEditor.Builder;
using YGOProDevelop.Model;

namespace YGOProDevelop.View.Converter {
    public class ID2SourceConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value == null) return null;

            string imgPath = Path.Combine(Properties.Settings.Default.picFolder,value + ".jpg"); ;
            string fullPath = Path.GetFullPath(imgPath);
            if (File.Exists(fullPath)) {
                return fullPath;
            }
            else {
                return @"/YGOProDevelop;component/Resources/cover.jpg";
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return null;
        }

    }
}
