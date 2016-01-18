using System;
using System.Globalization;
using System.Windows.Data;
using YGOProDevelop.Model;

namespace YGOProDevelop.View.Converter {
    public class Datas2StringConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {

            if (value == null) return null;

            datas card = value as datas;

            switch (parameter.ToString()) {
                case "Race":
                    return card.Race.Description;
                case "SubType":
                    return card.SubType.Description;
                case "AtkDef":
                    return string.Format(" ATK:{0} DEF:{1} ", card.atk,card.def);
                default:
                    return null;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return null;
        }
    }
}
