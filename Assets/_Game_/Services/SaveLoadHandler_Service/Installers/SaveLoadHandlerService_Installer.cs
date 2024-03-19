using Assets.LocalPackages.WKosArch.Scripts.Common.DIContainer;
using WKosArch.Domain.Contexts;
using WKosArch.Domain.Features;
using WKosArch.Extentions;
using UnityEngine;
using Assets.Game.Services.ProgressService.api;


[CreateAssetMenu(fileName = " SaveLoadHandlerService_Installer", menuName = "Game/Installers/SaveLoadHandlerService_Installer")]
public class SaveLoadHandlerService_Installer : FeatureInstaller
{
    private ISaveLoadHandlerService _feature;

    public override IFeature Create(IDIContainer container)
    {
        IProgressService progressService = container.Resolve<IProgressService>();
        ISaveLoadService saveLoadService = container.Resolve<ISaveLoadService>();

        _feature = new SaveLoadHandlerService(progressService, saveLoadService);

        BindFeature(container, _feature);

        return _feature;
    }

    public override void Dispose() 
    {
        _feature.Clear();
    }

    private void BindFeature(IDIContainer container, ISaveLoadHandlerService feature)
    {
        container.Bind(feature);
        Log.PrintColor($"[SaveLoadHandlerService_Installer] Create and Bind", Color.cyan);
    }
}
