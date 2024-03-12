using WKosArch.Domain.Features;

namespace Assets.Game.Services.ProgressService.api
{
    public interface IProgressService : IFeature
    {
        GameProgress Progress { get; set; }
    }
}