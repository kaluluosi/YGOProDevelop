using System.Windows;
using YGOProDevelop.ViewModel;
using System.Collections.Generic;
using Xceed.Wpf.AvalonDock.Themes;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Views;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;

namespace YGOProDevelop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow() {
            InitializeComponent();
            Closing += (s, e) => { ViewModelLocator.Cleanup(); Properties.Settings.Default.Save(); };

            ChangeTheme(Properties.Settings.Default.Theme);
        }


        private void themesMenu_Click(object sender, RoutedEventArgs e) {
            string header = (e.Source as MenuItem).Header.ToString();
            ChangeTheme(header);
        }

        public void ChangeTheme(string themeName) {
            switch(themeName) {
                case "VS2010":
                    dock.Theme = new VS2010Theme();
                    break;
                case "Aero":
                    dock.Theme = new AeroTheme();
                    break;
                case "ExpressLight":
                    dock.Theme = new ExpressionLightTheme();
                    break;
                case "Generic":
                    dock.Theme = new GenericTheme();
                    break;
                case "Metro":
                    dock.Theme = new MetroTheme();
                    break;
                default:
                case "ExpressDark":
                    dock.Theme = new ExpressionDarkTheme();
                    break;
            }
            Properties.Settings.Default.Theme = themeName;
        }

    }
}