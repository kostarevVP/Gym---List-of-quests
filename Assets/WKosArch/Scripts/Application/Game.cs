using UnityEngine;
using Cysharp.Threading.Tasks;
using WKosArch.Common.DIContainer;
using WKosArch.Domain.Contexts;

namespace WKosArch.Application
{
    public static class Game
    {
        public static ProjectContext ProjectContext { get; set; }

        private static bool _iSsStarted { get; set; }

        private static bool _gameStarting { get; set; }

        public static async UniTask StartGameAsync(ProjectContext projectContext)
        {
            if (!_iSsStarted && !_gameStarting)
            {
                _gameStarting = true;

                ProjectContext = projectContext;

                DI.AddDIContainer(projectContext.Container);
                DI.Bind(projectContext);

                if (projectContext != null)
                {
                    await ProjectContext.InitializeAsync();
                }

                _iSsStarted = true;
                _gameStarting = false;
            }
        }


        //need for not Reload Domain each time
        // ProjectSetting > Editor > Enter Play Mode Setting
        [RuntimeInitializeOnLoadMethod]
        static void Init()
        {
            _gameStarting = false;
            _iSsStarted = false;
        }
    }
}