using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace YGOProDevelop.ViewModel {
    public class DockableViewModelBase:ViewModelBase {

        private string _title;
        private bool _isVisible = true;


        private string _contentId;

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
             IsVisible = false;
        }
    }
}
