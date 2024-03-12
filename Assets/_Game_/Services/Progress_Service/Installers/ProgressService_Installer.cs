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
        private IProgressService _service;

        public override IFeature Create(IDIContainer container)
        {
            _service = new ProgressService();

            container.Bind(_service);

            Log.PrintColor($"[IProgressService] Create and Bind", Color.cyan);
            return _service;
        }

        public override void Dispose() { }
    }
}