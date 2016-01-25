using System.Collections.Generic;
using System.Windows;
using GalaSoft.MvvmLight.Threading;

namespace TestApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static App() {
            DispatcherHelper.Initialize();


            string test = "1";

            string[] tests = new[] { test };

            tests[0] = "shit";

            MessageBox.Show(test+" "+tests[0]);

        }
    }
}
