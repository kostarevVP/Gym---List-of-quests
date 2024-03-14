using Assets._Game_.Services.UI_Service.Views.UiView;
using System;
using UnityEngine;
using WKosArch.UIService.Views.Widgets;

namespace WKosArch.Services.UIService.UI
{
    public interface IUserInterface
    {
        void Show<TWindowViewModel>(bool hideWindow = true) where TWindowViewModel : UiViewModel;
        void Show<TWindowViewModel>(Type uiViewModelType, bool hideWindow = true) where TWindowViewModel : UiViewModel;
        TWidgetViewModel ShowWidget<TWidgetViewModel>(Transform root) where TWidgetViewModel : WidgetViewModel;
        
        void Back(bool hideCurrentWindow = true, bool forced = false);
        void CloseAllWindowInStack();
        void Build(UISceneConfig config);
    }
}