using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using YGOProDevelop.Message;

namespace YGOProDevelop.View {
    /// <summary>
    /// CardListView.xaml 的交互逻辑
    /// </summary>
    public partial class CardListView : UserControl{
        public CardListView() {
            InitializeComponent();
            Messenger.Default.Register<object>(this,CardList.ScrollTo, (msg) => { listBox.ScrollIntoView(msg); });

        }

        private void btnMore_Click(object sender, System.Windows.RoutedEventArgs e) {
            popMore.IsOpen = !popMore.IsOpen;
        }

    }
}
