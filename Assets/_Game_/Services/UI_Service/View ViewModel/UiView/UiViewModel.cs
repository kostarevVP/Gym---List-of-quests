using UnityEngine;
using WKosArch.Services.UIService.UI;
using WKosArch.UIService.Views;
using WKosArch.UIService.Views.Windows;

namespace Assets._Game_.Services.UI_Service.Views.UiView
{
    public class UiViewModel : ViewModel
    {
        public WindowSettings WindowSettings => _windowSettings;
        public IUiView UiView
        {
            get
            {
                if (_uiView == null)
                {
                    _uiView = (IUiView)View;
                }

                return _uiView;
            }
        }

        public IUserInterface UI
        {
            get
            {
                if (_userInterface == null)
                {
                    _userInterface = DiContainer.Resolve<IUserInterface>();
                }

                return _userInterface;
            }
        }

        [SerializeField] private WindowSettings _windowSettings;

        private IUiView _uiView;
        private IUserInterface _userInterface;
    }
}
