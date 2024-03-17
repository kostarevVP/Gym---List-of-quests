using WKosArch.UIService.Views.Widgets;

public class DisactiveStateButtonsJourneyWidgetModel : WidgetViewModel
{
    private IJourneyQuest _quest;

    public void Construct(IJourneyQuest quest)
    {
        _quest = quest;
    }

    internal void ChangeQuestState(QuestState state)
    {
        _quest.State = state;
        _quest.IsComplete = false;
    }
}
