using Assets._Game_.Services.UI_Service.Views.UiView;

namespace WKosArch.UIService.Views.Windows
{
    public class WindowViewModel : UiViewModel
    {
        public IWindow Window
        {
            get
            {
                if (_window == null)
                {
                    _window = (IWindow)View;
                }

                return _window;
            }
        }

        private IWindow _window;

        public virtual void Back() => UI.Back();

        internal void Close() => UI.CloseAllWindowInStack();
    }
}