
namespace Assets.Game.Services.ProgressService.api
{
    public interface ISavedProgress : ILoadProgress
    {
        public void SaveProgress(GameProgress progress);
    }

    public interface ILoadProgress
    {
        public void LoadProgress(GameProgress progress);
    }

}
