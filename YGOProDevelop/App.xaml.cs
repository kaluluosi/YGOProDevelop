using System.Windows;
using GalaSoft.MvvmLight.Threading;
using System;
using System.Diagnostics;
using System.IO;

namespace YGOProDevelop {

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        static App() {
            DispatcherHelper.Initialize();

        }

        private void Application_Startup(object sender, StartupEventArgs e) {
            #if (!DEBUG)
               AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
               Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;
               Debug.Listeners.Add(new TextWriterTraceListener("log.txt"));
               Debug.WriteLine(DateTime.Now);
            #endif
        }

        void Current_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e) {
            Debug.Write(e.Exception, "Error");
            e.Handled = true;
        }

        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) {
            if (e.ExceptionObject is Exception)
                Debug.Write((e.ExceptionObject as Exception).StackTrace);
        }
    }
}
