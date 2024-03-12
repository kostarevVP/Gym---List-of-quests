using WKosArch.Domain.Contexts;
using WKosArch.Domain.Features;
using WKosArch.Extentions;
using UnityEngine;
using Assets.LocalPackages.WKosArch.Scripts.Common.DIContainer;

namespace WKosArch.Services.StaticDataServices
{
    [CreateAssetMenu(fileName = "StaticDataService_Installer", menuName = "Game/Installers/StaticDataService_Installer")]
    public class StaticDataService_Installer : FeatureInstaller
    {
        private IStaticDataService _feature;
        public override IFeature Create(IDIContainer container)
        {
            var assetProviderService = container.Resolve<IAssetProviderService>();

            _feature = new StaticDataService(assetProviderService);

            container.Bind(_feature);

            Log.PrintColor($"[IStaticDataService] Create and Bind", Color.cyan);
            return _feature;
        }

        public override void Dispose() { }
    } 
}
