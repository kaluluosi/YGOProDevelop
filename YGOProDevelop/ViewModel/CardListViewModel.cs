
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
                            Search(_keyword);
                        else
                            ResetSearch();
                        RaisePropertyChanged(() => QueryResult);
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
                            datas d = CreateCard(id);
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

        private datas CreateCard(long id) {
            datas d = _cdbService.Datas.datas.Create();
            d.texts = _cdbService.Datas.texts.Create();
            d.id = d.texts.id = id;
            d.texts.desc = "";
            d.texts.name = "未命名";
            return d;
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
            var result = from c in _cdbService.Datas.datas
                         select c;
            QueryResult = new ObservableCollection<datas>(result);
        }

        /// <summary>
        /// 根据id来查找
        /// </summary>
        /// <returns>返回查找到的数量</returns>
        public int Search(int id) {
            //不通知界面刷新的resetsearch
            queryResult = new ObservableCollection<datas>(_cdbService.Datas.datas);
            var result = from c in queryResult
                         where c.id == id
                         select c;
            //必须为QueryResult赋值才会通知界面
            QueryResult = new ObservableCollection<datas>(result);
            return QueryResult.Count;
        }

        /// <summary>
        /// 通过卡片名称和描述来查找，这是默认的查找方式
        /// </summary>
        public int Search(string keyword) {
            //不通知界面刷新的resetsearch
            queryResult = new ObservableCollection<datas>(_cdbService.Datas.datas);
            var result = from c in queryResult
                         join t in _cdbService.Datas.texts on c.id equals t.id
                         where string.Join(t.desc,t.name,t.id).Contains(keyword)
                         select c;
            QueryResult = new ObservableCollection<datas>(result);
            return QueryResult.Count;
        }

        public datas CreateNewCard(long id) {
            if (_cdbService.IsIDExisted(id) == false) {
                datas d = _cdbService.Datas.datas.Create();
                d.id = id;
                return d;
            }
            return null;
        }

        public void ScrollIntoView(datas d) {
            MessengerInstance.Send<object>(d,CardList.ScrollTo);
        }
    }

}