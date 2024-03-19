using Assets._Game_.Services.UI_Service.Views.UiView;
using UnityEngine;
using UnityEngine.UI;

namespace WKosArch.UIService.Views.Windows
{
    public abstract class Window<TWindowViewModel> : UiView<TWindowViewModel>, IWindow<TWindowViewModel>, IWindow
        where TWindowViewModel : WindowViewModel
    {
        [Space]
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _backButton;

        public override void Subscribe()
        {
            base.Subscribe();
            _closeButton?.onClick.AddListener(ViewModel.Close);
            _backButton?.onClick.AddListener(ViewModel.Back);
        }

        public override void Unsubscribe()
        {
            base.Unsubscribe();
            _closeButton?.onClick.RemoveListener(ViewModel.Close);
            _backButton?.onClick.RemoveListener(ViewModel.Back);
        }
    }
}