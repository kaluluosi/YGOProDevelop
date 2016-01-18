using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using YGOProDevelop.Model;
using setting = YGOProDevelop.Properties.Settings;

namespace YGOProDevelop.View.Converter {
    public class Datas2SourceConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value == null) return null;

            datas card = value as datas;

            switch (parameter.ToString()) {

                case "Pic":
                    string imgPath = Path.Combine(setting.Default.YGOProPath,"Pics", card.id + ".jpg") ;
                    string fullPath = Path.GetFullPath(imgPath);
                    if (File.Exists(fullPath)) {
                        return fullPath;
                    }
                    else {
                        return @"/YGOProDevelop;component/Resources/cover.jpg";
                    }
                case "Attribute":
                    return @"/YGOProDevelop;component/Resources/属性/" + card.Attribute.Description + ".png";
                case "Type":
                    if(card.CardType==CardType.Monster)
                        return @"/YGOProDevelop;component/Resources/属性/" +card.Attribute.Description+ ".png";
                    else
                        return @"/YGOProDevelop;component/Resources/属性/" + (card.CardType==CardType.Spell?"魔":"陷") + ".png";
                case "SubType":
                    return @"/YGOProDevelop;component/Resources/魔陷卡类型/" + card.SubType.Description + ".png";
                case "Race":
                    return @"/YGOProDevelop;component/Resources/种族/" + card.Race.Description + ".png";
                default:
                    return null;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return null;
        }

    }
}
