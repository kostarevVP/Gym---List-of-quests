using Assets.Game.Services.ProgressService.api;
using WKosArch.Domain.Features;

public interface ISaveLoadHandlerService : IFeature
{
    void AddSaveLoadHolders(ILoadProgress loadHolders);
    void InformLoadHolders();
    void InformSaveHolders();
    void Clear();
}