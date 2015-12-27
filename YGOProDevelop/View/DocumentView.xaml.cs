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
using ICSharpCode.AvalonEdit.Search;
using ICSharpCode.AvalonEdit.Snippets;

namespace YGOProDevelop.View {
    /// <summary>
    /// DocumentView.xaml 的交互逻辑
    /// </summary>
    public partial class DocumentView : UserControl {
        private CompletionWindow completionWin;

        public DocumentView() {
            InitializeComponent();

            //Init Constant
            editor.TextArea.TextEntering += TextArea_TextEntering;
            editor.TextArea.TextEntered += TextArea_TextEntered;

            editor.TextArea.DefaultInputHandler.NestedInputHandlers.Add(new SearchInputHandler(editor.TextArea));

            Binding binding = new Binding("CompletionDatas");
            SetBinding(CompeltionDatasProperty, binding);

            editor.MouseHover += Editor_MouseHover;
            editor.MouseHoverStopped += Editor_MouseHoverStopped;

        }


        private void Editor_MouseHoverStopped(object sender, MouseEventArgs e) {
            toolTip.IsOpen = false;
        }

        ToolTip toolTip = new ToolTip();
        private void Editor_MouseHover(object sender, MouseEventArgs e) {
            var pos = editor.GetPositionFromPoint(e.GetPosition(editor));

            if (pos != null && CompletionDatas != null) {
                string text = GetWordOverMouse(e);

                var data = CompletionDatas.FirstOrDefault(d => d.Text.ToString().Contains(text));
                if (data != null) {
                    toolTip.Content = new TextBlock {
                        Text = data.Description.ToString(),
                        TextWrapping = TextWrapping.Wrap
                    };
                    toolTip.PlacementTarget = this; // required for property inheritance
                    toolTip.IsOpen = true;
                    e.Handled = true;
                }
            }
        }

        public string GetWordOverMouse(MouseEventArgs e) {
            var pos = editor.GetPositionFromPoint(e.GetPosition(editor));
            int offset = editor.Document.GetOffset(pos.Value.Location);
            int start = ICSharpCode.AvalonEdit.Document.TextUtilities.GetNextCaretPosition(editor.Document, offset, LogicalDirection.Backward, ICSharpCode.AvalonEdit.Document.CaretPositioningMode.WordBorder);
            int end = ICSharpCode.AvalonEdit.Document.TextUtilities.GetNextCaretPosition(editor.Document, offset, LogicalDirection.Forward, ICSharpCode.AvalonEdit.Document.CaretPositioningMode.WordBorder);
            if (end - start < 0) return null;
            return editor.Document.GetText(start, end - start);
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

        private void TextArea_TextEntered(object sender, TextCompositionEventArgs e) {
            if (".:".Contains(e.Text)) {
                ShowCompletionWindow();
            }
        }

        private void TextArea_TextEntering(object sender, TextCompositionEventArgs e) {
            // provide AvalonEdit with the data:
            if (char.IsLetter(e.Text[0])) {
                ShowCompletionWindow();
            }
            else if (e.Text.Length > 0 && completionWin != null) {
                if (!char.IsLetterOrDigit(e.Text[0]) && e.Text != "." && e.Text != ":") {
                    // Whenever a non-letter is typed while the completion window is open,
                    // insert the currently selected element.
                    completionWin.CompletionList.RequestInsertion(e);
                }
            }
        }

        private void ShowCompletionWindow() {
            if (completionWin == null && CompletionDatas != null) {
                CompletionWin = new CompletionWindow(editor.TextArea);
                foreach (ICompletionData data in CompletionDatas) {
                    CompletionWin.CompletionList.CompletionData.Add(data);
                }
                CompletionWin.Show();
                completionWin.CompletionList.ScrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
                completionWin.SizeToContent = SizeToContent.Width;
                CompletionWin.Closed += delegate {
                    CompletionWin = null;
                };
            }
        }
    }
}
