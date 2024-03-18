using Assets.Game.Services.ProgressService.api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadHandlerService 
{
    private List<ILoadProgress> _loadHolders;
    private List<ISavedProgress> _saveHolders;

    public void AddLoadHolders(ILoadProgress loadHolders)
    {
        if (loadHolders is ISavedProgress)
            _saveHolders.Add(loadHolders as ISavedProgress);
        _loadHolders.Add(loadHolders);
    }
}
