using Builder;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
namespace YGOProDevelop.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class CDBEditorViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the CDBEditorViewModel class.
        /// </summary>
        public CDBEditorViewModel() {
            cards = new ObservableCollection<datas>(cdbMgr.QueryResult);

        }


        private CDB.CDBManager cdbMgr = CDB.CDBManager.Instance;
        private ObservableCollection<datas> cards;
        private datas selectedCard;

        public datas SelectedCard {
            get { return selectedCard; }
            set { selectedCard = value; 
                RaisePropertyChanged(() => SelectedCard);
                CardBuilder = new CardBuilder(selectedCard);
            }
        }
        private CardBuilder cardBuilder;

        public CardBuilder CardBuilder {
            get { return cardBuilder; }
            set { cardBuilder = value; RaisePropertyChanged(() => CardBuilder); }
        }

        public ObservableCollection<datas> Cards {
            get { return cards; }
            set { cards = value; RaisePropertyChanged(() => Cards); }
        }

    }
}