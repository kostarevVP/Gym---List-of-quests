using WKosArch.UIService.Views.Widgets;

public class ActiveStateButtonsJourneyWidgetModel : WidgetViewModel
{
    private IJourneyQuest _quest;

    public void Construct(IJourneyQuest quest)
    {
        _quest = quest;
    }

    internal void CancelQuest()
    {
        _quest.State = QuestState.Disactive;
    }

    internal void EndSuccess()
    {
        _quest.State = QuestState.Disactive;
        _quest.IsComplete = true;
    }
}
