using System;
using System.Runtime.Remoting.Messaging;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using YGOProDevelop.Message;
using YGOProDevelop.Model;

namespace YGOProDevelop.View {
    /// <summary>
    /// CardListView.xaml 的交互逻辑
    /// </summary>
    public partial class CardListView : UserControl{
        public CardListView() {
            InitializeComponent();
            Messenger.Default.Register<NotificationMessage<datas>>(this, MessageHandler);

        }

        private void MessageHandler(NotificationMessage<datas> obj) {
            if(obj.Notification == CardListNotificaions.ScrollTo&&obj.Content!=null) {
                listBox.ScrollIntoView(obj.Content);
                listBox.SelectedItem = obj.Content;
            }
        }



        private void btnMore_Click(object sender, System.Windows.RoutedEventArgs e) {
            popMore.IsOpen = !popMore.IsOpen;
        }

    }
}
