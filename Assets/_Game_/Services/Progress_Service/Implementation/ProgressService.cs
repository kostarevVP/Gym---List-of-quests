using Assets.Game.Services.ProgressService.api;
using Cysharp.Threading.Tasks;

namespace WKosArch.Services.ProgressService
{
    public class ProgressService : IProgressService
    {
        private bool _isReady = true;

        public GameProgress Progress { get; set; }

        public bool IsReady => _isReady;

        public UniTask DestroyAsync()
        {
           return UniTask.CompletedTask;
        }

        public UniTask InitializeAsync()
        {
            return UniTask.CompletedTask;
        }

        public void OnApplicationFocus(bool hasFocus) { }

        public void OnApplicationPause(bool pauseStatus) { }
    }
}