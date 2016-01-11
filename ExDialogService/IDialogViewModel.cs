using System;
namespace ExDialogService
{
    public interface IDialogViewModel
    {
        GalaSoft.MvvmLight.Command.RelayCommand CancelCmd { get; }
        Action CloseWindow { get; set; }
        bool? DialogResult { get; set; }
        event EventHandler<bool?> DialogResultChanged;
        GalaSoft.MvvmLight.Command.RelayCommand SubmitCmd { get; }
    }
}
