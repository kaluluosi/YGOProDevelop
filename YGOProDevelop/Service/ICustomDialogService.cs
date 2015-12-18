using System;
namespace YGOProDevelop.Service
{
    public interface ICustomDialogService
    {
        void Show(GalaSoft.MvvmLight.ViewModelBase owner, YGOProDevelop.ViewModel.DialogViewModelBase vm);
        void Show(YGOProDevelop.ViewModel.DialogViewModelBase vm);
        TViewModel Show<TViewModel>() where TViewModel : YGOProDevelop.ViewModel.DialogViewModelBase;
        bool? ShowDialog(GalaSoft.MvvmLight.ViewModelBase owner, YGOProDevelop.ViewModel.DialogViewModelBase vm);
        bool? ShowDialog(YGOProDevelop.ViewModel.DialogViewModelBase vm);
        TViewModel ShowDialog<TViewModel>() where TViewModel : YGOProDevelop.ViewModel.DialogViewModelBase;
        TViewModel ShowDialog<TViewModel>(GalaSoft.MvvmLight.ViewModelBase owner) where TViewModel : YGOProDevelop.ViewModel.DialogViewModelBase;
    }
}
