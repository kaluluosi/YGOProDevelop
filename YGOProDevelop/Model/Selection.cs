using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace YGOProDevelop.Model {
    public abstract class Selection:ObservableObject {

        public bool IsSelected {
            get; set;
        }

    }
}
