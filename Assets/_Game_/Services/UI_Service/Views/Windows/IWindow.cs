using Assets._Game_.Services.UI_Service.Views.UiView;
namespace WKosArch.UIService.Views.Windows
{
    public interface IWindow<out TWindowViewModel> : IWindow, IView<TWindowViewModel>
        where TWindowViewModel : WindowViewModel
    { }

    public interface IWindow : IUiView
    {

    }
}