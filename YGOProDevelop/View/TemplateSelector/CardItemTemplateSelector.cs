using System.Windows;
using System.Windows.Controls;
using YGOProDevelop.CardEditor.Builder;
using YGOProDevelop.Model;

namespace YGOProDevelop.View.TemplateSelector {
    public class CardItemTemplateSelector:DataTemplateSelector {


        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container) {
            if(item is datas) {
                var card = new CardBuilder(item as datas);
                switch (card.CardType) {
                    case CardType.Monster:
                        return MonDataTemplate;
                    default:
                        return SpellDataTemplate;
                }
            }
            else {
                return SpellDataTemplate;
            }
        }

        public DataTemplate SpellDataTemplate {
            get;
            set;
        }
        public DataTemplate MonDataTemplate {
            get;
            set;
        }
    }
}
