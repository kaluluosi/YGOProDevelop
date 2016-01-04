using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YGOProDevelop.ViewModel {
    public abstract class ToolsViewModelBase:DockableViewModelBase {
        protected override void OnClose() {
            IsVisible = false;
        }
    }
}
