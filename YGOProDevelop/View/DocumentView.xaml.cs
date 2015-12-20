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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ICSharpCode.AvalonEdit.CodeCompletion;
using YGOProDevelop.Service;
using GalaSoft.MvvmLight.Messaging;
using ICSharpCode.AvalonEdit.Editing;
using ICSharpCode.AvalonEdit;
using System.Timers;
using System.ComponentModel;

namespace YGOProDevelop.View
{
    /// <summary>
    /// DocumentView.xaml 的交互逻辑
    /// </summary>
    public partial class DocumentView : UserControl
    {
        private CompletionWindow completionWin;
        private static List<ICompletionData> datas;

        public DocumentView() {
            InitializeComponent();

            //Init Constant
            editor.TextArea.TextEntering += TextArea_TextEntering;

            Binding binding = new Binding("CompletionDatas");
            SetBinding(CompeltionDatasProperty, binding);
        }

        public CompletionWindow CompletionWin {
            get {
                return completionWin;
            }

            set {
                completionWin = value;
            }
        }

        /// <summary>
        /// 自动完成数据依赖属性，可以将这个属性绑定到ViewModel里自动获取自动完成需要的数据
        /// </summary>
        public IList<ICompletionData> CompletionDatas {
            get { return (IList<ICompletionData>)GetValue(CompeltionDatasProperty); }
            set { SetValue(CompeltionDatasProperty, value); }
        }


        // Using a DependencyProperty as the backing store for CompeltionDatas.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CompeltionDatasProperty =
            DependencyProperty.Register("CompeltionDatas", typeof(IList<ICompletionData>), typeof(DocumentView), new PropertyMetadata(null));


        private void TextArea_TextEntering(object sender, TextCompositionEventArgs e) {
            // provide AvalonEdit with the data:
            CompletionWin = new CompletionWindow(editor.TextArea);
            foreach(ICompletionData data in CompletionDatas) {
                CompletionWin.CompletionList.CompletionData.Add(data);
            }
            CompletionWin.Show();
            CompletionWin.Closed += delegate {
                CompletionWin = null;
            };
        }

    }
}
