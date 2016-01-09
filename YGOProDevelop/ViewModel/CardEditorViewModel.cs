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


namespace YGOProDevelop.ViewModel {
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class CardEditorViewModel : DialogViewModelBase {
        /// <summary>
        /// Initializes a new instance of the CardEditorViewModel class.
        /// </summary>
        public CardEditorViewModel() {
            
        }

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