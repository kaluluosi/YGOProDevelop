using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using ICSharpCode.AvalonEdit.Document;
using System.Collections.ObjectModel;
using System.Windows.Input;
using YGOProDevelop.Service;
using ICSharpCode.AvalonEdit.Highlighting;
using Microsoft.Win32;
using System.IO;
using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using Xceed.Wpf.AvalonDock;
using System.ComponentModel;

namespace YGOProDevelop.ViewModel {
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase {

        public static MainViewModel Main;
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IHighlightSettingService hlSettingService,ICustomDialogService dialogService) {
            _hlSettingService = hlSettingService;
            _dialogService = dialogService;
            Main = this;
            ReOpenDocument();
        }

        private ICustomDialogService _dialogService;

        private CardListViewModel _cardListViewModel;
        /// <summary>
        /// 文档viewmodel集合
        /// </summary>
        private ObservableCollection<ViewModelBase> _documentViewModels = new ObservableCollection<ViewModelBase>();
        /// <summary>
        /// 当前激活的viewmodel
        /// </summary>
        private ViewModelBase _activeViewModel;

        /// <summary>
        /// 可停靠边缘的viewmodel
        /// </summary>
        private ObservableCollection<ViewModelBase> _anchorableViewModels = new ObservableCollection<ViewModelBase>();
        private IHighlightSettingService _hlSettingService;

        public ObservableCollection<ViewModelBase> AnchorableViewModels {
            get { return _anchorableViewModels; }
            set { _anchorableViewModels = value; RaisePropertyChanged(() => AnchorableViewModels); }
        }

        public ObservableCollection<ViewModelBase> DocumentViewModels {
            get { return _documentViewModels; }
            set { _documentViewModels = value; RaisePropertyChanged(() => DocumentViewModels); }
        }

        public ViewModelBase ActiveViewModel {
            get { return _activeViewModel; }
            set {
                _activeViewModel = value;
                RaisePropertyChanged(() => ActiveViewModel);
            }
        }

        public CardListViewModel CardListViewModel {
            get {
                if(_cardListViewModel == null) {
                    _cardListViewModel = SimpleIoc.Default.GetInstance<CardListViewModel>();
                    _anchorableViewModels.Add(_cardListViewModel);
                }
                return _cardListViewModel;
            }
        }
        public IReadOnlyCollection<IHighlightingDefinition> HightLightingDefs {
            get {
                return _hlSettingService.HighlightingDefs;
            }
        }

        public DocumentViewModel ActiveDocumentViewModel {
            get {
                return ActiveViewModel as DocumentViewModel;
            }
        }

        public bool IsShowLineNumbers {
            get { return Properties.Settings.Default.IsShowLineNumbers; }
            set {
                Properties.Settings.Default.IsShowLineNumbers = value;
                RaisePropertyChanged(() => IsShowLineNumbers);
                foreach (DocumentViewModel docVM in DocumentViewModels) {
                    docVM.IsShowLineNumbers = value;
                }
                Properties.Settings.Default.Save();
            }
        }

        #region command

        private ICommand _setLanguageCmd;
        public ICommand SetLanguageCmd {
            get {
                return _setLanguageCmd ?? (_setLanguageCmd = new RelayCommand<IHighlightingDefinition>(
                        language => {
                            ActiveDocumentViewModel.Language = language;
                        },
                        language => {
                            return ActiveViewModel is DocumentViewModel;
                        }
                    ));
            }
        }

        private ICommand _saveAsCmd;
        public ICommand SaveAsCmd {
            get {
                return _saveAsCmd ?? (_saveAsCmd = new RelayCommand(
                    () => {
//                         MessengerInstance.Send(new NotificationMessageAction<string>("SaveFile", (fileName) => {
//                             ActiveDocumentViewModel.SaveFile(fileName);
//                         }), "MainWindow");
                        SaveFileDialog saveDlg = new SaveFileDialog();
                        saveDlg.AddExtension = true;
                        saveDlg.Filter = "Lua脚本文件|*.lua|C#文件|*.cs|文本文件|*.txt|所有文件|*.*";
                        saveDlg.FilterIndex = 1;
                        if(saveDlg.ShowDialog()==true) {
                            ActiveDocumentViewModel.SaveFile(saveDlg.FileName);
                        }
                    },
                    () => {
                        return ActiveViewModel is DocumentViewModel;
                    }
                ));
            }
        }

