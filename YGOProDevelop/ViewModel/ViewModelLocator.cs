﻿/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:YGOProDevelop.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using System.Configuration;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using YGOProDevelop.Service;

namespace YGOProDevelop.ViewModel {
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

            //注册服务
            SimpleIoc.Default.Register<ExDialogService.IExDialogService,ExDialogService.DefaultDialogService>();
            SimpleIoc.Default.Register<IHighlightSettingService, DefaultHighlightSettingService>();
            SimpleIoc.Default.Register<IIntelisenceService, SmartIntelisenceService>();
            SimpleIoc.Default.Register<ICDBService, CDBService>();
//             SimpleIoc.Default.Register<SettingsBase>(() => Properties.Settings.Default);

            //注册ViewModel
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<DocumentViewModel>();
            SimpleIoc.Default.Register<ToolsViewModelBase,CardListViewModel>();
        }

        public static MainViewModel Main {
            get {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }


        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup() {
            
        }

    }
}