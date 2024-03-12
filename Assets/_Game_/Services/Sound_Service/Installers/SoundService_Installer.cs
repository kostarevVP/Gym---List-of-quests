using WKosArch.Domain.Contexts;
using WKosArch.Domain.Features;
using WKosArch.Extentions;
using UnityEngine;
using Assets.LocalPackages.WKosArch.Scripts.Common.DIContainer;

namespace WKosArch.Services.SoundService
{
    [CreateAssetMenu(fileName = "SoundService_Installer", menuName = "Game/Installers/SoundService_Installer")]
    public class SoundService_Installer : FeatureInstaller
    {
        private ISoundService _service;

        public override IFeature Create(IDIContainer container)
        {
            _service = new SoundService();

            container.Bind(_service);

            Log.PrintColor($"[ISoundService] Create and Bind", Color.cyan);
            return _service;
        }

        public override void Dispose()
        {

        }
    }
}