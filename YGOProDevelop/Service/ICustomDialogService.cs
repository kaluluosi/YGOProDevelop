using System;
namespace YGOProDevelop.Service
{
    public interface ICustomDialogService
    {
        void Show(YGOProDevelop.ViewModel.DialogViewModelBase vm);
        TViewModel Show<TViewModel>() where TViewModel : YGOProDevelop.ViewModel.DialogViewModelBase;
        bool? ShowDialog(YGOProDevelop.ViewModel.DialogViewModelBase vm);
        TViewModel ShowDialog<TViewModel>() where TViewModel : YGOProDevelop.ViewModel.DialogViewModelBase;
    }
}
