using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace YGOProDevelop.Converters {
    public class SelectModeConverter : IValueConverter {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">传入的是bool值，true表示多选，false表示单选</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return (bool)value ? SelectionMode.Multiple : SelectionMode.Single;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return null;
        }
    }
}
