using Assets.Game.Services.ProgressService.api;

namespace WKosArch.Services.ProgressService
{
    public class ProgressService : IProgressService
    {
        private bool _isReady = true;

        public GameProgress Progress { get; set; }

        public bool IsReady => _isReady;
    }
}