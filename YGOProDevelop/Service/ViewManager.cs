using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using YGOProDevelop.ViewModel;

namespace YGOProDevelop.Service
{
    /// <summary>
    /// View管理类
    /// 通过在XAML里面定义附加属性将View注册保存到_views里
    /// </summary>
    public class ViewManager
    {

        /// <summary>
        /// 所有被注册过的view实例
        /// </summary>
        private static HashSet<Window> _views = new HashSet<Window>();


        public static bool GetRegister(DependencyObject obj) {
            return (bool)obj.GetValue(RegisterProperty);
        } 

        public static void SetRegister(DependencyObject obj, bool value) {
            obj.SetValue(RegisterProperty, value);
        }

        // Using a DependencyProperty as the backing store for Register.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RegisterProperty =
            DependencyProperty.RegisterAttached("Register", typeof(bool), typeof(ViewManager), new PropertyMetadata(false,OnPropertyChanged));

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            if((bool)e.NewValue == true) {
                Window win = d as Window;
                _views.Add(d as Window);
            }
        }

        public static Window FindOwnerView(ViewModelBase vm) {
            return _views.FirstOrDefault(win => ReferenceEquals(win.DataContext, vm));
        }

        public static void Close(ViewModelBase vm) {
            Window win = FindOwnerView(vm);
            win.Close();
        }

        /// <summary>
        /// 自定义对话框工厂,viewmodel view 的映射关系
        /// key=ViewModel，value=View
        /// </summary>
        private static Dictionary<Type, Type> _customWindow = new Dictionary<Type, Type>();

        /// <summary>
        /// 注册映射关系
        /// 问题：这样一来这个注册映射关系的操作就必须在程序运行前就做，有点蛋疼！
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <typeparam name="TView"></typeparam>
        public static void Register<TViewModel, TView>() where TViewModel : DialogViewModelBase {
            _customWindow.Add(typeof(TViewModel), typeof(TView));
        }

        private static Window CreatWindowByViewModel(DialogViewModelBase vm, ViewModelBase owner = null, bool setDataContext = false) {
            Type vmType = vm.GetType();
            Type winType = _customWindow[vmType];
            Window win = Activator.CreateInstance(winType) as Window;
            //设置datacontext
            if (setDataContext == true)
                win.DataContext = vm;

            //设置owner
            if (owner != null) {
                win.Owner = ViewManager.FindOwnerView(owner);
            }

            //监听dialogresult
            vm.PropertyChanged += vm_Normal_PropertyChanged;

            return win;
        }

        private static Window CreateWindowByViewModelType<TViewModel>(ViewModelBase owner = null) where TViewModel : DialogViewModelBase {
            Type vmType = typeof(TViewModel);
            Type winType = _customWindow[vmType];
            Window win = Activator.CreateInstance(winType) as Window;

            if (owner != null)
                win.Owner = ViewManager.FindOwnerView(owner);

            return win;
        }

        /// <summary>
        /// 打开模态对话框，等待关闭返回
        /// </summary>
        /// <param name="vm">通过vm实例来创建窗口</param>
        public static bool? ShowDialog(DialogViewModelBase vm) {
            Window win = CreatWindowByViewModel(vm, setDataContext: true);
            return win.ShowDialog();
        }

        public static bool? ShowDialog(ViewModelBase owner, DialogViewModelBase vm) {
            Window win = CreatWindowByViewModel(vm, owner, true);
            return win.ShowDialog();
        }


        /// <summary>
        /// 打开非模态对话框，不等待关闭
        /// </summary>
        /// <param name="vm"></param>
        public static void Show(DialogViewModelBase vm) {
            Window win = CreatWindowByViewModel(vm, setDataContext: true);
            vm.PropertyChanged += delegate (object sender, System.ComponentModel.PropertyChangedEventArgs e) {
                if (e.PropertyName == "DialogResult") {
                    win.Close();
                }
            };
            win.Show();
        }

        public static void Show(ViewModelBase owner, DialogViewModelBase vm) {
            Window win = CreatWindowByViewModel(vm, owner, setDataContext: true);
            vm.PropertyChanged += delegate (object sender, System.ComponentModel.PropertyChangedEventArgs e) {
                if (e.PropertyName == "DialogResult") {
                    win.Close();
                }
            };
            win.Show();
        }

        private static void vm_Normal_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) {
            if (e.PropertyName == "DialogResult") {
                DialogViewModelBase dvm = sender as DialogViewModelBase;
                Window win = ViewManager.FindOwnerView(dvm);
                if (dvm.DialogResult != null) {
                    win.DialogResult = dvm.DialogResult;
                    win.Close();
                }
            }
        }


        // 通过viewmodel类型打开但不为其设置datacontext

        /// <summary>
        /// 打开非模态对话框
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <returns>返回View中绑定的DataContext的ViewModel</returns>
        public static TViewModel Show<TViewModel>() where TViewModel : DialogViewModelBase {
            Window win = CreateWindowByViewModelType<TViewModel>();
            win.Show();
            TViewModel vm = win.DataContext as TViewModel;
            vm.PropertyChanged += delegate (object sender, System.ComponentModel.PropertyChangedEventArgs e) {
                if (e.PropertyName == "DialogResult") {
                    win.Close();
                }
            };
            return win.DataContext as TViewModel;
        }

        public static TViewModel ShowDialog<TViewModel>() where TViewModel : DialogViewModelBase {
            Window win = CreateWindowByViewModelType<TViewModel>();
            win.ShowDialog();
            return win.DataContext as TViewModel;
        }

        public static TViewModel ShowDialog<TViewModel>(ViewModelBase owner) where TViewModel : DialogViewModelBase {
            Window win = CreateWindowByViewModelType<TViewModel>(owner);
            win.ShowDialog();
            return win.DataContext as TViewModel;
        }

    }
}
