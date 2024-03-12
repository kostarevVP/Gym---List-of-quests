using Assets.Game.Services.ProgressService.api;
using Assets.LocalPackages.WKosArch.Scripts.Common.DIContainer;
using WKosArch.Domain.Contexts;
using WKosArch.Domain.Features;
using WKosArch.Extentions;
using UnityEngine;

namespace WKosArch.Services.ProgressService
{
    [CreateAssetMenu(fileName = "ProgressService_Installer", menuName = "Game/Installers/ProgressService_Installer")]
    public class ProgressService_Installer : FeatureInstaller
    {
        public override IFeature Create(IDIContainer container)
        {
            IProgressService service = new ProgressService();

            BindFeature(container, service);

            return service;
        }

        public override void Dispose() { }

        private void BindFeature(IDIContainer container, IProgressService feature)
        {
            container.Bind(feature);
            Log.PrintColor($"[IProgressService] Create and Bind", Color.cyan);
        }
    }
}