using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;
using System.Windows.Input;
using YGOProDevelop.Service;
using ICSharpCode.AvalonEdit.Highlighting;
using System.IO;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Configuration;
using ExDialogService;
using Microsoft.Practices.ServiceLocation;

namespace YGOProDevelop.ViewModel {
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase {

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IHighlightSettingService hlSettingService,IExDialogService  dialogService) {
            _hlSettingService = hlSettingService;
            _dialogService = dialogService;
            ReOpenDocument();
        }


        private IExDialogService _dialogService;

        private IHighlightSettingService _hlSettingService;

        /// <summary>
        /// 文档viewmodel集合
        /// </summary>
        private ObservableCollection<DocumentViewModel> _documentViewModels = new ObservableCollection<DocumentViewModel>();
        /// <summary>
        /// 当前激活的viewmodel
        /// </summary>
        private ViewModelBase _activeViewModel;

        /// <summary>
        /// 可停靠边缘的viewmodel
        /// </summary>
        private ObservableCollection<ToolsViewModelBase> _anchorableViewModels;

        public ObservableCollection<ToolsViewModelBase> AnchorableViewModels {
            get { return _anchorableViewModels??(_anchorableViewModels= new ObservableCollection<ToolsViewModelBase>(ServiceLocator.Current.GetAllInstances<ToolsViewModelBase>())); }
            set { _anchorableViewModels = value; RaisePropertyChanged(() => AnchorableViewModels); }
        }

        public ObservableCollection<DocumentViewModel> DocumentViewModels {
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
                        SaveDocument(ActiveDocumentViewModel, true);
                    },
                    () => ActiveViewModel is DocumentViewModel
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
                        SaveDocument(ActiveDocumentViewModel);
                    },
                    () => {
                        return ActiveViewModel is DocumentViewModel;
                    }));
            }
        }

        private ICommand _openCmd;
        public ICommand OpenCmd {
            get {
                return _openCmd ?? (_openCmd = new RelayCommand(
                    () => {
                        OpenFileDialog openDlg = new OpenFileDialog();
                        openDlg.AddExtension = true;
                        openDlg.Filter = "Lua脚本文件|*.lua|C#文件|*.cs|文本文件|*.txt|所有文件|*.*";
                        openDlg.FilterIndex = 1;
                        if (openDlg.ShowDialog() == DialogResult.OK) {
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

        private RelayCommand _saveAllCmd;

        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public RelayCommand SaveAllCmd {
            get {
                return _saveAllCmd
                    ?? (_saveAllCmd = new RelayCommand(
                    () => {
                        foreach(DocumentViewModel doc in DocumentViewModels) {
                            doc.SaveFile();
                        }
                    }));
            }
        }

        /// <summary>
        /// 编辑器关闭时保存最后打开的文件
        /// </summary>
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

        private ICommand _openPreferencesCmd;
        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public ICommand OpenPreferencesCmd {
            get {
                return _openPreferencesCmd
                    ?? (_openPreferencesCmd = new RelayCommand(
                    () => {
                        _dialogService.ShowDialog<PreferencesViewModel>(this );
                    }));
            }
        }


        #endregion
        #region method

        public void SaveDocument(DocumentViewModel doc, bool saveAs = false) {
            //如果doc的文件名是空的则证明这个文件是未命名文件或者saveAs是true，使用另存为，否则直接覆盖保存。
            if (doc.FileName == null || saveAs) {
                SaveFileDialog saveDlg = new SaveFileDialog();
                saveDlg.AddExtension = true;
                saveDlg.Filter = "Lua脚本文件|*.lua|C#文件|*.cs|文本文件|*.txt|所有文件|*.*";
                saveDlg.FilterIndex = 1;
                if (saveDlg.ShowDialog() == DialogResult.OK) {
                    doc.SaveFile(saveDlg.FileName);
                }
            }
            else {
                doc.SaveFile();
            }
        }

        /// <summary>
        /// 重新打开上次没关闭的文档
        /// </summary>
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
            foreach (var doc in DocumentViewModels) {
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
            DocumentViewModel docVM = ServiceLocator.Current.GetInstance<DocumentViewModel>(Guid.NewGuid().ToString());
            docVM.IsShowLineNumbers = IsShowLineNumbers;
            return docVM;
        }

        public void CloseDocument(DocumentViewModel doc) {
            //如果文档修改过则询问是否保存，cancel则取消关闭文档。
            if (doc.IsDirty) {
                DialogResult result =MessageBox.Show("是否保存" + doc.Title + "?", "保存", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes) {
                    SaveDocument(doc);
                }
                else if (result == DialogResult.Cancel) {
                    return;
                }
            }
            //如果文档没被改过则直接关闭
            if (DocumentViewModels.Contains(doc))
                DocumentViewModels.Remove(doc);
        }

        public void CloseAllBut(DocumentViewModel doc) {
            var doc2close = new List<DocumentViewModel>();
            foreach(var docVM in DocumentViewModels) {
                if (docVM != null && docVM != doc)
                    doc2close.Add(docVM);
            }
            foreach(var docVM in doc2close) {
                CloseDocument(docVM);
            }
        }

        #endregion
    }
}