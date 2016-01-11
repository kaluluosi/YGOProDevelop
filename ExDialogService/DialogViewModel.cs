using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExDialogService
{
    /// <summary>
    /// 对话框ViewModel基类
    /// </summary>
    public abstract class DialogViewModel : ViewModelBase, ExDialogService.IDialogViewModel
    {

        private bool? dialogResult;
        public bool? DialogResult {
            get { return dialogResult; }
            set { dialogResult = value; RaisePropertyChanged(); OnDialogResultChanged(value); }
        }

        public event EventHandler<bool?> DialogResultChanged;
        private void OnDialogResultChanged(bool? result) {
            if(DialogResultChanged != null) {
                DialogResultChanged(this, result);
            }
        }

        private Action closeWindow = () => { };

        public Action CloseWindow {
            get { return closeWindow; }
            set { closeWindow = value; }
        }

        private RelayCommand submitCmd;

        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public RelayCommand SubmitCmd {
            get {
                return submitCmd
                    ?? (submitCmd = new RelayCommand(
                    () => {
                        OnSubmit();
                    }));
            }
        }

        protected virtual void OnSubmit() {
            DialogResult = true;
        }

        private RelayCommand cancelCmd;

        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public RelayCommand CancelCmd {
            get {
                return cancelCmd
                    ?? (cancelCmd = new RelayCommand(
                    () => {
                        OnCancel();
                    }));
            }
        }

        protected virtual void OnCancel() {
            DialogResult = false;
        }
    }
}

