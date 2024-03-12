using WKosArch.Domain.Contexts;
using WKosArch.Domain.Features;
using WKosArch.Extentions;
using UnityEngine;
using Assets.LocalPackages.WKosArch.Scripts.Common.DIContainer;

namespace WKosArch.Services.AssetProviderService
{
    [CreateAssetMenu(fileName = "AssetProviderService_Installer", menuName = "Game/Installers/AssetProviderService_Installer")]
    public class AssetProviderService_Installer : FeatureInstaller
    {
        private IAssetProviderService _service;

        public override IFeature Create(IDIContainer container)
        {
            _service = new AssetProviderService();

            container.Bind(_service);

            Log.PrintColor($"[AssetProviderService] Create and Bind", Color.cyan);
            return _service;
        }

        public override void Dispose() { }
    } 
}
