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
using GalaSoft.MvvmLight.Dialog;
using GalaSoft.MvvmLight.Ioc;
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
            SimpleIoc.Default.Register<DialogRigister>(true);
            //面板模板注册器
            SimpleIoc.Default.Register<PanelTemplateRegister>(true);


            //注册服务
            SimpleIoc.Default.Register<IDialogService, DefaultDialogService>();
            SimpleIoc.Default.Register<IHighlightSettingService, DefaultHighlightSettingService>();
            //注册ViewModel
            SimpleIoc.Default.Register<MainViewModel>(()=>MainViewModel.This);
//             SimpleIoc.Default.Register<DocumentViewModel>();
            
            
        }


        public MainViewModel Main {
            get {
               return ServiceLocator.Current.GetInstance<MainViewModel>();
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