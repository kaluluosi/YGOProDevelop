
using ExDialogService;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using YGOProDevelop.Model;
using YGOProDevelop.Service;
using System.Linq;
using YGOProDevelop.Message;
using GalaSoft.MvvmLight.Messaging;

namespace YGOProDevelop.ViewModel {
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class CardListViewModel : ToolsViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the CardListViewModel class.
        /// </summary>
        public CardListViewModel(ICDBService cdbService, IExDialogService dialogService) {
            _cdbService = cdbService;
            ContentId = "CardList";
            _dialogService = dialogService;
            try {
                cdbService.Open(Properties.Settings.Default.lastCDB);
                ResetSearch();
            }
            catch(System.Exception ex) {
                //                 MessageBox.Show(ex.Message);
            }
        }


        private ICDBService _cdbService;

        private datas _selectedCard;
        public datas SelectedCard {
            get {
                return _selectedCard;
            }

            set {
                _selectedCard = value;
                RaisePropertyChanged();
            }
        }


        private string _keyword;

        public string KeyWord {
            get {
                return _keyword;
            }

            set {
                _keyword = value;
                RaisePropertyChanged();
            }
        }

        public override string Title {
            get {
                return "卡片列表";
            }
        }

        private ObservableCollection<datas> queryResult;

        /// <summary>
        /// 查询结果，由于使用了observerableCollection所以增删查都会自动通知控件刷新
        /// </summary>
        public ObservableCollection<datas> QueryResult {
            get {
                return queryResult;
            }
            set {
                queryResult = value;
                RaisePropertyChanged();
            }
        }



        private IExDialogService _dialogService;


        #region command
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
                            string script = Path.Combine(Properties.Settings.Default.YGOProPath,"script", "c" + _selectedCard.id + ".lua");
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
                            QueryResult = new ObservableCollection<datas>(_cdbService.Search(KeyWord));
                        else
                            ResetSearch();
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
                            _cdbService.Open(openFile.FileName);
                            ResetSearch();
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
                        ce.Card = SelectedCard;
                        ce.CardEntity = _cdbService.Datas.Entry(SelectedCard);
                        if (_dialogService.ShowDialog(ce) != true) {
                            _cdbService.Datas.Entry(SelectedCard).Reload();
                        }
                        _cdbService.Save();
                        ResetSearch();
                    }));
            }
        }


        private RelayCommand _addNewCmd;

        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public RelayCommand AddNewCmd {
            get {
                return _addNewCmd
                    ?? (_addNewCmd = new RelayCommand(
                    () => {
                        //打开卡密设置对话框
                        IDInputViewModel idInput = _dialogService.ShowDialog<IDInputViewModel>();
                        if (idInput.DialogResult !=true) return;
                        long id = idInput.Id;
                        if (_cdbService.IsIDExisted(id) == false) {
                            datas d = _cdbService.Create(id);
                            CardEditorViewModel ce = new CardEditorViewModel();
                            ce.Card = d;
                            ce.CardEntity = _cdbService.Datas.Entry(d);
                            if (_dialogService.ShowDialog(ce) == true) {
                                _cdbService.Datas.datas.Add(d);
                                _cdbService.Save();
                            }
                            ResetSearch();
                            ScrollIntoView(d);
                        }
                    }));
            }
        }

        private RelayCommand _deleteCmd;

        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public RelayCommand DeleteCmd {
            get {
                return _deleteCmd
                    ?? (_deleteCmd = new RelayCommand(
                    () => {
                        _cdbService.Remove(SelectedCard);
                        _cdbService.Save();
                        ResetSearch();
                    }));
            }
        }
        #endregion

        /// <summary>
        /// 重置搜索，相当于将所有的卡片查找出来
        /// </summary>
        public void ResetSearch() {
            QueryResult = new ObservableCollection<datas>(_cdbService.GetData());
        }

        public void ScrollIntoView(datas d) {
            MessengerInstance.Send(new NotificationMessage<datas>(this,d,CardListNotificaions.ScrollTo));
        }
    }

}