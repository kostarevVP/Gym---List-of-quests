using WKosArch.Domain.Features;

public interface ISaveLoadService : IFocusPauseFeature
{
    public GameProgress LoadProgress();
    public void SaveProgress();
}
