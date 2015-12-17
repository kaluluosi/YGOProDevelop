using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YGOProDevelop.View;
using YGOProDevelop.ViewModel;

namespace YGOProDevelop.Service
{
    public class CustomDialogRigister
    {
        public CustomDialogRigister() {

            ViewManager.Register<CDBEditorViewModel, CDBEditorView>();

        }
    }
}
