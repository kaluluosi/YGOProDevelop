using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YGOProDevelop.Model {
    public class SelectionCollection<T>:ObservableCollection<T> where T:Selection {

        public List<T> SelectedItems {
            get {
                return (from s in this where s.IsSelected select s).ToList();
            }
            set {
                ClearSelected();
                value.ForEach(s => Select(s));
            }
        }

        public void Select(T item) {
            T selection = Items.FirstOrDefault(s => s.Equals(item));
            if (selection != null) selection.IsSelected = true;
        }

        public void UnSelect(T item) {
            T selection = Items.FirstOrDefault(s => s.Equals(item));
            if (selection != null) selection.IsSelected = false;
        }

        public void ClearSelected() {
            foreach(var item in Items) {
                item.IsSelected = false;
            }
        }
    }
}
