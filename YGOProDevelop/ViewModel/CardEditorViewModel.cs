using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using YGOProDevelop.CardEditor.Builder;
using YGOProDevelop.CardEditor.Config;

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
            Categories = new SelectionCollection<VarItem>(SettingConfig.Categorys);
        }

        private CardBuilder _card;

        public CardBuilder Card {
            get {
                return _card;
            }

            set {
                _card = value;RaisePropertyChanged();
                UpdateViewModel();
            }
        }

        private void UpdateViewModel() {
            foreach(var item in Card.Category.CategoryItems) {
                foreach(var selectionItem in Categories) {
                    if(selectionItem.Content == item) {
                        selectionItem.IsSelected = true;
                    }
                }
            }
        }

        public SelectionCollection<VarItem> Categories {
            get {
                return categories;
            }

            set {
                categories = value;
                RaisePropertyChanged();
            }
        }

        private SelectionCollection<VarItem> categories;


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
                            select s.Content;
                return items.ToList();
            }
        }

    }
}