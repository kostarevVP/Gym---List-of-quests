using System;
using WKosArch.Domain.Features;

public interface ISaveLoadService : IFocusPauseFeature
{
    event Action OnSaveStarted;
    public GameProgress LoadProgress();
    public void SaveProgress();
}
