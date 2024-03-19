using Cysharp.Threading.Tasks;
using System;
using WKosArch.UIService.Views;

namespace Assets._Game_.Services.UI_Service.Views.UiView
{
    public interface IUiView<out TUiViewModel> : IUiView, IView<TUiViewModel>
    where TUiViewModel : UiViewModel
    {
    }

    public interface IUiView : IView
    {
        event Action<UiViewModel> Hidden;
        event Action<UiViewModel> Destroyed;

        bool IsShown { get; }

        UniTask<IUiView> Show();
        UniTask<IUiView> Hide(bool forced = false);
        IUiView HideInstantly();
    }
}
