using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using YGOProDevelop.CardEditor.Builder;
using YGOProDevelop.Model;

namespace YGOProDevelop.View.Converter {
    public class Datas2SourceConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value == null) return null;

            CardBuilder card = new CardBuilder(value as datas);

            switch (parameter.ToString()) {

                case "Pic":
                    string imgPath = Path.Combine(Properties.Settings.Default.picFolder, card.ID + ".jpg"); ;
                    string fullPath = Path.GetFullPath(imgPath);
                    if (File.Exists(fullPath)) {
                        return fullPath;
                    }
                    else {
                        return @"/YGOProDevelop;component/Resources/cover.jpg";
                    }
                case "Attribute":
                    return @"/YGOProDevelop;component/Resources/属性/" + card.Attribute.AttributeItem.Description + ".png";
                case "Type":
                    string type = card.Type.TypeItem.Description== "魔法卡"?"魔":"陷";
                    return @"/YGOProDevelop;component/Resources/属性/" +type+ ".png";
                case "SubType":
                    return @"/YGOProDevelop;component/Resources/魔陷卡类型/" + card.Type.SubTypeItems[0].Description + ".png";
                case "Race":
                    return @"/YGOProDevelop;component/Resources/种族/" + card.Race.RaceItem.Description + ".png";
                default:
                    return null;
            }

            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return null;
        }

    }
}
