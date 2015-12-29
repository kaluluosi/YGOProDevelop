using System;
using System.Globalization;
using System.Windows.Data;
using YGOProDevelop.CardEditor.Builder;
using YGOProDevelop.Model;

namespace YGOProDevelop.View.Converter {
    public class Datas2StringConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {

            if (value == null) return null;

            CardBuilder card = new CardBuilder(value as datas);

            switch (parameter.ToString()) {
                case "Race":
                    return card.Race.RaceItem.Description;
                case "SubType":
                    return card.Type.SubTypeItems[0].Description;
                case "AtkDef":
                    return string.Format("ATK:{0} DEF:{1}", card.Atk, card.Def);
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return null;
        }
    }
}
