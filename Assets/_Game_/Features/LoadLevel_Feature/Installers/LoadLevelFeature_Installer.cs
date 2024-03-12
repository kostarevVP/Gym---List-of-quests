using Assets.LocalPackages.WKosArch.Scripts.Common.DIContainer;
using WKosArch.Domain.Contexts;
using WKosArch.Domain.Features;
using WKosArch.Extentions;
using WKosArch.Services.Scenes;
using UnityEngine;

namespace WKosArch.Features.LoadLevelFeature
{
    [CreateAssetMenu(fileName = "LoadLevelFeature_Installer", menuName = "Game/Installers/LoadLevelFeature_Installer")]
    public class LoadLevelFeature_Installer : FeatureInstaller
    {
        private ILoadLevelFeature _loadLevelFeature;

        public override IFeature Create(IDIContainer container)
        {
            var sceneManagementService = container.Resolve<ISceneManagementService>();

            _loadLevelFeature = new LoadLevelFeature(sceneManagementService);

            container.Bind(_loadLevelFeature);

            
            Log.PrintColor($"[ILoadLevelFeature] Create and Bind", Color.cyan);

            return _loadLevelFeature;
        }

        public override void Dispose() { }
    }
}
