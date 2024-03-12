using Assets.LocalPackages.WKosArch.Scripts.Common.DIContainer;
using WKosArch.Domain.Contexts;
using WKosArch.Domain.Features;
using WKosArch.Extentions;
using UnityEngine;

namespace WKosArch.Services.AnalyticService
{
    [CreateAssetMenu(fileName = "Analytic_Installer", menuName = "Game/Installers/Analytic_Installer")]
    public class Analytic_Installer : FeatureInstaller
    {
        private IAnalyticService _service;

        public override IFeature Create(IDIContainer container)
        {
            _service = new AnalyticLogService();

            container.Bind(_service);

            Log.PrintColor($"[IAnalyticService] Create and Bind", Color.cyan);
            return _service;
        }

        public override void Dispose() { }
    }
}