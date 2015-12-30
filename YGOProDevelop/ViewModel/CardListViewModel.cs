using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using YGOProDevelop.Model;
using YGOProDevelop.Service;

namespace YGOProDevelop.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class CardListViewModel : DockableViewModelBase
    {
        private ICDBService _cdbService;

        /// <summary>
        /// Initializes a new instance of the CardListViewModel class.
        /// </summary>
        public CardListViewModel(ICDBService cdbService, ICustomDialogService dialogService) {
            CdbService = cdbService;
            try {
                cdbService.Open(Properties.Settings.Default.lastCDB);
                cdbService.ResetSearch();
            }
            catch(System.Exception ex) {
                //                 MessageBox.Show(ex.Message);
            }
            ContentId = "CardList";

            _dialogService = dialogService;
        }


        private datas _selectedCard;
        private string _keyword;

        public override string Title {
            get {
                return "卡片列表";
            }
        }

        public ICDBService CdbService {
            get {
                return _cdbService;
            }

            set {
                _cdbService = value;
            }
        }

        public ObservableCollection<datas> QueryResult {
            get {
                return _cdbService.QueryResult;
            }
        }


        private ICustomDialogService _dialogService;

        private ICommand _openScriptCmd;
        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public ICommand OpenScriptCmd {
            get {
                return _openScriptCmd
                    ?? (_openScriptCmd = new RelayCommand(
                    () => {
                        try {
                            string script = string.Format(@"{0}\c{1}.lua", Properties.Settings.Default.scriptFolder, _selectedCard.id);
                            if(File.Exists(script)) {
                                Main.OpenDocument(script);
                            }
                            else {
                                MessageBoxResult result = MessageBox.Show("脚本不存在是否新建？", "提示", MessageBoxButton.YesNo);
                                if(result == MessageBoxResult.Yes) {
                                    string path = Path.GetDirectoryName(script);
                                    if(Directory.Exists(path) == false)
                                        Directory.CreateDirectory(path);
                                    File.CreateText(script).Close();
                                    Main.OpenDocument(script);
                                }
                            }
                        }
                        catch(System.Exception ex) {
                            MessageBox.Show(ex.Message);
                        }
                    }));
            }
        }

        private ICommand _searchCmd;
        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public ICommand SearchCmd {
            get {
                return _searchCmd
                    ?? (_searchCmd = new RelayCommand(
                    () => {
                        if(string.IsNullOrEmpty(_keyword) == false)
                            CdbService.Search(_keyword);
                        else
                            CdbService.ResetSearch();

                    }));
            }
        }

        private ICommand _openCDBCmd;

        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public ICommand OpenCDBCmd {
            get {
                return _openCDBCmd
                    ?? (_openCDBCmd = new RelayCommand(
                    () => {
                        OpenFileDialog openFile = new OpenFileDialog();
                        openFile.Filter = "CDB文件|*.cdb";
                        bool? result = openFile.ShowDialog();
                        if(result == true) {
                            CdbService.Open(openFile.FileName);
                            CdbService.ResetSearch();
                            Properties.Settings.Default.lastCDB = openFile.FileName;
                        }
                    }));
            }
        }

        private ICommand _editCmd;

        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public ICommand EditCmd {
            get {
                return _editCmd
                    ?? (_editCmd = new RelayCommand(
                    () => {
                        CardEditorViewModel ce = new CardEditorViewModel();
                        ce.Card = new CardEditor.Builder.CardBuilder(SelectedCard);
                        _dialogService.ShowDialog(ce);
                    }));
            }
        }


        public datas SelectedCard {
            get {
                return _selectedCard;
            }

            set {
                _selectedCard = value;
                RaisePropertyChanged();
            }
        }

        public string KeyWord {
            get {
                return _keyword;
            }

            set {
                _keyword = value;
                RaisePropertyChanged();
            }
        }
    }
}