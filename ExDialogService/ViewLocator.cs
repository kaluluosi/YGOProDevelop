using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using GalaSoft.MvvmLight;

namespace ExDialogService {
    /// <summary>
    /// 负责管理和注册View,ViewModel,并用于定位Dialog
    /// </summary>
    public static class ViewLocator {
        static ViewLocator(){
            //ViewLocator被调用的时候会运行此静态方法做一次初始化.
            //搜索当前程序集里所有带CustomDialogAttribute的窗口类自动注册View -ViewModel
            foreach (var typeInfo in Assembly.GetExecutingAssembly().DefinedTypes) {
                typeInfo.GetCustomAttribute<CustomDialogAttribute>();
            }
        }

        /// <summary>
        /// 父窗口集合
        /// </summary>
        private static HashSet<Window> views = new HashSet<Window>();
        /// <summary>
        /// 自定义对话框工厂,dialogViewModel DialogView 的映射关系
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
        #endregion

        /// <summary>
        /// 注册对话框窗口和对话框VM的映射关系。
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <typeparam name="TView"></typeparam>
        public static void RegistDialog<TViewModel, TView>() where TViewModel : DialogViewModelBase where TView : Window {
            _customWindowFactory.Add(typeof(TViewModel), typeof(TView));
        }

        public static void RegistDialog(DialogViewModelBase vm, Window win) {
            _customWindowFactory.Add(vm.GetType(), win.GetType());
        }

        public static void RegistDialog(Type vm, Type win) {
            _customWindowFactory.Add(vm, win);
        }


        /// <summary>
        /// 获取viewmodel所属的view。
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        public static Window GetOwnerWindow(ViewModelBase vm) {
            foreach(var win in views) {
                if (win.DataContext.Equals(vm)) return win;
            }
            return null;
        }
    }
}
