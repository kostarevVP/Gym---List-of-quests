using Cysharp.Threading.Tasks;
using UnityEngine;
using WKosArch.Extentions;
using WKosArch.Services.Scenes;

namespace WKosArch.Features.LoadLevelFeature
{
    public class LoadLevelFeature : ILoadLevelFeature
    {
        public bool IsReady => _isReady;

        private ISceneManagementService _sceneManagementService;
        private bool _isReady;



        public LoadLevelFeature(ISceneManagementService sceneManagementService)
        {
            _sceneManagementService = sceneManagementService;
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