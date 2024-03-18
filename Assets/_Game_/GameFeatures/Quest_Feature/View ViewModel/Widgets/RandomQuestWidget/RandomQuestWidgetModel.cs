using System.Collections.Generic;
using UnityEngine;
using WKosArch.UIService.Views.Widgets;

public class RandomQuestWidgetModel : WidgetViewModel
{
    public bool HasQuest { get; private set; }

    private IQuestFeature _questFeature => DiContainer.Resolve<IQuestFeature>();

    internal void ActiveRandomQuest()
    {
        var randomQuestList = new List<IQuest>();

        foreach (var quest in _questFeature.Quests)
        {
            if (quest.State != QuestState.New)
                continue;

            randomQuestList.Add(quest);
        }

        var randomIndex = Random.Range(0, randomQuestList.Count);

        if (randomQuestList.Count != 0)
        {
            randomQuestList[randomIndex].State = QuestState.Active;
            HasQuest = true;
            Refresh();
        }
        else
        {
            HasQuest = false;
            Refresh();
        }
    }
}
