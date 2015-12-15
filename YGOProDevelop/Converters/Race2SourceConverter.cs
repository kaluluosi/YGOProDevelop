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
    class Race2SourceConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value == null ||(Int64)value == 0) return null;

            VarItem item = RaceField.GetRaceItem((Int64)value);
           
            return "Resources/种族/" + item.Description + ".png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return null;
        }
    }
}
