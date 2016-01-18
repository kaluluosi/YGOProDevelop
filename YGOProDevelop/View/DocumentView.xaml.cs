using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Search;

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
            SetBinding(CompletionDataSourceProperty, binding);

            editor.MouseHover += Editor_MouseHover;
            editor.MouseHoverStopped += Editor_MouseHoverStopped;
        }


        private void Editor_MouseHoverStopped(object sender, MouseEventArgs e) {
            toolTip.IsOpen = false;
        }

        ToolTip toolTip = new ToolTip();
        private void Editor_MouseHover(object sender, MouseEventArgs e) {
            var pos = editor.GetPositionFromPoint(e.GetPosition(editor));
            string text = GetWordOverMouse(e);
            if (pos != null && CompletionDataSource != null&&text!=null) {
                var data = CompletionDataSource.FirstOrDefault(d => d.Text==null? false :d.Text==text);
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
            try
            {
	            var pos = editor.GetPositionFromPoint(e.GetPosition(editor));
	            int offset = editor.Document.GetOffset(pos.Value.Location);
	            int start = ICSharpCode.AvalonEdit.Document.TextUtilities.GetNextCaretPosition(editor.Document, offset, LogicalDirection.Backward, ICSharpCode.AvalonEdit.Document.CaretPositioningMode.WordBorder);
	            int end = ICSharpCode.AvalonEdit.Document.TextUtilities.GetNextCaretPosition(editor.Document, offset, LogicalDirection.Forward, ICSharpCode.AvalonEdit.Document.CaretPositioningMode.WordBorder);
                if (end - start < 0) return null;
                return editor.Document.GetText(start, end - start);
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
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
        public IList<ICompletionData> CompletionDataSource {
            get { return (IList<ICompletionData>)GetValue(CompletionDataSourceProperty); }
            set { SetValue(CompletionDataSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CompeltionDatas.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CompletionDataSourceProperty =
            DependencyProperty.Register("CompletionDataSourceProperty", typeof(IList<ICompletionData>), typeof(DocumentView), new PropertyMetadata(null));


        private void TextArea_TextEntered(object sender, TextCompositionEventArgs e) {
            if (".:".Contains(e.Text)) {
                if(completionWin != null)
                    completionWin.Close();
                ShowCompletionWindow();
            }
        }

        private void TextArea_TextEntering(object sender, TextCompositionEventArgs e) {
            // provide AvalonEdit with the data:
            if (char.IsLetter(e.Text[0])) {
                ShowCompletionWindow();
            }
            else if (e.Text.Length > 0 && completionWin != null) {
                if(!char.IsLetterOrDigit(e.Text[0]) && !".:".Contains(e.Text)) {
                    completionWin.CompletionList.RequestInsertion(e);
                }
            }
        }

        private void ShowCompletionWindow() {
            if (completionWin == null && CompletionDataSource != null) {
                CompletionWin = new CompletionWindow(editor.TextArea);
                foreach (ICompletionData data in CompletionDataSource) {
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
