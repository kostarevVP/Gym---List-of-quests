using Cysharp.Threading.Tasks;

namespace WKosArch.Domain.Features
{
    public interface IFeature
    {
        bool IsReady { get; }
    }

    public interface IAsyncFeature : IFeature
    {
        UniTask InitializeAsync();
        UniTask DestroyAsync();
    }

    public interface IFocusPauseFeature : IFeature
    {
        void OnApplicationFocus(bool hasFocus);
        void OnApplicationPause(bool pauseStatus);
    }
}