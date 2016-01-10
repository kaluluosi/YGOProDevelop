using GalaSoft.MvvmLight;
using System;

namespace ExDialogService {
    /// <summary>
    /// View管理类
    /// 通过在XAML里面定义附加属性将View注册保存到_views里
    /// </summary>
    public class DefaultDialogService : IExDialogService {
        public void Show(DialogViewModelBase vm) {
            throw new NotImplementedException();
        }

        public void Show(ViewModelBase parent, DialogViewModelBase vm) {
            throw new NotImplementedException();
        }

        public bool? ShowDialog(DialogViewModelBase vm) {
            throw new NotImplementedException();
        }
    }
}
