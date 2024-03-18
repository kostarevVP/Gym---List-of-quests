using Assets._Game_.Services.UI_Service.Views.UiView;
using Assets.LocalPackages.WKosArch.Scripts.Common.DIContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using WKosArch.Extentions;
using WKosArch.Services.UIService;
using WKosArch.Services.UIService.Common;
using WKosArch.Services.UIService.UI;
using WKosArch.UIService.Views;
using WKosArch.UIService.Views.HUD;
using WKosArch.UIService.Views.Widgets;
using WKosArch.UIService.Views.Windows;

namespace Assets._Game_.Services.UI_Service.Implementation
{
    public class UserInterfaceFactory : MonoBehaviour, IUserInterfaceFactory
    {
        private const string PrefabPath = "[INTERFACE]";

        public Dictionary<Type, UiViewModel> UiViewModelsCache => _createdUiViewModelsCache;


        [SerializeField] private UILayerContainer[] _containers;

        private static UserInterfaceFactory _instance;

        private Dictionary<Type, UiViewModel> _createdUiViewModelsCache = new();
        private Dictionary<Type, WidgetViewModel> _createdWidgetViewModelsCache = new();

        private IDIContainer _diContainer;
        private IUserInterface _ui;

        private UISceneConfig _uiSceneConfig;

        public void Construct(IDIContainer dIContainer, IUserInterface ui)
        {
            _diContainer = dIContainer;
            _ui = ui;
        }

        public static UserInterfaceFactory CreateInstance()
        {
            if (_instance != null)
            {
                Debug.LogWarning($"UserInterface CreateInstance _instance = {_instance}");
                return _instance;
            }

            var prefab = Resources.Load<UserInterfaceFactory>(PrefabPath);
            _instance = Instantiate(prefab);
            DontDestroyOnLoad(_instance);

            return _instance;
        }

        public void Build(UISceneConfig config)
        {
            _uiSceneConfig = config;

            DestroyOldWindows();
            CreateNewUiViews();
        }

        public TUiViewModel ShowUiView<TUiViewModel>() where TUiViewModel : UiViewModel
        {
            Type uiViewModelType = typeof(TUiViewModel);

            return ShowUiView<TUiViewModel>(uiViewModelType);
        }

        public TUiViewModel ShowUiView<TUiViewModel>(Type uiViewModelType) where TUiViewModel : UiViewModel
        {
            TUiViewModel uiViewModel = null;

            if (_createdUiViewModelsCache.TryGetValue(uiViewModelType, out var viewModel))
            {
                uiViewModel = viewModel as TUiViewModel;
            }
            else
            {
                uiViewModel = CreateUiViewModel<TUiViewModel>(uiViewModelType);
            }

            ActivateWindowViewModel(uiViewModel);

            return uiViewModel;
        }

        public TWidgetViewModel ShowWidgetView<TWidgetViewModel>(Type widgetModelType, Transform root) where TWidgetViewModel : WidgetViewModel
        {
            TWidgetViewModel widgetViewModel = null;

            if (_createdWidgetViewModelsCache.TryGetValue(widgetModelType, out var viewModel))
            {
                if (!viewModel.gameObject.IsUnityNull())
                {
                    widgetViewModel = viewModel as TWidgetViewModel;
                }
                else
                {
                    widgetViewModel = CreateWidgetViewModel<TWidgetViewModel>(widgetModelType, root);
                }
            }
            else
            {
                widgetViewModel = CreateWidgetViewModel<TWidgetViewModel>(widgetModelType, root);
            }

            return widgetViewModel;
        }

        private TUiViewModel CreateWidgetViewModel<TUiViewModel>(Type typeViewModel, Transform root) where TUiViewModel : WidgetViewModel
        {
            TUiViewModel prefabWidgetViewModel = null;

            if (_uiSceneConfig.TryGetWidgetPrefab(typeViewModel, out TUiViewModel prefab))
            {
                if (prefab == null)
                {
                    Log.PrintWarning($"Couldn't open window ({typeViewModel}). Maybe its not add to UISceneConfig for this Scene");
                }
                else
                {
                    prefabWidgetViewModel = Instantiate(prefab, root);
                    prefabWidgetViewModel.InjectDI(_diContainer);

                    if (prefabWidgetViewModel.IsSingleInstance)
                    {
                        _createdWidgetViewModelsCache[typeViewModel] = prefabWidgetViewModel;
                    }
                }
            }

            return prefabWidgetViewModel;
        }


