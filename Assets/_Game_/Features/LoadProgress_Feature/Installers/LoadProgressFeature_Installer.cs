using Assets.Game.Services.ProgressService.api;
using WKosArch.Domain.Contexts;
using WKosArch.Domain.Features;
using WKosArch.Extentions;
using WKosArch.Services.Scenes;
using UnityEngine;
using Assets.LocalPackages.WKosArch.Scripts.Common.DIContainer;
using WKosArch.Services.StaticDataServices;

namespace WKosArch.Features.LoadProgressFeature
{
    [CreateAssetMenu(fileName = "LoadProgressFeature_Installer", menuName = "Game/Installers/LoadProgressFeature_Installer")]
    public class LoadProgressFeature_Installer : FeatureInstaller
    {
        private ILoadProgressFeature _feature;
        public override IFeature Create(IDIContainer container)
        {
            var progressService = container.Resolve<IProgressService>();
            var saveLoadService = container.Resolve<ISaveLoadService>();
            var staticDataService = container.Resolve<IStaticDataService>();
            var sceneManagementService = container.Resolve<ISceneManagementService>();

            _feature = new LoadProgressFeature(progressService, saveLoadService, staticDataService);

            _feature.LoadProgressOrInitNew();


            container.Bind(_feature);

            Log.PrintColor($"[ILoadProgressFeature] Create and Bind", Color.cyan);

            sceneManagementService.LoadScene(progressService.Progress.SceneIndex);

            return _feature;
        }

        public override void Dispose() { }
    } 
}
