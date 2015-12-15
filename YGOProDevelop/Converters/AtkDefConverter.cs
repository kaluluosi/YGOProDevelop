using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace YGOProDevelop.Converters {
    class AtkDefConverter : IMultiValueConverter {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
            if(values != null) {
                string atkDefInfo = string.Format("ATK:{0} DEF:{1}", values[0], values[1]);
                return atkDefInfo;
            }else {
                return "";
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
            return null;
        }
    }
}
