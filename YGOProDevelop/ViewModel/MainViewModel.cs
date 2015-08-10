﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using ICSharpCode.AvalonEdit.Document;
using System.Collections.ObjectModel;
using System.Windows.Input;
using YGOProDevelop.Service;
using ICSharpCode.AvalonEdit.Highlighting;
using Microsoft.Win32;
using System.IO;

namespace YGOProDevelop.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {

        private static MainViewModel _this;

        public static MainViewModel This {
            get {
                return _this ?? (_this = new MainViewModel());
            }
        }

        /// <summary>
        /// 文档viewmodel集合
        /// </summary>
        private ObservableCollection<ViewModelBase> _documentViewModels = new ObservableCollection<ViewModelBase>();
        /// <summary>
        /// 当前激活的viewmodel
        /// </summary>
        private ViewModelBase _activeViewModel;
        /// <summary>
        /// 当前激活的DocVM
        /// </summary>
        private DocumentViewModel _activeDocumentViewModel;

        /// <summary>
        /// 可停靠边缘的viewmodel
        /// </summary>
        private ObservableCollection<ViewModelBase> _anchorableViewModels = new ObservableCollection<ViewModelBase>();


        private bool _IsShowLineNumbers;
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
                if(_activeViewModel is DocumentViewModel) {
                    _activeDocumentViewModel = _activeViewModel as DocumentViewModel;
                }
            }
        }

        public bool IsShowLineNumbers {
            get { return _IsShowLineNumbers; }
            set {
                _IsShowLineNumbers = value;
                RaisePropertyChanged(() => IsShowLineNumbers);
                foreach(DocumentViewModel docVM in DocumentViewModels) {
                    docVM.IsShowLineNumbers = _IsShowLineNumbers;
                }
            }
        }

        #region command
        public RelayCommand<IHighlightingDefinition> SetLanguageCmd {
            get {
                return new RelayCommand<IHighlightingDefinition>(
                        language => {
                            _activeDocumentViewModel.Language = language;
                        },
                        language => {
                            return _activeDocumentViewModel!=null;
                        }
                    );
            }
        }

        public RelayCommand SaveCmd {
            get {
                return new RelayCommand(
                    () => {
                        SaveDocument();
                    },
                    () => {
                        return _activeDocumentViewModel!=null;
                    }
                );
            }
        }

        public RelayCommand OpenCmd {
            get {
                return new RelayCommand(
                    () => {
                        OpenDocument();
                    }
                );
            }
        }

        #endregion
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel() {

        }


        #region method

        private void OpenDocument() {
            OpenFileDialog openDlg = new OpenFileDialog();
            if(openDlg.ShowDialog() == true) {
                DocumentViewModel docVM = new DocumentViewModel();
                docVM.IsShowLineNumbers = IsShowLineNumbers;
                docVM.OpenFile(openDlg.FileName);
                DocumentViewModels.Add(docVM);
                ActiveViewModel = docVM;
            }
        }

        private void SaveDocument() {
            SaveFileDialog saveDlg = new SaveFileDialog();
            if(saveDlg.ShowDialog() == true) {
                _activeDocumentViewModel.SaveFile(saveDlg.FileName); 
            }
        }

        #endregion
    }
}