using Cysharp.Threading.Tasks;
using WKosArch.Domain.Features;

public interface ILoadProgressFeature : IFeature
{
    void LoadProgressOrInitNew();
}