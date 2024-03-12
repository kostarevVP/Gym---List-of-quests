using Assets.LocalPackages.WKosArch.Scripts.Common.DIContainer;
using System;
using WKosArch.Extentions;
using WKosArch.Services.Scenes;
using WKosArch.Services.StaticDataServices;
using WKosArch.Services.UIService.UI;

namespace WKosArch.Services.UIService
{
    public class UIService : IUIService, IDisposable
    {
        private readonly ISceneManagementService _sceneManagementService;
        private readonly IStaticDataService _staticDataService;

        public IUserInterface UI { get; private set; }
        public bool IsReady => _isReady;

        private bool _isReady;

        public UIService(IStaticDataService staticDataService, ISceneManagementService sceneManagementService,
            IDIContainer container)
        {
            _staticDataService = staticDataService;
            _sceneManagementService = sceneManagementService;

            UI = new UserInterface(container);

            _sceneManagementService.OnSceneLoaded += SceneLoaded;

            _isReady = true;
        }

        public void Dispose()
        {
            _sceneManagementService.OnSceneLoaded -= SceneLoaded;
        }

        private void SceneLoaded(string sceneName)
        {
            //SubScene from DOTS after open get same callBack SceneLoaded
            //Thats why there is TryGet before was like below
            //var config = _staticDataService.SceneConfigsMap[sceneName];
            if (_staticDataService.SceneConfigsMap.TryGetValue(sceneName, out var config))
            {
                UI.Build(config);
            }
            else
            {
                Log.PrintWarning($"Try to load for {sceneName} SceneConfig {config} in SceneConfigsMap result false");
            }
        }
    }
}