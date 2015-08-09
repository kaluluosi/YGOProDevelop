using GalaSoft.MvvmLight;
using ICSharpCode.AvalonEdit.Document;
using Xceed.Wpf.AvalonDock;

namespace YGOProDevelop.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class DocumentViewModel : ViewModelBase
    {

        private TextDocument _document;
        private string _title;
        private string _fileName;
        private bool _isShowLineNumbers;
        public TextDocument Document {
            get { return _document; }
            set { _document = value; RaisePropertyChanged(()=>Document); }
        }

        public string Title {
            get {
                return _title;
            }
            set {
                _title = value;
                RaisePropertyChanged(()=>Title);
            }
        }
        public string FileName {
            get { return _fileName; }
            set { _fileName = value; }
        }
        public bool IsShowLineNumbers {
            get { return _isShowLineNumbers; }
            set { _isShowLineNumbers = value; RaisePropertyChanged(()=>IsShowLineNumbers); }
        }

        
        /// <summary>
        /// Initializes a new instance of the DocumentViewModel class.
        /// </summary>
        public DocumentViewModel() {

        }
    }
}