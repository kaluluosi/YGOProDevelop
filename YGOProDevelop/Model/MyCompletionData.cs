using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Editing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace YGOProDevelop.Model {
        public class MyCompletionData : ICompletionData {
            public MyCompletionData(string description,string text) {
                Description = description;
                Text = text;
                Content = text;
            }

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
