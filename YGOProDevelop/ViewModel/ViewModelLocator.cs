/*
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
            SimpleIoc.Default.Register<CustomDialogRigister>(true);
            //面板模板注册器
            SimpleIoc.Default.Register<PanelTemplateRegister>(true);


            //注册服务
            SimpleIoc.Default.Register<IDialogService,DefaultDialogService>();
            SimpleIoc.Default.Register<IHighlightSettingService, DefaultHighlightSettingService>();
            SimpleIoc.Default.Register<CDB.CDBManager>();
            //注册ViewModel
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<CDBEditorViewModel>();
            
        }


        public MainViewModel Main {
            get {
               return MainViewModel.This = ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public CDBEditorViewModel CDBEditor {
            get {
                return ServiceLocator.Current.GetInstance<CDBEditorViewModel>();
            }
        }

        public IHighlightSettingService HighlightSetting {
            get {
                return ServiceLocator.Current.GetService(typeof(IHighlightSettingService)) as IHighlightSettingService;
            }
        }

//         public DocumentViewModel Document {
//             get {
//                 return ServiceLocator.Current.GetInstance<DocumentViewModel>();
//             }
//         }

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup() {
            
        }
    }
}