        private TUiViewModel CreateUiViewModel<TUiViewModel>(TUiViewModel uiViewModel) where TUiViewModel : UiViewModel
        {
            Type uiViewModelType = uiViewModel.GetType();

            return CreateUiViewModel<TUiViewModel>(uiViewModelType);
        }

        private TUiViewModel CreateUiViewModel<TUiViewModel>(Type typeViewModel) where TUiViewModel : UiViewModel
        {
            TUiViewModel prefabUiViewModel = null;

            if (_uiSceneConfig.TryGetPrefab(typeViewModel, out TUiViewModel prefab))
            {
                if (prefab == null)
                {
                    Log.PrintWarning($"Couldn't open window ({typeViewModel}). Maybe its not add to UISceneConfig for this Scene");
                }
                else
                {
                    var containerLayer = GetLayerContainer(prefab.WindowSettings.TargetLayer);
                    prefabUiViewModel = Instantiate(prefab, containerLayer);
                    prefabUiViewModel.InjectDI(_diContainer);

                    _createdUiViewModelsCache[typeViewModel] = prefabUiViewModel;
                }
            }

            return prefabUiViewModel;
        }

        private void ActivateWindowViewModel(UiViewModel uiViewModel)
        {
            if (!uiViewModel.UiView.IsShown)
            {
                uiViewModel.Subscribe();

                var uiView = uiViewModel.UiView;

                uiView.Show();
                uiView.Hidden += OnWindowHidden;
                uiView.Destroyed += OnWindowDestroyed;
            }

            uiViewModel.Refresh();
        }

        private void OnWindowHidden(UiViewModel uiViewModel)
        {
            uiViewModel.Unsubscribe();
        }

        private void OnWindowDestroyed(UiViewModel uiViewModel)
        {
            OnWindowHidden(uiViewModel);

            _createdUiViewModelsCache.Remove(uiViewModel.GetType());
        }

        private Transform GetLayerContainer(UILayer layer)
        {
            return _containers.FirstOrDefault(container => container.layer == layer)?.transform;
        }

        private void DestroyOldWindows()
        {
            foreach (var createdWindowViewModelItem in _createdUiViewModelsCache)
            {
                Destroy(createdWindowViewModelItem.Value.gameObject);
            }

            _createdUiViewModelsCache.Clear();
            _createdWidgetViewModelsCache.Clear();
        }

        private void CreateNewUiViews()
        {

            WindowViewModel[] windowPrefabsForCreating = _uiSceneConfig.WindowPrefabs;
            HudViewModel[] hudPrefabsForCreating = _uiSceneConfig.HudPrefabs;
            WidgetViewModel[] widgetPrefabsForCreating = _uiSceneConfig.WidgetPrefabs;

            foreach (WindowViewModel prefab in windowPrefabsForCreating)
            {
                if (prefab.WindowSettings.IsPreCached)
                {
                    AddToUiViewModelToCash(prefab);
                }
            }

            foreach (HudViewModel prefab in hudPrefabsForCreating)
            {
                if (prefab.WindowSettings.IsPreCached)
                {
                    AddToUiViewModelToCash(prefab);
                }
            }

        }

        private TUiViewModel AddToUiViewModelToCash<TUiViewModel>(TUiViewModel uiViewModel) where TUiViewModel : UiViewModel
        {
            var viewModel = CreateUiViewModel(uiViewModel);

            HideUiViewModelInstantly(viewModel);

            if (viewModel.WindowSettings.OpenWhenCreated)
            {
                var type = viewModel.GetType();
                _ui.Show<TUiViewModel>(type);
            }

            return viewModel;
        }

        private static void HideUiViewModelInstantly<TUiViewModel>(TUiViewModel prefabUiViewModel) where TUiViewModel : ViewModel
        {
            if (prefabUiViewModel is WindowViewModel)
            {
                var windowViewModel = prefabUiViewModel as WindowViewModel;
                windowViewModel.Window.HideInstantly();
            }
            if (prefabUiViewModel is HudViewModel)
            {
                var windowViewModel = prefabUiViewModel as HudViewModel;
                windowViewModel.Hud.HideInstantly();
            }
        }

    }
}
