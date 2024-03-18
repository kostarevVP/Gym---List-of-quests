using Assets.Game.Services.ProgressService.api;
using System.Collections.Generic;

public class SaveLoadHandlerService : ISaveLoadHandlerService
{
    public bool IsReady => _isReady;

    private bool _isReady;
    private List<ILoadProgress> _loadHolders = new();
    private List<ISavedProgress> _saveHolders = new();
    private readonly IProgressService _progressService;

    public SaveLoadHandlerService(IProgressService progressService)
    {
        _isReady = true;
        _progressService = progressService;
    }

    public void AddLoadHolders(ILoadProgress loadHolders)
    {
        if (loadHolders is ISavedProgress)
            _saveHolders.Add(loadHolders as ISavedProgress);
        else
            _loadHolders.Add(loadHolders);
    }

    public void InformSaveHolders()
    {
        var progress = _progressService.Progress;

        foreach (var holder in _saveHolders)
        {
            holder.SaveProgress(progress);
            holder.LoadProgress(progress);
        }
    }

    public void InformLoadHolders()
    {
        var progress = _progressService.Progress;

        foreach (var holder in _loadHolders)
        {
            holder.LoadProgress(progress);
        }
    }

    public void Clear()
    {
        _loadHolders.Clear();
        _saveHolders.Clear();
    }
}
