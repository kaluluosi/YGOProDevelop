using GalaSoft.MvvmLight;
using System;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Threading;

namespace ExDialogService {
    /// <summary>
    /// View管理类
    /// 通过在XAML里面定义附加属性将View注册保存到_views里
    /// </summary>
    public class DefaultDialogService : IExDialogService {
        public void Show(IDialogViewModel vm) {
            Window win = ViewLocator.CreateDialogView(vm);
            ViewLocator.BindingDialog(vm, win, false);
            win.Show();
        }

        public void Show(object parent, IDialogViewModel vm) {
            Window win = ViewLocator.CreateDialogView(vm);
            ViewLocator.BindingDialog(vm, win, false);
            win.Owner = ViewLocator.GetOwnerWindow(parent)??ViewLocator.Main;
            win.Show();
        }

        public bool? ShowDialog(IDialogViewModel vm) {
            Window win = ViewLocator.CreateDialogView(vm);
            ViewLocator.BindingDialog(vm, win, true);
            return win.ShowDialog();
        }

        public bool? ShowDialog(object parent, IDialogViewModel vm) {
            Window win = ViewLocator.CreateDialogView(vm);
            ViewLocator.BindingDialog(vm, win, true);
            win.Owner = ViewLocator.GetOwnerWindow(parent) ?? ViewLocator.Main;
            return win.ShowDialog();
        }


        public void Show<T>() where T : IDialogViewModel {
            Window win = ViewLocator.CreateDialogView<T>();
            win.Show();
        }

        public void Show<T>(object parent) where T : IDialogViewModel {
            Window win = ViewLocator.CreateDialogView<T>();
            win.Owner = ViewLocator.GetOwnerWindow(parent) ?? ViewLocator.Main;
            win.Show();
        }

        public bool? ShowDialog<T>() where T : IDialogViewModel {
            Window win = ViewLocator.CreateDialogView<T>();
            return win.ShowDialog();
        }



        public bool? ShowDialog<T>(object parent) where T : IDialogViewModel {
            Window win = ViewLocator.CreateDialogView<T>();
            win.Owner = ViewLocator.GetOwnerWindow(parent) ?? ViewLocator.Main;
            return win.ShowDialog();
        }
    }
}
