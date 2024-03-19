namespace WKosArch.UIService.Views
{
    public interface IView<out TViewModel> : IView where TViewModel : ViewModel
    {
    }

    public interface IView
    {
        bool IsActive { get; }
        void Refresh();
        void Subscribe();
        void Unsubscribe();
    }
}