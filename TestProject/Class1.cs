using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;


namespace TestProject
{
    public class Class1:IDialogService
    {
        public Task ShowError() {
            return Task.Run(() => MessageBox.Show("test"));
        }
        public Task ShowError(Exception error, string title, string buttonText, Action afterHideCallback) {
            return Task.Run(() => MessageBox.Show("test"));
        }

        public Task ShowError(string message, string title, string buttonText, Action afterHideCallback) {
            throw new NotImplementedException();
        }

        public Task<bool> ShowMessage(string message, string title, string buttonConfirmText, string buttonCancelText, Action<bool> afterHideCallback) {
            throw new NotImplementedException();
        }

        public Task ShowMessage(string message, string title, string buttonText, Action afterHideCallback) {
            throw new NotImplementedException();
        }

        public Task ShowMessage(string message, string title) {
            throw new NotImplementedException();
        }

        public Task ShowMessageBox(string message, string title) {
            throw new NotImplementedException();
        }

    }
}
