using GalaSoft.MvvmLight;
using TestApplication.Model;
using GalaSoft.MvvmLight.CommandWpf;
using ExDialogService;
using System.Windows;

namespace TestApplication.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private string _welcomeTitle = string.Empty;

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string WelcomeTitle {
            get {
                return _welcomeTitle;
            }

            set {
                if(_welcomeTitle == value) {
                    return;
                }

                _welcomeTitle = value;
                RaisePropertyChanged(WelcomeTitlePropertyName);
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService,IExDialogService dialogService) {
            _dataService = dataService;
            _dataService.GetData(
                (item, error) => {
                    if(error != null) {
                        // Report error here
                        return;
                    }

                    WelcomeTitle = item.Title;
                });

            _dialogService = dialogService;
        }

        private RelayCommand _myCommand;

        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public RelayCommand MyCommand {
            get {
                return _myCommand
                    ?? (_myCommand = new RelayCommand(
                    () => {
//                         _dialogService.ShowDialog(this, new MvvmViewModel1());

//                             _dialogService.ShowDialog(this, new MvvmViewModel1());
                        NewMethod();
                        MessageBox.Show("这是NewMethod执行后立刻执行的");

                    }));
            }
        }

        private void NewMethod() {
                var vm = new MvvmViewModel1();
            try
            {
	            _dialogService.ShowDialog(vm);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("这是异步窗口关闭后执行的 "+vm.DialogResult);
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}

        public IExDialogService _dialogService { get; set; }
    }
}