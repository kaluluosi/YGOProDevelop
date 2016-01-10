using GalaSoft.MvvmLight;
using System;
using GalaSoft.MvvmLight.Command;

namespace ExDialogService {
    public abstract class DialogViewModelBase : ViewModelBase {

        private bool? dialogResult;
        public bool? DialogResult {
            get { return dialogResult; }
            set { dialogResult = value; RaisePropertyChanged("DialogResult");OnDialogResultChanged(value); }
        }

        public event EventHandler<bool?> DialogResultChanged;
        private void OnDialogResultChanged(bool? result) {
            if (DialogResultChanged != null) {
                DialogResultChanged(this, result);
            }
        }

        public Action CloseWindow = () => { };

        private RelayCommand _submit;

        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public RelayCommand Submit {
            get {
                return _submit
                    ?? (_submit = new RelayCommand(
                    () => {
                        OnSubmit();
                    }));
            }
        }

        protected virtual void OnSubmit() {
            DialogResult = true;
        }

        private RelayCommand _cancel;

        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public RelayCommand Cancel {
            get {
                return _cancel
                    ?? (_cancel = new RelayCommand(
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
