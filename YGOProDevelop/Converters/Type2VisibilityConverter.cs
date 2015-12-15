using Builder;
using YGOProDevelop.CDBEditor.Cfg;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace YGOProDevelop.Converters {
    class Type2VisibilityConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value == null) return null;
            VarItem type = TypeField.GetTypeItem((Int64)value);
            string target = parameter.ToString();

            return target.Contains(type.Description)?System.Windows.Visibility.Visible:System.Windows.Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return null;
        }
    }
}
