using System.Windows;
using GalaSoft.MvvmLight.Threading;
using System;
using System.Diagnostics;

namespace YGOProDevelop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static App() {
            DispatcherHelper.Initialize();

        }

        private void Application_Startup(object sender, StartupEventArgs e) {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;

            Debug.Listeners.Add(new TextWriterTraceListener("log.txt"));
        }

        void Current_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e) {
            MessageBox.Show(e.Exception.Message);
            Debug.Write(e.Exception, "Error");
            e.Handled = true;
        }

        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) {
            MessageBox.Show(e.ExceptionObject.ToString());
            Debug.Write(e.ExceptionObject);
        }
    }
}
