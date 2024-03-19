using Assets.Game.Services.ProgressService.api;
using System.Collections.Generic;

public class SaveLoadHandlerService : ISaveLoadHandlerService
{
    public bool IsReady => _isReady;

    private bool _isReady;
    private List<ILoadProgress> _loadHolders = new();
    private List<ISavedProgress> _saveHolders = new();
    private readonly IProgressService _progressService;
    private readonly ISaveLoadService _saveLoadService;

    public SaveLoadHandlerService(IProgressService progressService, ISaveLoadService saveLoadService)
    {
        _isReady = true;
        _progressService = progressService;
        _saveLoadService = saveLoadService;

        _saveLoadService.OnSaveStarted += InformSaveHolders;
    }

    public void AddSaveLoadHolders(ILoadProgress loadHolders)
    {
        //if (loadHolders is ISavedProgress)
        //    _saveHolders.Add(_saveHolders as ISavedProgress);

        _loadHolders.Add(loadHolders);
    }

    public void InformSaveHolders()
    {
        var progress = _progressService.Progress;

        foreach (var holder in _loadHolders)
        {
            if(holder is ISavedProgress saveHolder)
                saveHolder.SaveProgress(progress);
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
