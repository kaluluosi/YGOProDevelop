using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
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


        private ICommand _editCmd;
        private ICustomDialogService _dialogService;

        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public ICommand EditCmd {
            get {
                return _editCmd
                    ?? (_editCmd = new RelayCommand(
                    () => {
                        try
                        {
                            var cardEditor = new CardEditorViewModel();
                            cardEditor.Card = SelectedCard;
                            _dialogService.ShowDialog(cardEditor);
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