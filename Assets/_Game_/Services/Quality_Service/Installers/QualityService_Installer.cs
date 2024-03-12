using Assets.LocalPackages.WKosArch.Scripts.Common.DIContainer;
using UnityEngine;
using WKosArch.Domain.Contexts;
using WKosArch.Domain.Features;
using WKosArch.Extentions;
using WKosArch.Services.StaticDataServices;

[CreateAssetMenu(fileName = "QualityService_Installer", menuName = "Game/Installers/QualityService_Installer  ")]

public class QualityService_Installer : FeatureInstaller
{
    [SerializeField] private int _targetFPS = 30;

    private IQualityService _qualityService;
    public override IFeature Create(IDIContainer container)
    {
        var _staticDataService = container.Resolve<IStaticDataService>();

        _qualityService = new QualityService(_staticDataService.RenderQualityConfigMap);

        container.Bind(_qualityService);

        Log.PrintColor($"[IQualityService] Create and Bind", Color.cyan);

        _qualityService.SetFPSLimit(_targetFPS);

        return _qualityService;
    }

    public override void Dispose()
    {
        
    }
}
