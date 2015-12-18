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

namespace YGOProDevelop.View
{
    /// <summary>
    /// DocumentView.xaml 的交互逻辑
    /// </summary>
    public partial class DocumentView : UserControl
    {
        private static CompletionWindow completionWin;
        private static List<ICompletionData> datas;

        public DocumentView() {
            InitializeComponent();

            //Init Constant
        }


        private class MyCompletionData : ICompletionData
        {
            public void Complete(TextArea textArea, ICSharpCode.AvalonEdit.Document.ISegment completionSegment, EventArgs insertionRequestEventArgs) {
                textArea.Document.Replace(completionSegment, Text);
            }

            public object Content {
                get;
                private set;
            }

            public object Description {
                get;
                private set;
            }

            public ImageSource Image {
                get;
                private set;
            }

            public double Priority {
                get;
                private set;
            }

            public string Text {
                get;
                private set;
            }
        }
    }
}
