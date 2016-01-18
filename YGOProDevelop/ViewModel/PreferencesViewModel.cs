using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using YGOProDevelop.Properties;
using System.Windows.Forms;

namespace YGOProDevelop.ViewModel {
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class PreferencesViewModel : ExDialogService.DialogViewModel {
        /// <summary>
        /// Initializes a new instance of the PreferencesViewModel class.
        /// </summary>
        /// 

        public PreferencesViewModel() {
            
        }

        private Settings setting = Settings.Default;

        public string YGOProPath {
            get {
                return setting.YGOProPath;
            }
            set {
                setting.YGOProPath = value;RaisePropertyChanged();
            }
        }


        private ICommand _ygoProPathSelectCmd;

        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public ICommand YGOProPathSelectCmd {
            get {
                return _ygoProPathSelectCmd
                    ?? (_ygoProPathSelectCmd = new RelayCommand(
                    () => {
                        FolderBrowserDialog fbDlg = new FolderBrowserDialog();
                        if (fbDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                            YGOProPath = fbDlg.SelectedPath;
                        }
                    }));
            }
        }
    }
}