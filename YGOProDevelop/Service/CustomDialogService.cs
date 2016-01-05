using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using YGOProDevelop.ViewModel;

namespace YGOProDevelop.Service {
    /// <summary>
    /// View管理类
    /// 通过在XAML里面定义附加属性将View注册保存到_views里
    /// </summary>
    public class CustomDialogService : ICustomDialogService {

        public static Window MainWindow;

        /// <summary>
        /// 自定义对话框工厂,viewmodel view 的映射关系
        /// key=ViewModel，value=View
        /// </summary>
        private static Dictionary<Type, Type> _customWindowFactory = new Dictionary<Type, Type>();

        /// <summary>
        /// 注册映射关系
        /// 问题：这样一来这个注册映射关系的操作就必须在程序运行前就做，有点蛋疼！
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <typeparam name="TView"></typeparam>
        public static void Regist<TViewModel, TView>() where TViewModel : DialogViewModelBase where TView : Window {
            _customWindowFactory.Add(typeof(TViewModel), typeof(TView));
        }

        public static void Regist(DialogViewModelBase vm, Window win) {
            _customWindowFactory.Add(vm.GetType(), win.GetType());
        }

        public static void Regist(Type vm, Type win) {
            _customWindowFactory.Add(vm, win);
        }

        public static bool GetRegister(DependencyObject obj) {
            return (bool)obj.GetValue(RegisterProperty);
        }


        public static void SetRegister(DependencyObject obj, bool value) {
            obj.SetValue(RegisterProperty, value);
        }

        // Using a DependencyProperty as the backing store for Register.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RegisterProperty =
            DependencyProperty.RegisterAttached("Register", typeof(bool), typeof(CustomDialogService), new PropertyMetadata(false, OnPropertyChanged));

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            if ((bool)e.NewValue == true) {
                if (d is Window) {
                    Window win = d as Window;
                    MainWindow = win;
                }
            }
        }

        static CustomDialogService() {
            //这个服务创建的时候搜索当前程序集里所有带CustomDialogAttribute的类自动注册View-ViewModel
            foreach (var typeInfo in Assembly.GetExecutingAssembly().DefinedTypes) {
                typeInfo.GetCustomAttribute<CustomDialogAttribute>();
            }
        }

        /// <summary>
        /// 具体的vm和view的 dialogresult行为根据窗口是用show还是用showdialog打开来决定。
        /// show打开的窗口 dialogresult改变 和调用closewindow都会直接关闭窗口。
        /// showdialog打开的窗口 dialogresult改变只会影响window的dialogresult不直接关闭窗口。
        /// </summary>
        /// <param name="vm"></param>
        /// <param name="win"></param>
        /// <param name="isDialog"></param>
        private void BindDialogVM(DialogViewModelBase vm, Window win, bool isDialog = true) {
            if (isDialog) {
                vm.DialogResultChanged += (sender, result) => {
                    win.DialogResult = result;
                };
            }
            else {
                vm.DialogResultChanged += (sender, result) => {
                    win.Close();
                };
            }
            vm.CloseWindow = () => {
                if (win != null && win.IsEnabled)
                    win.Close();
            };
        }

        private Window CreatWindowByViewModel(DialogViewModelBase vm, ViewModelBase owner = null, bool setDataContext = false) {
            Type vmType = vm.GetType();
            if (_customWindowFactory.ContainsKey(vmType) == false || _customWindowFactory[vmType] == null) throw new Exception(vmType + "没有注册！");
            Type winType = _customWindowFactory[vmType];
            Window win = Activator.CreateInstance(winType) as Window;
            //设置datacontext
            if (setDataContext == true)
                win.DataContext = vm;

            //设置owner
            if (MainWindow != null) {
                win.Owner = CustomDialogService.MainWindow;
                CustomDialogService.MainWindow.Closed += (s, e) => win.Close();
            }

            //监听dialogresult
            //             vm.PropertyChanged += vm_Normal_PropertyChanged;

            return win;
        }

        private Window CreateWindowByViewModelType<TViewModel>(ViewModelBase owner = null) where TViewModel : DialogViewModelBase {
            Type vmType = typeof(TViewModel);
            if (_customWindowFactory.ContainsKey(vmType) == false || _customWindowFactory[vmType] == null) throw new Exception(vmType + "没有注册！");
            Type winType = _customWindowFactory[vmType];
            Window win = Activator.CreateInstance(winType) as Window;

            if (MainWindow != null) {
                win.Owner = CustomDialogService.MainWindow;
                CustomDialogService.MainWindow.Closed += (s, e) => win.Close();
            }

            return win;
        }

        /// <summary>
        /// 打开模态对话框，等待关闭返回
        /// </summary>
        /// <param name="vm">通过vm实例来创建窗口</param>
        public bool? ShowDialog(DialogViewModelBase vm) {
            Window win = CreatWindowByViewModel(vm, setDataContext: true);
            BindDialogVM(vm, win);
            return win.ShowDialog();
        }

        public TViewModel ShowDialog<TViewModel>() where TViewModel : DialogViewModelBase {
            Window win = CreateWindowByViewModelType<TViewModel>();
            TViewModel vm = win.DataContext as TViewModel;
            BindDialogVM(vm, win);
            win.ShowDialog();
            return vm;
        }

        /// <summary>
        /// 打开非模态对话框，不等待关闭
        /// </summary>
        /// <param name="vm"></param>
        public void Show(DialogViewModelBase vm) {
            Window win = CreatWindowByViewModel(vm, setDataContext: true);
            BindDialogVM(vm, win, false);
            win.Show();
        }

        // 通过viewmodel类型打开但不为其设置datacontext
        /// <summary>
        /// 打开非模态对话框
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <returns>返回View中绑定的DataContext的ViewModel</returns>
        public TViewModel Show<TViewModel>() where TViewModel : DialogViewModelBase {
            Window win = CreateWindowByViewModelType<TViewModel>();
            TViewModel vm = win.DataContext as TViewModel;
            BindDialogVM(vm, win, false);
            win.Show();
            return win.DataContext as TViewModel;
        }

    }
}
