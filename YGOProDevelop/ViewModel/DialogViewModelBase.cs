using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YGOProDevelop.ViewModel {
    public abstract class DialogViewModelBase:ViewModelBase
    {
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
    }
}