        private ICommand _saveCmd;

        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public ICommand SaveCmd {
            get {
                return _saveCmd
                    ?? (_saveCmd = new RelayCommand(
                    () => {
                        SaveActiveDocument();
                    },
                    () => {
                        return ActiveViewModel is DocumentViewModel;
                    }));
            }
        }

        private void SaveActiveDocument() {
            if(File.Exists(ActiveDocumentViewModel.FileName))
                ActiveDocumentViewModel.SaveFile();
            else
                SaveAsCmd.Execute(null);
        }

        private ICommand _openCmd;
        public ICommand OpenCmd {
            get {
                return _openCmd ?? (_openCmd = new RelayCommand(
                    () => {
//                         MessengerInstance.Send(new NotificationMessageAction<string>("OpenFile", (fileName) => {
//                             OpenDocument(fileName);
//                         }), "MainWindow");
                        OpenFileDialog openDlg = new OpenFileDialog();
                        openDlg.AddExtension = true;
                        openDlg.Filter = "Lua脚本文件|*.lua|C#文件|*.cs|文本文件|*.txt|所有文件|*.*";
                        openDlg.FilterIndex = 1;
                        if(openDlg.ShowDialog()==true) {
                            OpenDocument(openDlg.FileName);
                        }
                    }
                ));
            }
        }

        private ICommand _newCmd;
        public ICommand NewCmd {
            get {
                return _newCmd ?? (_newCmd = new RelayCommand(
                        () => {
                            NewDocument();
                        }
                    ));
            }
        }

        private ICommand _closingCmd;
        public ICommand ClosingCmd {
            get {
                return _closingCmd
                    ?? (_closingCmd = new RelayCommand(
                    () => {
                        System.Collections.Specialized.StringCollection files = new System.Collections.Specialized.StringCollection();
                        foreach (DocumentViewModel doc in DocumentViewModels) {
                            files.Add(doc.FileName);
                        }
                        Properties.Settings.Default.lastFiles = files;
                        Properties.Settings.Default.Save();
                    }));
            }
        }

        private ICommand _showCardListCmd;
        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public ICommand ShowCardListCmd {
            get {
                return _showCardListCmd
                    ?? (_showCardListCmd = new RelayCommand(
                    () => {
                        CardListViewModel.IsVisible = true;
                    }));
            }
        }

        private ICommand _openPreferencesCmd;
        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public ICommand OpenPreferencesCmd {
            get {
                return _openPreferencesCmd
                    ?? (_openPreferencesCmd = new RelayCommand(
                    () => {
                        _dialogService.ShowDialog<PreferencesViewModel>();
                    }));
            }
        }

        #endregion
        #region method

        public void ReOpenDocument() {
            var files = Properties.Settings.Default.lastFiles;
            if (files != null && files.Count != 0) {
                foreach (var fileName in files) {
                    if (File.Exists(fileName))
                        OpenDocument(fileName);
                }
            }
        }

        public void NewDocument() {
            DocumentViewModel docVM = CreateDocumentVM();
            DocumentViewModels.Add(docVM);
            ActiveViewModel = docVM;
        }


        public void OpenDocument(string fileName) {
            foreach(var doc in DocumentViewModels) {
                if (doc is DocumentViewModel && (doc as DocumentViewModel).FileName == fileName) {
                    ActiveViewModel = doc;
                    return;
                }
            }
            var docVM = CreateDocumentVM();
            docVM.OpenFile(fileName);
            DocumentViewModels.Add(docVM);
            ActiveViewModel = docVM;
        }

        public DocumentViewModel CreateDocumentVM() {
            DocumentViewModel docVM = SimpleIoc.Default.GetInstance<DocumentViewModel>(Guid.NewGuid().ToString());
            docVM.IsShowLineNumbers = IsShowLineNumbers;
            return docVM;
        }

        #endregion
    }
}