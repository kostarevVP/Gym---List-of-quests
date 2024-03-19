using Cysharp.Threading.Tasks;
using UnityEngine;
using WKosArch.Extentions;
using WKosArch.Services.Scenes;
using WKosArch.Services.UIService;
using WKosArch.Services.UIService.UI;

namespace WKosArch.Features.LoadLevelFeature
{
    public class LoadLevelFeature : ILoadLevelFeature
    {
        public bool IsReady => _isReady;

        private ISceneManagementService _sceneManagementService;
        private IUserInterface _ui;
        private bool _isReady;



        public LoadLevelFeature(ISceneManagementService sceneManagementService, IUserInterface ui)
        {
            _sceneManagementService = sceneManagementService;
            _ui = ui;
        }

        public UniTask InitializeAsync()
        {
            Subscribe();
            _isReady = true;
            return UniTask.CompletedTask;
        }

        public UniTask DestroyAsync()
        {
            Unsubscribe();
            return UniTask.CompletedTask;
        }

        private void Subscribe()
        {
            _sceneManagementService.OnSceneLoaded += SceneLoaded;
            _sceneManagementService.OnSceneStarted += SceneStarted;
        }

        private void Unsubscribe()
        {
            _sceneManagementService.OnSceneLoaded -= SceneLoaded;
            _sceneManagementService.OnSceneStarted -= SceneStarted;
        }

        private void SceneLoaded(string sceneName)
        {
            LoadGameLevelEnviroment();
            SceneReadyToStart();
        }

        private void SceneStarted(string sceneName)
        {
            PlayStartLevelAnimation();
        }

        public void LoadGameLevelEnviroment()
        {
            //in this point load player and all environment
            Log.PrintYellow("Load environment");
            //_ui.Show<QuestWindowModel>();
        }

        public void PlayStartLevelAnimation()
        {
            Log.PrintYellow("Play Start animation");
        }

        public void SceneReadyToStart()
        {
            _sceneManagementService.SceneReadyToStart = true;
        }
    }
}