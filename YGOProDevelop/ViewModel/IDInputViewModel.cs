using GalaSoft.MvvmLight;
using ExDialogService;
using YGOProDevelop.Service;
using GalaSoft.MvvmLight.Command;
using System;

namespace YGOProDevelop.ViewModel {
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class IDInputViewModel : DialogViewModel {
        private ICDBService _cdbService;

        /// <summary>
        /// Initializes a new instance of the IDInputViewModel class.
        /// </summary>
        public IDInputViewModel(ICDBService cdbService) {
            _cdbService = cdbService;
        }

        private long id=0;

        public long Id {
            get {
                return id;
            }

            set {
                id = value;RaisePropertyChanged();SubmitCmd.RaiseCanExecuteChanged();
            }
        }

        protected override bool CanSubmit() {
            return !_cdbService.IsIDExisted(id);
        }

        private RelayCommand _randomIDCmd;

        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public RelayCommand RandomIDCmd {
            get {
                return _randomIDCmd
                    ?? (_randomIDCmd = new RelayCommand(
                    () => {
                        Random rand = new Random();
                        do {
                            Id = rand.Next(0, int.MaxValue);
                        } while (_cdbService.IsIDExisted(id));
                    }));
            }
        }
    }
}