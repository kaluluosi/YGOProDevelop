using System;
using System.Windows;
namespace YGOProDevelop.Service
{
    public interface IMessageBoxService
    {
        System.Threading.Tasks.Task ShowError(Exception error, string title, Action afterHideCallback = null);
        System.Threading.Tasks.Task ShowError(string message, string title, Action afterHideCallback = null);
        System.Threading.Tasks.Task ShowMessage(string message, string title);
        System.Threading.Tasks.Task<System.Windows.MessageBoxResult> ShowMessageBox(string message, string title, System.Windows.MessageBoxImage icon, System.Windows.MessageBoxButton msgButton, System.Windows.MessageBoxResult defaultResult, Action<System.Windows.MessageBoxResult> afterHideCallback = null, System.Windows.MessageBoxOptions option = MessageBoxOptions.None);
        System.Threading.Tasks.Task<bool> ShowOKCancel(string message, string title, Action<bool> afterHideCallback);
        System.Threading.Tasks.Task<bool> ShowYesNo(string message, string title, Action<bool> afterHideCallback);
        System.Threading.Tasks.Task<bool?> ShowYesNoCancel(string message, string title, Action<bool?> afterHideCallback);
    }
}
