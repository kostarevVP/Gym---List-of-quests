using Assets._Game_.Services.UI_Service.Views.UiView;

namespace WKosArch.UIService.Views.HUD
{
    public interface IHud<out THudViewModel> : IHud, IView<THudViewModel>
    where THudViewModel : HudViewModel
    { }

    public interface IHud : IUiView
    {

    }
}