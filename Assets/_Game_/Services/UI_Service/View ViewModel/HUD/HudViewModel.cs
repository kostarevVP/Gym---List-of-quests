using Assets._Game_.Services.UI_Service.Views.UiView;

namespace WKosArch.UIService.Views.HUD
{
    public class HudViewModel : UiViewModel
    {
        public IHud Hud
        {
            get
            {
                if (_hud == null)
                {
                    _hud = (IHud)View;
                }

                return _hud;
            }
        }

        private IHud _hud;
    }
}