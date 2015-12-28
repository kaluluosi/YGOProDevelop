using GalaSoft.MvvmLight;
using YGOProDevelop.Model;

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
                _card = value;RaisePropertyChanged();
            }
        }
    }
}