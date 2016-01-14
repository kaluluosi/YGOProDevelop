using System.Windows;
using YGOProDevelop.Service;
using YGOProDevelop.ViewModel;
using ExDialogService;

namespace YGOProDevelop.View {
    /// <summary>
    /// CardEditView.xaml 的交互逻辑
    /// </summary>
    [CustomDialog(typeof(CardEditorViewModel),typeof(CardEditView))]
    public partial class CardEditView : Window {
        public CardEditView() {
            InitializeComponent();
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e) {
            if (e.Key == System.Windows.Input.Key.Escape) this.Close();
        }
    }
}
