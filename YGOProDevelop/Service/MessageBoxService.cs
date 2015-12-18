using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace YGOProDevelop.Service
{
    public class MessageBoxService : YGOProDevelop.Service.IMessageBoxService
    {
        /// <summary>
        /// 定制具体messagebox
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="icon"></param>
        /// <param name="msgButton"></param>
        /// <param name="defaultResult"></param>
        /// <param name="afterHideCallback"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public Task<MessageBoxResult> ShowMessageBox(
            string message, 
            string title, 
            MessageBoxImage icon, 
            MessageBoxButton msgButton,
            MessageBoxResult defaultResult, 
            Action<MessageBoxResult> afterHideCallback=null, 
            MessageBoxOptions option=MessageBoxOptions.None
            ) {
            
            return Task<MessageBoxResult>.Run(() => {
                MessageBoxResult result = MessageBox.Show(message, title, msgButton, icon, defaultResult, option);
                if(afterHideCallback != null)
                    afterHideCallback(result);
                return result;
            });
        }


        public Task ShowError(string message, string title, Action afterHideCallback=null) {
            return Task.Run(() => {
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
                if(afterHideCallback != null)
                    afterHideCallback();
            });
        }

        public Task ShowError(Exception error, string title, Action afterHideCallback=null) {
            return ShowError(error.Message, title, afterHideCallback);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="afterHideCallback"></param>
        /// <returns>OK returns true，cancel returns false</returns>
        public Task<bool> ShowOKCancel(string message, string title, Action<bool> afterHideCallback) {
            return Task<bool>.Run(() => {
                MessageBoxResult msgResult = MessageBox.Show(message, title, MessageBoxButton.OKCancel, MessageBoxImage.Question);
                bool result = msgResult == MessageBoxResult.OK ? true : false;
                if(afterHideCallback != null)
                    afterHideCallback(result);
                return result;
            });
        }

        public Task<bool> ShowYesNo(string message, string title, Action<bool> afterHideCallback) {
            return Task<bool>.Run(() => {
                MessageBoxResult msgResult = MessageBox.Show(message, title, MessageBoxButton.YesNo, MessageBoxImage.Question);
                bool result = msgResult == MessageBoxResult.Yes ? true : false;
                if(afterHideCallback != null)
                    afterHideCallback(result);
                return result;
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="afterHideCallback"></param>
        /// <returns>Yes returns true,No returns false,Cancel returns null</returns>
        public Task<bool?> ShowYesNoCancel(string message, string title, Action<bool?> afterHideCallback) {
            return Task<bool?>.Run(() => {
                MessageBoxResult msgResult = MessageBox.Show(message, title, MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                bool? result;
                if(msgResult == MessageBoxResult.Cancel){
                    result = null;
                }
                else {
                    result = msgResult == MessageBoxResult.Yes ? true : false;

                }
                if(afterHideCallback != null)
                    afterHideCallback(result);
                return result;
            });
        }

        public Task ShowMessage(string message, string title) {
            return Task.Run(() => {
                MessageBox.Show(message, title,MessageBoxButton.OK,MessageBoxImage.Information);
            });
        }

    }
}
