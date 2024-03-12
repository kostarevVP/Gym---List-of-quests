using Assets._Game_.Services.UI_Service.Views.UiView;

namespace WKosArch.UIService.Views.HUD
{
    public abstract class Hud<THudViewModel> : UiView<THudViewModel>, IHud<THudViewModel>
         where THudViewModel : HudViewModel
    {

    }
}