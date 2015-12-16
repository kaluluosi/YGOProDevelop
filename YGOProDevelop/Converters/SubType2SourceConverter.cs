using Builder;
using Cfg;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace YGOProDevelop.Converters {
    class SubType2SourceConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value == null) return null;
            VarItem type = TypeField.GetTypeItem((Int64)value);
            if (type.Description == "怪兽卡") return null;
            
            List<VarItem> subTypes = TypeField.GetSubTypeItems((Int64)value);
            
            return "Resources/魔陷卡类型/"+subTypes[0].Description+".png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return null;
        }
    }
}
