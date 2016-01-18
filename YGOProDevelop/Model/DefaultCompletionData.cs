using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Editing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace YGOProDevelop.Model {
        public class DefaultCompletionData : ICompletionData {
            public DefaultCompletionData() {
                Text = "";
            }

            public void Complete(TextArea textArea, ICSharpCode.AvalonEdit.Document.ISegment completionSegment, EventArgs insertionRequestEventArgs) {
                textArea.Document.Replace(completionSegment, Text);
            }

            public object Content {
                get;
                set;
            }

            public object Description {
                get;
                set;
            }

            public ImageSource Image {
                get;
                set;
            }

            public double Priority {
                get;
                set;
            }

            public string Text {
                get;
                set;
            }
        }
}
