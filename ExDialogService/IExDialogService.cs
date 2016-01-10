using System;
using GalaSoft.MvvmLight;

namespace ExDialogService
{
    public interface IExDialogService
    {
        void Show(DialogViewModelBase vm);
        void Show(ViewModelBase parent, DialogViewModelBase vm);
        bool? ShowDialog(DialogViewModelBase vm);
    }
}
