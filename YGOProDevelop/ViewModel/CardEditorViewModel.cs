using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using YGOProDevelop.CardEditor.Builder;
using YGOProDevelop.CardEditor.Config;
using YGOProDevelop.Model;
using GalaSoft.MvvmLight.Command;
using System.Data.Entity.Infrastructure;
using YGOProDevelop.Service;

namespace YGOProDevelop.ViewModel {
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class CardEditorViewModel : ExDialogService.DialogViewModel {
        /// <summary>
        /// Initializes a new instance of the CardEditorViewModel class.
        /// </summary>
        public CardEditorViewModel() {
           
        }

        private ICDBService _cdbService;

        private datas _card;

        public datas Card {
            get {
                return _card;
            }

            set {
                _card = value;
                RaisePropertyChanged();
                Categories.SelectedItems = _card.Category;
                Types.SelectedItems = _card.Type;
            }
        }

        public DbEntityEntry CardEntity { get; set; }

        private SelectionCollection<VarItem> _types = new SelectionCollection<VarItem>(SettingConfig.Types);
        public SelectionCollection<VarItem> Types {
            get {
                return _types;
            }
        }


        private SelectionCollection<VarItem> _categories = new SelectionCollection<VarItem>(SettingConfig.Categorys);
        public SelectionCollection<VarItem> Categories {
            get {
                return _categories;
            }
        }


        private RelayCommand _resetCmd;
        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public RelayCommand ResetCmd {
            get {
                return _resetCmd
                    ?? (_resetCmd = new RelayCommand(
                    () => {
                        if (CardEntity != null) CardEntity.Reload();
                        RaisePropertyChanged(() => Card);
                    }));
            }
        }

        protected override void OnSubmit() {
            Card.Category = Categories.SelectedItems;
            Card.Type = Types.SelectedItems;
            base.OnSubmit();
        }


    }

    public class Selection<T>:ObservableObject {
        private bool _isSelected;
        private T _content;

        public bool IsSelected {
            get {
                return _isSelected;
            }

            set {
                _isSelected = value;RaisePropertyChanged();
            }
        }

        public T Content {
            get {
                return _content;
            }

            set {
                _content = value; RaisePropertyChanged();
            }
        }
    }

    public class SelectionCollection<T> : ObservableCollection<Selection<T>> {

        public SelectionCollection(IEnumerable<T> collection):base(
                from s in collection select new Selection<T> { IsSelected=false,Content=s}
            ) {
        }

        public List<T> SelectedItems {
            get {
                var items = from s in this
                            where s.IsSelected
                            select s.Content;
                return items.ToList();
            }
            set {
                foreach(var item in value) {
                    Select(item);
                }
            }
        }

        public void Select(T item) {
            Selection<T> selection = Items.FirstOrDefault(i => i.Content.Equals(item));
            if (selection != null) selection.IsSelected = true;
        }

        public void UnSelect(T item) {
            Selection<T> selection = Items.FirstOrDefault(i => i.Content.Equals(item));
            if (selection != null) selection.IsSelected = false;
        }
    }
}