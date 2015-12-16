using Builder;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace YGOProDevelop.Converters {
    public class CardBuilderConverter : IValueConverter {
       
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if(value == null) return null;

            datas data = value as datas;
            return new CardBuilder(data);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            if(value == null) return null;
            return (value as CardBuilder).ToDatas();
        }
    }
}
