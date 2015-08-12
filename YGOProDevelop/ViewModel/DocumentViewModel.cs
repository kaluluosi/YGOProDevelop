using GalaSoft.MvvmLight;
using ICSharpCode.AvalonEdit.Document;
using System.IO;
using System.Xml;
using Xceed.Wpf.AvalonDock;
using YGOProDevelop.Properties;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using ICSharpCode.AvalonEdit.Utils;
using System.Threading.Tasks;

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

        private TextDocument _document=new TextDocument();
        private string _fileName;
        private bool _isShowLineNumbers;
        private IHighlightingDefinition _language;
        public ICSharpCode.AvalonEdit.Highlighting.IHighlightingDefinition Language {
            get { return _language; }
            set { _language = value; RaisePropertyChanged(()=>Language); }
        }
        public TextDocument Document {
            get { return _document; }
            set { _document = value; RaisePropertyChanged(()=>Document); }
        }

        public string Title {
            get {
                return _fileName==null?"未命名":Path.GetFileName(_fileName);
            }
        }
        public string FileName {
            get { return _fileName; }
            set { _fileName = value; RaisePropertyChanged(() => Title); RaisePropertyChanged(() => FileName); }
        }
        public bool IsShowLineNumbers {
            get { return _isShowLineNumbers; }
            set { _isShowLineNumbers = value; RaisePropertyChanged(()=>IsShowLineNumbers); }
        }

        public string Extension {
            get {
                return Path.GetExtension(FileName);
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the DocumentViewModel class.
        /// </summary>
        public DocumentViewModel() {
            
        }

        public void OpenFile(string fileName) {
            if(File.Exists(fileName) == false)
                throw new FileNotFoundException("文档不存在", fileName);
            FileName = fileName;
            StreamReader  reader= FileReader.OpenFile(fileName, System.Text.Encoding.UTF8);
            _document.Text = reader.ReadToEnd();
            reader.Close();

            string extension = Path.GetExtension(fileName);
            Language = HighlightingManager.Instance.GetDefinitionByExtension(extension);
        }

        public void SaveFile(string fileName) {
            StreamWriter writer = new StreamWriter(fileName);
            writer.Write(_document.Text);
            writer.Close();
            FileName = fileName;
        }
    }
}