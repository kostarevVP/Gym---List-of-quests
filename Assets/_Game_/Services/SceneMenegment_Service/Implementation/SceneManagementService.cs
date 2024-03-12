using Cysharp.Threading.Tasks;
using System;
using UnityEngine.SceneManagement;
using WKosArch.Domain.Contexts;

namespace WKosArch.Services.Scenes
{
    public class SceneManagementService : ISceneManagementService
    {
        public event Action<string> OnSceneLoadingStarted;
        public event Action<string> OnSceneChanged;
        public event Action<string> OnSceneUnloaded;
        public event Action<string> OnSceneLoaded;
        public event Action<string> OnSceneStarted;
        public event Action<SceneContext> OnContextLoaded;
        public event Action<SceneContext> OnContextUnLoad;
        public event Action<string> OnSceneReloadBegin;
        public bool SceneReadyToStart { get; set; }
        public bool IsReady => _isReady;
        public string CurrentSceneName => _currentSceneName;

        private string _currentSceneName => SceneManager.GetActiveScene().name;

        private ILoadingScreen _loadingScreen;
        private bool _isReady;


        public SceneManagementService(ILoadingScreen loadingScreen = null)
        {
            _loadingScreen = loadingScreen;

            SceneManager.sceneLoaded += (scene, _) =>
            {
                OnSceneLoaded?.Invoke(scene.name);
            };
            SceneManager.sceneUnloaded += scene =>
            {
                OnSceneUnloaded?.Invoke(scene.name);
            };

            _isReady = true;
        }

        public void LoadScene(string sceneName) => 
            LoadSceneAsync(sceneName);

        public void ReloadScene()
        {
            OnSceneReloadBegin?.Invoke(_currentSceneName);
            LoadScene(_currentSceneName);
        }

        public void OnContextLoadInvoke(SceneContext sceneContext)
        {
            OnContextLoaded?.Invoke(sceneContext);
        }

        public void OnContextUnLoadInvoke(SceneContext sceneContext)
        {
            OnContextUnLoad?.Invoke(sceneContext);
        }

        public void LoadScene(int sceneIndex)
        {
            var path = SceneUtility.GetScenePathByBuildIndex(sceneIndex);
            var lastSlash = path.LastIndexOf('/');
            var nameWithExtension = path.Substring(lastSlash + 1);
            var lastDot = nameWithExtension.LastIndexOf('.');
            var sceneName = nameWithExtension.Substring(0, lastDot);

            LoadScene(sceneName);
        }

        private async void LoadSceneAsync(string sceneName)
        {
            OnSceneLoadingStarted?.Invoke(sceneName);

            if (_loadingScreen != null)
            {
                await ShowAnimation(_loadingScreen.Show);
            }

            var async = SceneManager.LoadSceneAsync(sceneName);
            async.allowSceneActivation = false;

            while (async.progress < 0.9f)
            {
                await UniTask.Yield();
            }

            async.allowSceneActivation = true;

            OnSceneChanged?.Invoke(sceneName);

            while (!SceneReadyToStart)
            {
                await UniTask.Yield();
            }

            if (_loadingScreen != null)
            {
                await ShowAnimation(_loadingScreen.Hide);
            }

            OnSceneStarted?.Invoke(sceneName);
        }

        private static async UniTask ShowAnimation(Action<Action> method)
        {
            var isCompleted = false;

            void OnComplete()
            {
                isCompleted = true;
            }

            method(OnComplete);

            while (!isCompleted)
            {
                await UniTask.Yield();
            }
        }

        public void OnApplicationFocus(bool hasFocus) { }

        public void OnApplicationPause(bool pauseStatus) { }
    }
}