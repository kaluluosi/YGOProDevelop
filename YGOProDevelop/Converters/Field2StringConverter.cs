using Builder;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace YGOProDevelop.Converters {
    class Field2StringConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {

            if (value == null) return null;

            string param = parameter.ToString();

            switch (param) {
                case "Race":
                    return RaceField.GetRaceItem((Int64)value).Description;

                case "Attribute":
                    return AttributeField.GetAttributeItem((Int64)value).Description;

                case "SubType":
	                return TypeField.GetSubTypeItems((Int64)value)[0].Description;

                default:
                    return null;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
