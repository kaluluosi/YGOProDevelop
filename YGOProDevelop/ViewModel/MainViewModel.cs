using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using ICSharpCode.AvalonEdit.Document;
using System.Collections.ObjectModel;
using System.Windows.Input;
using YGOProDevelop.Service;
using ICSharpCode.AvalonEdit.Highlighting;
using Microsoft.Win32;
using System.IO;

namespace YGOProDevelop.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {

        public static MainViewModel This { get; set; }

        /// <summary>
        /// 文档viewmodel集合
        /// </summary>
        private ObservableCollection<ViewModelBase> _documentViewModels = new ObservableCollection<ViewModelBase>();
        /// <summary>
        /// 当前激活的viewmodel
        /// </summary>
        private ViewModelBase _activeViewModel;
        /// <summary>
        /// 当前激活的DocVM
        /// </summary>
        private DocumentViewModel _activeDocumentViewModel;

        /// <summary>
        /// 可停靠边缘的viewmodel
        /// </summary>
        private ObservableCollection<ViewModelBase> _anchorableViewModels = new ObservableCollection<ViewModelBase>();


        public ObservableCollection<ViewModelBase> AnchorableViewModels {
            get { return _anchorableViewModels; }
            set { _anchorableViewModels = value; RaisePropertyChanged(() => AnchorableViewModels); }
        }

        public ObservableCollection<ViewModelBase> DocumentViewModels {
            get { return _documentViewModels; }
            set { _documentViewModels = value; RaisePropertyChanged(() => DocumentViewModels); }
        }

        public ViewModelBase ActiveViewModel {
            get { return _activeViewModel; }
            set {
                _activeViewModel = value;
                RaisePropertyChanged(() => ActiveViewModel);
                if(_activeViewModel is DocumentViewModel) {
                    _activeDocumentViewModel = _activeViewModel as DocumentViewModel;
                }
            }
        }

        public bool IsShowLineNumbers {
            get { return Properties.Settings.Default.IsShowLineNumbers; }
            set {
                Properties.Settings.Default.IsShowLineNumbers = value;
                RaisePropertyChanged(() => IsShowLineNumbers);
                foreach(DocumentViewModel docVM in DocumentViewModels) {
                    docVM.IsShowLineNumbers = value;
                }
                Properties.Settings.Default.Save();
            }
        }

        #region command
        public RelayCommand<IHighlightingDefinition> SetLanguageCmd {
            get {
                return new RelayCommand<IHighlightingDefinition>(
                        language => {
                            _activeDocumentViewModel.Language = language;
                        },
                        language => {
                            return _activeDocumentViewModel != null;
                        }
                    );
            }
        }

        public RelayCommand SaveCmd {
            get {
                return new RelayCommand(
                    () => {
                        SaveDocument();
                    },
                    () => {
                        return _activeDocumentViewModel != null;
                    }
                );
            }
        }

        public RelayCommand OpenCmd {
            get {
                return new RelayCommand(
                    () => {
                        OpenDocument();
                    }
                );
            }
        }

        public RelayCommand NewCmd {
            get {
                return new RelayCommand(
                        () => {
                            NewDocument();
                        }
                    );
            }
        }

        #endregion
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel() {

        }


        #region method

        private void OpenDocument() {
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.AddExtension = true;
            openDlg.Filter = "所有文件|*.*|文本文件|*.txt|Lua脚本文件|*.lua|C#文件|*.cs";
            
            if(openDlg.ShowDialog() == true) {
                DocumentViewModel docVM = CreateDocumentVM();
                docVM.OpenFile(openDlg.FileName);
                DocumentViewModels.Add(docVM);
                ActiveViewModel = docVM;
            }
        }

        private void SaveDocument() {
            SaveFileDialog saveDlg = new SaveFileDialog();
            if(saveDlg.ShowDialog() == true) {
                _activeDocumentViewModel.SaveFile(saveDlg.FileName);
            }
        }

        private void NewDocument() {
            DocumentViewModel docVM = CreateDocumentVM();
            DocumentViewModels.Add(docVM);
            ActiveViewModel = docVM;
        }

        private DocumentViewModel CreateDocumentVM() {
            DocumentViewModel docVM = new DocumentViewModel();
            docVM.IsShowLineNumbers = IsShowLineNumbers;
            return docVM;
        }

        #endregion
    }
}