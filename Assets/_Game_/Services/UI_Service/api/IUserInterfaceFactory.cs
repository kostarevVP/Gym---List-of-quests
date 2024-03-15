using Assets._Game_.Services.UI_Service.Views.UiView;
using Assets.LocalPackages.WKosArch.Scripts.Common.DIContainer;
using System;
using System.Collections.Generic;
using UnityEngine;
using WKosArch.Services.UIService;
using WKosArch.Services.UIService.UI;
using WKosArch.UIService.Views.Widgets;

namespace Assets._Game_.Services.UI_Service.Implementation
{
    public interface IUserInterfaceFactory
    {
        Dictionary<Type, UiViewModel> UiViewModelsCache { get; }

        void Build(UISceneConfig config);
        void Construct(IDIContainer dIContainer, IUserInterface userInterface);
        TUiViewModel ShowUiView<TUiViewModel>() where TUiViewModel : UiViewModel;
        TUiViewModel ShowUiView<TUiViewModel>(Type uiViewModelType) where TUiViewModel : UiViewModel;
        TWidgetViewModel ShowWidgetView<TWidgetViewModel>(Type widgetModelType, Transform root) where TWidgetViewModel : WidgetViewModel;

    }
}