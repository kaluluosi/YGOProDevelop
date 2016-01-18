using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using Microsoft.Practices.ServiceLocation;

namespace YGOProDevelop.ViewModel {
    public abstract class DockableViewModelBase:ViewModelBase {
        /// <summary>
        /// 主工作区的引用
        /// </summary>
        public MainViewModel Main {
            get {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        protected string _title;
        protected bool _isVisible = true;

        protected string _contentId;

        public virtual string Title {
            get {
                return _title;
            }
            set {
                _title = value; RaisePropertyChanged();
            }
        }

        public bool IsVisible {
            get {
                return _isVisible;
            }

            set {
                _isVisible = value; RaisePropertyChanged();
            }
        }


        public string ContentId {
            get {
                return _contentId;
            }

            set {
                _contentId = value;RaisePropertyChanged();
            }
        }


        private ICommand _closeCmd;

        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public ICommand CloseCmd {
            get {
                return _closeCmd
                    ?? (_closeCmd = new RelayCommand(
                    () => {
                        OnClose();
                    }));
            }
        }

        protected virtual void OnClose() {
             
        }
    }
}
