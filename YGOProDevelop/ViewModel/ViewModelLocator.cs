/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:YGOProDevelop.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using System;
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
            SimpleIoc.Default.Register<IHighlightSettingService>(()=>new DefaultHighlightSettingService(@"Data\Highlight"));
            SimpleIoc.Default.Register<IIntelisenceService>(() =>new SmartIntelisenceService(@"data\Intelisence"));
            SimpleIoc.Default.Register<ICDBService, CDBService>();

            //注册ViewModel
            SimpleIoc.Default.Register<IDInputViewModel>();
            SimpleIoc.Default.Register<DocumentViewModel>();
            SimpleIoc.Default.Register<CardListViewModel>();
            SimpleIoc.Default.Register<MainViewModel>(true);

        }

        public static MainViewModel Main {
            get {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public IDInputViewModel IDInput {
            get {
                return ServiceLocator.Current.GetInstance<IDInputViewModel>();
            }
        }

        public static DocumentViewModel Document
        {
            get { return ServiceLocator.Current.GetInstance<DocumentViewModel>(Guid.NewGuid().ToString()); }
        }

        public static CardListViewModel CardList
        {
            get { return ServiceLocator.Current.GetInstance<CardListViewModel>(Guid.NewGuid().ToString()); }
        }

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup() {
            
        }

    }
}