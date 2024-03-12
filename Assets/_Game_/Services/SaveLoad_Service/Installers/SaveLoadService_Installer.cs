using Assets.Game.Services.ProgressService.api;
using WKosArch.Domain.Contexts;
using WKosArch.Domain.Features;
using WKosArch.Extentions;
using UnityEngine;
using Assets.LocalPackages.WKosArch.Scripts.Common.DIContainer;

namespace WKosArch.Services.SaveLoadService
{
    [CreateAssetMenu(fileName = "SaveLoadService_Installer", menuName = "Game/Installers/SaveLoadService_Installer  ")]
    public class SaveLoadService_Installer : FeatureInstaller
    {
        private ISaveLoadService _service;
        public override IFeature Create(IDIContainer container)
        {
            var progressService = container.Resolve<IProgressService>();

            _service = new SaveLoadService(progressService);

            container.Bind(_service);

            Log.PrintColor($"[ISaveLoadService] Create and Bind", Color.cyan);
            return _service;
        }

        public override void Dispose() { }
    }
}
