﻿/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:YGOProDevelop.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System;
using YGOProDevelop.Service;

namespace YGOProDevelop.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        static ViewModelLocator() {

            //不能删除
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            //对话框注册器
            //             SimpleIoc.Default.Register<CustomDialogRigister>(true);
            //面板模板注册器
            SimpleIoc.Default.Register<PanelTemplateRegister>(true);
            //注册ViewModel
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<CDBEditorViewModel>();

            //注册服务
            SimpleIoc.Default.Register<IMessageBoxService, MessageBoxService>();
            SimpleIoc.Default.Register<ICustomDialogService, CustomDialogService>();
            SimpleIoc.Default.Register<IHighlightSettingService, DefaultHighlightSettingService>();
            SimpleIoc.Default.Register<ICDBService, CDBService>();
            SimpleIoc.Default.Register<IIntelisenceService, DefaultIntelisenceService>();

            //注册ViewModel
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<CDBEditorViewModel>();
            SimpleIoc.Default.Register<DocumentViewModel>();


        }

        public MainViewModel Main {
            get {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public CDBEditorViewModel CDBEditor {
            get {
                return ServiceLocator.Current.GetInstance<CDBEditorViewModel>();
            }
        }

        public DocumentViewModel Document {
            get {
                return ServiceLocator.Current.GetInstance<DocumentViewModel>(Guid.NewGuid().ToString());
            }
        }

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup() {

        }
    }
}