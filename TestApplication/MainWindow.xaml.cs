using System.Windows;
using TestApplication.ViewModel;

namespace TestApplication
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
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {

        }
    }
}