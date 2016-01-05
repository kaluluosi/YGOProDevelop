


namespace YGOProDevelop.ViewModel {
    public abstract class ToolsViewModelBase:DockableViewModelBase {
        protected override void OnClose() {
            IsVisible = false;
        }
    }
}
