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
    public class PreferencesViewModel : DialogViewModelBase {
        /// <summary>
        /// Initializes a new instance of the PreferencesViewModel class.
        /// </summary>
        /// 

        public PreferencesViewModel() {
            
        }

        private Settings setting = Settings.Default;

        public string ScriptFolderPath {
            get {
                return setting.scriptFolder;
            }
            set {
                setting.scriptFolder = value;
            }
        }

        public string PicFolderPath {
            get {
                return setting.picFolder;
            }
            set {
                setting.picFolder = value;
            }
        }


        private ICommand _picFolderSelectCmd;

        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public ICommand PicFolderSelectCmd {
            get {
                return _picFolderSelectCmd
                    ?? (_picFolderSelectCmd = new RelayCommand(
                    () => {
                        FolderBrowserDialog fbDlg = new FolderBrowserDialog();
                        if (fbDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                            PicFolderPath = fbDlg.SelectedPath;
                        }
                    }));
            }
        }

        private ICommand _scriptFolderSelectCmd;

        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public ICommand ScriptFolderSelectCmd {
            get {
                return _scriptFolderSelectCmd
                    ?? (_scriptFolderSelectCmd = new RelayCommand(
                    () => {
                        FolderBrowserDialog fbDlg = new FolderBrowserDialog();
                        if (fbDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                            ScriptFolderPath = fbDlg.SelectedPath;
                        }
                    }));
            }
        }
    }
}