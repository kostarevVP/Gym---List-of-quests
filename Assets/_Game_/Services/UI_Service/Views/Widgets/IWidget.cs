using Assets._Game_.Services.UI_Service.Views.UiView;
using Cysharp.Threading.Tasks;
using System;

namespace WKosArch.UIService.Views.Widgets
{
    public interface IWidget : IView 
    {
        event Action<WidgetViewModel> Hidden;
        event Action<WidgetViewModel> Destroyed;

        bool IsShown { get; }

        UniTask<IWidget> Show();
        UniTask<IWidget> Hide(bool forced = false);
        IWidget HideInstantly();
    }

    public interface IWidget<TWidgetViewModel> : IView<TWidgetViewModel>, IWidget where TWidgetViewModel : WidgetViewModel 
    {

    }
}