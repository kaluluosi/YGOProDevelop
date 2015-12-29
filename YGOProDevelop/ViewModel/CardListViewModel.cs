using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using YGOProDevelop.Model;
using YGOProDevelop.Service;

namespace YGOProDevelop.ViewModel {
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class CardListViewModel :DockableViewModelBase {
        private ICDBService _cdbService;

        /// <summary>
        /// Initializes a new instance of the CardListViewModel class.
        /// </summary>
        public CardListViewModel(ICDBService cdbService,ICustomDialogService dialogService) {
            CdbService = cdbService;
            cdbService.ResetSearch();
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
                        try
                        {
                            string script = @".\script\c" + _selectedCard.id + ".lua";
                            if(File.Exists(script)) {
                                Main.OpenDocument(script);
                            }
                            else {
                                MessageBoxResult result =  MessageBox.Show("脚本不存在是否新建？", "提示", MessageBoxButton.YesNo);
                                if(result == MessageBoxResult.Yes) {
                                    string path =  Path.GetDirectoryName(script);
                                    if(Directory.Exists(path) == false)
                                        Directory.CreateDirectory(path);
                                    File.CreateText(script).Close();
                                    Main.OpenDocument(script);
                                }
                            }
                        }
                        catch (System.Exception ex)
                        {
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
                    ?? (_searchCmd = new RelayCommand<KeyEventArgs>(
                    (arg) => {
                        if (arg.Key == Key.Enter) {
                            if (string.IsNullOrEmpty(KeyWord) == false)
                                CdbService.Search(KeyWord);
                            else
                                CdbService.ResetSearch();
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
                        ce.Card = SelectedCard;
                        _dialogService.ShowDialog(ce);
                    }));
            }
        }


        public datas SelectedCard {
            get {
                return _selectedCard;
            }

            set {
                _selectedCard = value;RaisePropertyChanged();
            }
        }

        public string KeyWord {
            get {
                return _keyword;
            }

            set {
                _keyword = value;RaisePropertyChanged();
            }
        }
    }
}