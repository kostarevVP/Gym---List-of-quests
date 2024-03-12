using WKosArch.Domain.Features;
using WKosArch.Services.Scenes;

namespace WKosArch.Features.LoadLevelFeature
{
	public interface ILoadLevelFeature : IAsyncFeature
    {
		void LoadGameLevelEnviroment();
        void PlayStartLevelAnimation();
        void SceneReadyToStart();
    } 
}