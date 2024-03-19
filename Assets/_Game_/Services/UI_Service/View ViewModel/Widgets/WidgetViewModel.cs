using UnityEngine;
using WKosArch.Services.UIService.UI;

namespace WKosArch.UIService.Views.Widgets
{
    public class WidgetViewModel : ViewModel
    {
        [Tooltip("If enabled you have to call Refresh() method manually for refreshing widget. If not - it calls automatically from the OnEnable() method")]
        [SerializeField] private bool _manualRefreshing;
        [Tooltip("If enabled you have to call Subscribe() and Unsubscribe methods manually. If not - it calls automatically from the OnEnable() and OnDisable() methods")]
        [SerializeField] private bool _manualSubscription;

        public bool IsSingleInstance;

        public IWidget Widget
        {
            get
            {
                if (_widget == null)
                {
                    _widget = (IWidget)View;
                }

                return _widget;
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

        private IWidget _widget;
        private IUserInterface _userInterface;

        private void OnEnable()
        {
            Subscribe();
        }
        private void OnDisable()
        {
            Unsubscribe();
        }
    }
}