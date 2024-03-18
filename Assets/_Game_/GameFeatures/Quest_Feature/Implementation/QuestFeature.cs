using Assets.Game.Services.ProgressService.api;
using System.Collections.Generic;
using WKosArch.Extentions;

public class QuestFeature : IQuestFeature, ISavedProgress
{
    public bool IsReady => _isReady;

    public List<IQuest> Quests => _quests;


    private bool _isReady;


    private List<ICollectionQuest> _activeCollectingQuests;
    private List<ICollectionQuest> _disactiveCollectingQuests;
    private List<ICollectionQuest> _newCollectingQuests;


    private List<IJourneyQuest> _activeJourneyQuests;
    private List<IJourneyQuest> _disactiveJourneyQuests;
    private List<IJourneyQuest> _newJourneyQuests;


    private List<IQuest> _quests;

    public QuestFeature(List<IQuest> quests)
    {
        _quests = quests;

        _isReady = true;
    }


    public void SaveProgress(GameProgress progress)
    {
        //CombaineData();
        progress.Quests = _quests;
    }


    public void LoadProgress(GameProgress progress)
    {
        _quests = progress.Quests;
        //SeparateData();
    }

    private void CombaineData()
    {
        if (_quests.Count == 0)
        {
            AddToQuestsList(_newCollectingQuests);
            AddToQuestsList(_activeCollectingQuests);
            AddToQuestsList(_disactiveCollectingQuests);
            AddToQuestsList(_newJourneyQuests);
            AddToQuestsList(_activeJourneyQuests);
            AddToQuestsList(_disactiveJourneyQuests); 
        }
    }

    private void AddToQuestsList<T>(List<T> quests) where T : IQuest
    {
        foreach (var quest in quests)
        {
            _quests.Add(quest);
        }
    }

    private void SeparateData()
    {
        foreach (var quest in _quests)
        {
            if (quest is ICollectionQuest)
            {
                switch (quest.State)
                {
                    case QuestState.New:
                        _newCollectingQuests.Add(quest as ICollectionQuest);
                        break;
                    case QuestState.Active:
                        _activeCollectingQuests.Add(quest as ICollectionQuest);
                        break;
                    case QuestState.Disactive:
                        _disactiveCollectingQuests.Add(quest as ICollectionQuest);
                        break;
                }
            }
            if (quest is IJourneyQuest)
            {
                switch (quest.State)
                {
                    case QuestState.New:
                        _newJourneyQuests.Add(quest as IJourneyQuest);
                        break;
                    case QuestState.Active:
                        _activeJourneyQuests.Add(quest as IJourneyQuest);
                        break;
                    case QuestState.Disactive:
                        _disactiveJourneyQuests.Add(quest as IJourneyQuest);
                        break;
                }
            }
        }

        _quests.Clear();
    }



    private void PrintLog()
    {
        foreach (var quest in _quests)
        {
            Log.PrintYellow(quest.ToString());
        }
    }
}
