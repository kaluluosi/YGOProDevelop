using System.Windows;
using ExDialogService;
using YGOProDevelop.ViewModel;

namespace YGOProDevelop.View {
    /// <summary>
    /// IDInputView.xaml 的交互逻辑
    /// </summary>
    [CustomDialog(typeof(IDInputViewModel),typeof(IDInputView))]
    public partial class IDInputView : Window {
        public IDInputView() {
            InitializeComponent();
        }
    }
}
