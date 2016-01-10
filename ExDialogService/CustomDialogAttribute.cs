using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExDialogService
{

    /// <summary>
    /// 自定义对话框属性，标记到对话框窗口类上来自动注册到ViewLocator。
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class CustomDialogAttribute:Attribute
    {
        public CustomDialogAttribute(Type viewModel, Type view) {
            ViewLocator.RegistDialog(viewModel, view);
        }

    }
}
