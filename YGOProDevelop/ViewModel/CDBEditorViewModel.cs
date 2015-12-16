using GalaSoft.MvvmLight;
using YGOProDevelop.CDBEditor.CDB;
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
        }


        private CDBManager cdbMgr = CDBManager.Instance;

        public CDBEditor.CDB.CDBManager CdbMgr {
            get { return cdbMgr; }
            set { cdbMgr = value; RaisePropertyChanged(()=>CdbMgr); }
        }
        

    }
}