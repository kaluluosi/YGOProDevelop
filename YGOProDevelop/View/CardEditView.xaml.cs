using System.Windows;
using YGOProDevelop.Service;
using YGOProDevelop.ViewModel;

namespace YGOProDevelop.View {
    /// <summary>
    /// CardEditView.xaml 的交互逻辑
    /// </summary>
    [CustomDialog(typeof(CardEditorViewModel),typeof(CardEditView))]
    public partial class CardEditView : Window {
        public CardEditView() {
            InitializeComponent();
        }
    }
}
