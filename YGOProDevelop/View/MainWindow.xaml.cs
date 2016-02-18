using System.Windows;
using YGOProDevelop.ViewModel;
using Xceed.Wpf.AvalonDock.Themes;
using System.Windows.Controls;
using Xceed.Wpf.AvalonDock.Layout.Serialization;
using YGOProDevelop.View;
using System.Diagnostics;

namespace YGOProDevelop {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow() {
            InitializeComponent();

            layoutSerilizer = new XmlLayoutSerializer(dock);

            Closing += (s, e) => { ViewModelLocator.Cleanup(); Properties.Settings.Default.Save(); };

            ChangeTheme(Properties.Settings.Default.Theme);
        }

        private XmlLayoutSerializer layoutSerilizer;

        private void themesMenu_Click(object sender, RoutedEventArgs e) {
            string header = (e.Source as MenuItem).Header.ToString();
            ChangeTheme(header);
        }

        public void ChangeTheme(string themeName) {
            switch (themeName) {
                case "Aero":
                    dock.Theme = new AeroTheme();
                    break;
                case "Generic":
                    dock.Theme = new GenericTheme();
                    break;
                case "Metro":
                    dock.Theme = new MetroTheme();
                    break;
                case "VS2010":
                default:
                    dock.Theme = new VS2010Theme();
                    break;
            }
            Properties.Settings.Default.Theme = themeName;
        }

        private void window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            layoutSerilizer.Serialize(@".\layout.cfg");
        }

        private void window_Loaded(object sender, RoutedEventArgs e) {
            try {
                layoutSerilizer.Deserialize(@".\layout.cfg");
            }
            catch (System.Exception ex) {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e) {
            (new AboutWindow()).ShowDialog();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e) {
            System.Diagnostics.Process.Start("https://github.com/kaluluosi/YGOProDevelop/releases");
        }
    }
}