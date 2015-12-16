using YGOProDevelop.Builder;
using YGOProDevelop.CDBEditor.Cfg;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace YGOProDevelop.Converters {
    class Type2SourceConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {

            if (value == null) return null;

            VarItem item = TypeField.GetTypeItem((Int64)value);

            string path = "Resources/属性/{0}.png";

            if(item.Description == "魔法卡") {
                return string.Format(path, "魔");
            }
            else if (item.Description == "陷阱卡") {
                return string.Format(path, "陷");
            }

            return null;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return null;
        }
    }
}
