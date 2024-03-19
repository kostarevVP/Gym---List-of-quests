using Assets.LocalPackages.WKosArch.Scripts.Common.DIContainer;
using WKosArch.Domain.Contexts;
using WKosArch.Domain.Features;
using WKosArch.Extentions;
using UnityEngine;
using WKosArch.Services.StaticDataServices;


[CreateAssetMenu(fileName = "QuestFeature_Installer", menuName = "Game/Installers/QuestFeature_Installer")]
public class QuestFeature_Installer : FeatureInstaller
{
    public override IFeature Create(IDIContainer container)
    {
        var _staticDataService = container.Resolve<IStaticDataService>();
        var questsList = _staticDataService.QuestsList;

        var saveHolders = container.Resolve<ISaveLoadHandlerService>();

        IQuestFeature feature = new QuestFeature(questsList);

        saveHolders.AddSaveLoadHolders(feature);
        saveHolders.InformLoadHolders();

        BindFeature(container, feature);

        return feature;
    }

    public override void Dispose() 
    {
    }

    private void BindFeature(IDIContainer container, IQuestFeature feature)
    {
        container.Bind(feature);
        Log.PrintColor($"[QuestFeature_Installer] Create and Bind", Color.cyan);
    }
}
