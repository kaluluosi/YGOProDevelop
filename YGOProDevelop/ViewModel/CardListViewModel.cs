using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using YGOProDevelop.Model;
using YGOProDevelop.Service;

namespace YGOProDevelop.ViewModel {
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class CardListViewModel :DockableViewModelBase {
        private ICDBService _cdbService;

        /// <summary>
        /// Initializes a new instance of the CardListViewModel class.
        /// </summary>
        public CardListViewModel(ICDBService cdbService) {
            CdbService = cdbService;
            cdbService.ResetSearch();
            ContentId = "CardList";
        }

        public override string Title {
            get {
                return "卡片列表";
            }
        }

        public ICDBService CdbService {
            get {
                return _cdbService;
            }

            set {
                _cdbService = value;
            }
        }
    }
}