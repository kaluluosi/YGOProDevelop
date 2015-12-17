using Builder;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using YGOProDevelop.CDB;
namespace YGOProDevelop.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class CDBEditorViewModel : DialogViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the CDBEditorViewModel class.
        /// </summary>
        public CDBEditorViewModel(CDBManager cdbMgr,IDialogService dialogService) {

            try {
                this.cdbMgr = cdbMgr;
                this.cdbMgr.Open(Properties.Settings.Default.lastCDB);
                this.cdbMgr.ResetSearch();
                cards = this.cdbMgr.QueryResult;
            }
            catch(Exception ex) {
                dialogService.ShowError(ex, "错误", "", null);
            }
        }

        private IDialogService dialogService;
        private CDBManager cdbMgr;
        private ObservableCollection<datas> cards;
        private CardBuilder cardBuilder;

        public CardBuilder CardBuilder {
            get { return cardBuilder; }
            set { cardBuilder = value; RaisePropertyChanged(() => CardBuilder); }
        }

        public ObservableCollection<datas> Cards {
            get { return cards; }
            set { cards = value; RaisePropertyChanged(() => Cards); }
        }


        public ICommand Open { get;private set; }
    }
}