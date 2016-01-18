using System;
using GalaSoft.MvvmLight;
using System.Threading.Tasks;

namespace ExDialogService
{
    public interface IExDialogService
    {
        /// <summary>
        /// 显示独立非模态对话框。阻塞的。
        /// 阻塞的。
        /// </summary>
        /// <param name="vm"></param>
        void Show(IDialogViewModel vm);
        /// <summary>
        /// 显示非模态对话框并设置父窗口，当父窗口关闭后对话框也会关闭。阻塞的。
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="vm"></param>
        void Show(object parentVM, IDialogViewModel vm);

        IDialogViewModel Show<T>() where T : IDialogViewModel;
        IDialogViewModel Show<T>(object parentVM) where T : IDialogViewModel;

        /// <summary>
        /// 显示模态对话框。
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        bool? ShowDialog(IDialogViewModel vm);
        /// <summary>
        /// 显示模态对话框并设置父窗口，父窗口关闭后对话框也会关闭。阻塞的。
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="vm"></param>
        /// <returns></returns>
        bool? ShowDialog(object parentVM, IDialogViewModel vm);

        IDialogViewModel ShowDialog<T>() where T : IDialogViewModel;
        IDialogViewModel ShowDialog<T>(object parentVM) where T : IDialogViewModel;

//         /// <summary>
//         /// 显示独立非模态对话框。异步的。
//         /// 阻塞的。
//         /// </summary>
//         /// <param name="vm"></param>
//         Task ShowAsync(IDialogViewModel vm);
//         /// <summary>
//         /// 显示非模态对话框并设置父窗口，当父窗口关闭后对话框也会关闭。异步的。
//         /// </summary>
//         /// <param name="parent"></param>
//         /// <param name="vm"></param>
//         Task ShowAsync(ViewModelBase parent, IDialogViewModel vm);
//         /// <summary>
//         /// 显示模态对话框并设置父窗口，父窗口关闭后对话框也会关闭。异步的。
//         /// </summary>
//         /// <param name="parent"></param>
//         /// <param name="vm"></param>
//         /// <returns></returns>
//         Task<bool?> ShowDialogAsync(IDialogViewModel vm);
//         /// <summary>
//         /// 显示模态对话框并设置父窗口，父窗口关闭后对话框也会关闭。异步的。
//         /// </summary>
//         /// <param name="parent"></param>
//         /// <param name="vm"></param>
//         /// <returns></returns>
//         Task<bool?> ShowDialogAsync(ViewModelBase parent, IDialogViewModel vm);

    }
}
