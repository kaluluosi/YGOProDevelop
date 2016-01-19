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
            win.Owner = ViewLocator.Main;
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
            win.Owner = ViewLocator.Main;

            return win.ShowDialog();
        }

        public bool? ShowDialog(object parent, IDialogViewModel vm) {
            Window win = ViewLocator.CreateDialogView(vm);
            ViewLocator.BindingDialog(vm, win, true);
            win.Owner = ViewLocator.GetOwnerWindow(parent) ?? ViewLocator.Main;
            return win.ShowDialog();
        }


        public T Show<T>() where T : IDialogViewModel {
            Window win = ViewLocator.CreateDialogView<T>();
            ViewLocator.BindingDialog(win.DataContext as IDialogViewModel, win,false);
            win.Owner = ViewLocator.Main;

            win.Show();
            return (T)win.DataContext;
        }

        public T Show<T>(object parent) where T : IDialogViewModel {
            Window win = ViewLocator.CreateDialogView<T>();
            win.Owner = ViewLocator.GetOwnerWindow(parent) ?? ViewLocator.Main;
            ViewLocator.BindingDialog(win.DataContext as IDialogViewModel, win,false);

            win.Show();
            return (T)win.DataContext;
        }

        public T ShowDialog<T>() where T : IDialogViewModel {
            Window win = ViewLocator.CreateDialogView<T>();
            ViewLocator.BindingDialog(win.DataContext as IDialogViewModel, win,true);
            win.Owner = ViewLocator.Main;
            win.ShowDialog();
            return (T)win.DataContext ;
        }



        public T ShowDialog<T>(object parent) where T : IDialogViewModel {
            Window win = ViewLocator.CreateDialogView<T>();
            win.Owner = ViewLocator.GetOwnerWindow(parent) ?? ViewLocator.Main;
            ViewLocator.BindingDialog(win.DataContext as IDialogViewModel, win, true);
            win.ShowDialog();
            return (T)win.DataContext ;
        }
    }
}
