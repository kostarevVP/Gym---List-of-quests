using Assets.Game.Services.ProgressService.api;
using WKosArch.Services.StaticDataServices;

namespace WKosArch.Features.LoadProgressFeature
{
    public class LoadProgressFeature : ILoadProgressFeature
    {
        public bool IsReady => _isReady;

        private readonly IProgressService _progressService;
        private readonly ISaveLoadService _saveLoadService;
        private readonly IStaticDataService _staticDataService;

        private bool _isReady;

        public LoadProgressFeature(IProgressService progressService, ISaveLoadService saveLoadService, IStaticDataService staticDataService)
        {
            _progressService = progressService;
            _saveLoadService = saveLoadService;
            _staticDataService = staticDataService;

            _isReady = true;
        }

        public void LoadProgressOrInitNew() =>
            _progressService.Progress = _saveLoadService.LoadProgress() ?? NewProgress();

        private GameProgress NewProgress()
        {
            var progress = new GameProgress();

            progress.SceneIndex = _staticDataService.GameProgressConfig.SceneIndex;

            return progress;
        }
    } 
}
