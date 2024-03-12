using System.Collections.Generic;
using WKosArch.Extentions;
using WKosArch.Services.StaticDataServices;

public class QuestFeature : IQuestFeature
{
    public bool IsReady => _isReady;
    public List<ICollectionQuest> CollectionQuests => _collectingQuests;
    public List<IJourneyQuest> JourneyQuests => _journeyQuests;


    private bool _isReady;

    private IStaticDataService _staticDataService;

    private List<ICollectionQuest> _collectingQuests;
    private List<IJourneyQuest> _journeyQuests;

    public QuestFeature(IStaticDataService staticDataService)
    {
        _staticDataService = staticDataService;

        Init();
    }


    private void Init()
    {
        _collectingQuests = _staticDataService.ColectionQuests;
        _journeyQuests = _staticDataService.JourneyQuests;
    }


    private void PrintLog()
    {
        foreach (var quest in _collectingQuests)
        {
            Log.PrintYellow(quest.ToString());
        }

        foreach (var quest in _journeyQuests)
        {
            Log.PrintYellow(quest.ToString());
        }
    }
}
