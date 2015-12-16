using YGOProDevelop.CDBEditor.Cfg;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using YGOProDevelop.Builder;

namespace YGOProDevelop.Converters {
    class Attr2SourceConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value == null||(Int64)value ==0) return null;

            VarItem item = AttributeField.GetAttributeItem((long)value);

            string path = "Resources/属性/"+item.Description + ".png";
            
            return path;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return null;
        }
    }
}
