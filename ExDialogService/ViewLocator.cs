using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Markup;
using System.Xaml;
using GalaSoft.MvvmLight;

namespace ExDialogService {
    /// <summary>
    /// 负责管理和注册View,ViewModel,并用于定位Dialog
    /// </summary>
    public static class ViewLocator {
        static ViewLocator(){
            //ViewLocator被调用的时候会运行此静态方法做一次初始化.
            //搜索当前程序集里所有带CustomDialogAttribute的窗口类自动注册View -ViewModel
            foreach (var typeInfo in Assembly.GetEntryAssembly().DefinedTypes) {
                //当typeinfo搜索CustomDialogAttribute的时候会顺便实例化Attribute，然后
                //CustomDialogAttribute的构造函数里就会调用ViewLocator.RegistDialog注册View和ViewModel
                typeInfo.GetCustomAttribute<CustomDialogAttribute>();
            }
        }

        private static Window main;

        public static Window Main {
            get { return ViewLocator.main; }
        }
        /// <summary>
        /// 父窗口集合，为了防止重复使用hashset储存。
        /// </summary>
        private static HashSet<Window> views = new HashSet<Window>();
        /// <summary>
        /// 自定义对话框工厂,IDialogViewModel DialogView 的映射关系
        /// key=ViewModel，value=View
        /// </summary>
        private static Dictionary<Type, Type> _customWindowFactory = new Dictionary<Type, Type>();


        #region 父窗口注册附加属性
        public static bool GetRegistView(DependencyObject obj) {
            return (bool)obj.GetValue(RegistViewProperty);
        }

        public static void SetRegistView(DependencyObject obj, bool value) {
            obj.SetValue(RegistViewProperty, value);
        }

        // Using a DependencyProperty as the backing store for RegistView.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RegistViewProperty =
            DependencyProperty.RegisterAttached("RegistView", typeof(bool), typeof(ViewLocator), new PropertyMetadata(false, OnRegistView));


        private static void OnRegistView(DependencyObject sender,DependencyPropertyChangedEventArgs args) {
            if (sender is Window) views.Add(sender as Window);
        }



        public static bool GetRegistMain(DependencyObject obj) {
            return (bool)obj.GetValue(RegistMainProperty);
        }

        public static void SetRegistMain(DependencyObject obj, bool value) {
            obj.SetValue(RegistMainProperty, value);
        }

        // Using a DependencyProperty as the backing store for RegistMain.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RegistMainProperty =
            DependencyProperty.RegisterAttached("RegistMain", typeof(bool), typeof(ViewLocator), new PropertyMetadata(false,OnRegistMain));

        public static void OnRegistMain(DependencyObject sender, DependencyPropertyChangedEventArgs args) {
            if(sender is Window)
                main = sender as Window;
            views.Add(sender as Window);
        }
        #endregion

        /// <summary>
        /// 注册DialogView和IDialogViewModel的映射关系。
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <typeparam name="TView"></typeparam>
        public static void RegistDialog<TViewModel, TView>() where TViewModel : IDialogViewModel where TView : Window {
            _customWindowFactory.Add(typeof(TViewModel), typeof(TView));
        }

        public static void RegistDialog(IDialogViewModel vm, Window win) {
            _customWindowFactory.Add(vm.GetType(), win.GetType());
        }

        public static void RegistDialog(Type vm, Type win) {
            _customWindowFactory.Add(vm, win);
        }


        /// <summary>
        /// 获取ViewModel所属的View。
        /// 只能获取RegistView注册了的窗口。
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        public static Window GetOwnerWindow(object vm) {
            foreach(var win in views) {
                if (win.DataContext.Equals(vm)) return win;
            }
            return null;
        }


        /// <summary>
        /// 根据IDialogViewModel实例检索并创建其对应的DialogView，默认设置Owner为Main(即使Main是null)。
        /// 获得的DialogView并没有绑定datacontext到ViewModel，需要进一步调用BindingDialog方法绑定。
        /// 异常:
        ///     ViewNotFoundException:
        ///         没找到对应的View时抛出。
        /// </summary>
        /// <param name="dlgVM"></param>
        /// <returns></returns>
        public static Window CreateDialogView(IDialogViewModel dlgVM) {
            Type vmType = dlgVM.GetType();

            if(_customWindowFactory.ContainsKey(vmType)) {
                Type winType = _customWindowFactory[vmType];
                Window win = Activator.CreateInstance(winType) as Window;
                win.Owner = main;
                return win;
            }
            else {
                throw new ViewNotFoundException(vmType, vmType.ToString() + "is not found,make sure view is mark CustomDialogAttribute.");
            }
        }

        public static Window CreateDialogView<T>() where T:IDialogViewModel {
            Type vmType = typeof(T);

            if(_customWindowFactory.ContainsKey(vmType)) {
                Type winType = _customWindowFactory[vmType];
                return Activator.CreateInstance(winType) as Window;
            }
            else {
                throw new ViewNotFoundException(vmType, vmType.ToString() + "is not found,make sure view is mark CustomDialogAttribute.");
            }
        }


        /// <summary>
        /// 将IDialogViewModel绑定到DialogView上.
        /// </summary>
        /// <param name="vm"></param>
        /// <param name="view"></param>
        /// <param name="isModal"></param>
        public static void BindingDialog(IDialogViewModel vm, Window view,bool isModal=true) {
            //如果是模式对话框则将vm和view的dialogResult关联起来。
            if(isModal) {
                vm.DialogResultChanged += (sender, result) => {
                    view.DialogResult = result;
                };
            }
            
            //关联View和ViewModel的关闭操作，让ViewModel能关闭View
            vm.CloseWindow = () => {
                if(view != null && view.IsEnabled)
                    view.Close();
            };

            //设置View的DataContext为VM
            view.DataContext = vm;
        }
    }
}
