using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using ICSharpCode.AvalonEdit.Document;
using System.Collections.ObjectModel;
using System.Windows.Input;
using YGOProDevelop.Service;
using ICSharpCode.AvalonEdit.Highlighting;

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

        private static MainViewModel _this;

        public static MainViewModel This {
            get {
                return _this ?? (_this = new MainViewModel());
            }
        }

        /// <summary>
        /// 文档viewmodel集合
        /// </summary>
        private ObservableCollection<ViewModelBase> _documentViewModels = new ObservableCollection<ViewModelBase>();
        /// <summary>
        /// 当前激活的viewmodel
        /// </summary>
        private ViewModelBase _activeViewModel;
        /// <summary>
        /// 可停靠边缘的viewmodel
        /// </summary>
        private ObservableCollection<ViewModelBase> _anchorableViewModels = new ObservableCollection<ViewModelBase>();


        private bool _IsShowLineNumbers;
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
            set { _activeViewModel = value ?? _activeViewModel; RaisePropertyChanged(() => ActiveViewModel); }
        }

        public bool IsShowLineNumbers {
            get { return _IsShowLineNumbers; }
            set { 
                _IsShowLineNumbers = value; 
                RaisePropertyChanged(() => IsShowLineNumbers);
                foreach(DocumentViewModel docVM in DocumentViewModels) {
                    docVM.IsShowLineNumbers = _IsShowLineNumbers;
                }
            }
        }

        #region command
        public RelayCommand<IHighlightingDefinition> SetLanguageCmd {
            get {
                return new RelayCommand<IHighlightingDefinition>(
                        language => {
                            (ActiveViewModel as DocumentViewModel).Language = language;
                        },
                        language => {
                            return ActiveViewModel is DocumentViewModel;
                        }
                    );
            }
        }

        #endregion
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel() {

            TextDocument textdoc = new TextDocument();
            textdoc.Text = "测试";
            _documentViewModels.Add(new DocumentViewModel() { Document = textdoc, Title = "测试文档1" });
            _documentViewModels.Add(new DocumentViewModel() { Document = textdoc, Title = "测试文档2" });
            _documentViewModels.Add(new DocumentViewModel() { Document = textdoc, Title = "测试文档3" });

        }
    }
}