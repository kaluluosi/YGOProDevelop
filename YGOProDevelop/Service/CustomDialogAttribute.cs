using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YGOProDevelop.Service
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class CustomDialogAttribute:Attribute
    {
        public CustomDialogAttribute(Type viewModel, Type view) {
            CustomDialogService.Regist(viewModel, view);
        }

    }
}
