using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
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
