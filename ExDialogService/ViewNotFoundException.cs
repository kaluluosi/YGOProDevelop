using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExDialogService
{
    public class ViewNotFoundException:Exception
    {
        public Type ViewModelType { get; set; }

        public ViewNotFoundException(Type viewModelType,string message):base(message) {
            ViewModelType = viewModelType;
        }
    }
}
