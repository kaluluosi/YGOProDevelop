using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using ICSharpCode.AvalonEdit.Document;
using System.Collections.ObjectModel;
using System.Windows.Input;

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
            get { return MainViewModel._this ?? (_this = new MainViewModel()); }
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


        private bool _IsShowLineNUmbers;
        public ObservableCollection<ViewModelBase> AnchorableViewModels {
            get { return _anchorableViewModels; }
            set { _anchorableViewModels = value; RaisePropertyChanged(()=>AnchorableViewModels); }
        }

        public ObservableCollection<ViewModelBase> DocumentViewModels {
            get { return _documentViewModels; }
            set { _documentViewModels = value; RaisePropertyChanged(()=>DocumentViewModels); }
        }

        public ViewModelBase ActiveViewModel {
            get { return _activeViewModel; }
            set { _activeViewModel = value; RaisePropertyChanged(()=>ActiveViewModel); }
        }

        public bool IsShowLineNUmbers {
            get { return _IsShowLineNUmbers; }
            set { _IsShowLineNUmbers = value; RaisePropertyChanged(() => IsShowLineNUmbers); }
        }


        #region command
        private ICommand _showLineNumbersCmd;
        public System.Windows.Input.ICommand ShowLineNumbersCmd {
            get {
                return new RelayCommand<bool>(isChecked => {
                    foreach(DocumentViewModel docVM in DocumentViewModels) {
                        docVM.IsShowLineNumbers = isChecked;
                    }
                });
            }
        }
        

        #endregion
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel() {

            TextDocument textdoc = new TextDocument();
            textdoc.Text = "测试";
            _documentViewModels.Add(new DocumentViewModel() { Document = textdoc });
            _documentViewModels.Add(new DocumentViewModel() { Document = textdoc });
            _documentViewModels.Add(new DocumentViewModel() { Document = textdoc });

        }
    }
}