using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YGOProDevelop.View;
using YGOProDevelop.ViewModel;
using GalaSoft.MvvmLight;
using YGOProDevelop.PanelTempalte;

namespace YGOProDevelop.Service
{
    public class PanelTemplateRegister
    {
        public PanelTemplateRegister() {

            PanelTemplateManager.Register<DocumentViewModel, DocumentView>();

        }
    }
}
