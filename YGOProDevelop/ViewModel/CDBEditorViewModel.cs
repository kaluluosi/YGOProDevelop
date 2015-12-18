using Builder;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Input;
using YGOProDevelop.Model;
using YGOProDevelop.Service;
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
        public CDBEditorViewModel(ICDBService cdbService, IMessageBoxService msgBoxService) {
            this.msgBoxService = msgBoxService;

            try {
                this.cdbService = cdbService;
                if(string.IsNullOrEmpty(Properties.Settings.Default.lastCDB) == false) {
                    this.cdbService.Open(Properties.Settings.Default.lastCDB);
                    this.cdbService.ResetSearch();
                }
                cards = this.cdbService.QueryResult;
            }
            catch(Exception ex) {
                Debug.WriteLine("Debug",ex.StackTrace);
                msgBoxService.ShowError(ex, "警告");
                Properties.Settings.Default.lastCDB = "";
            }
        }

        private ICDBService cdbService;
        private ObservableCollection<datas> cards;
        private CardBuilder cardBuilder;
        private IMessageBoxService msgBoxService;

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