using WKosArch.UIService.Views.Widgets;

public class NewStateButtonsJourneyWidgetModel : WidgetViewModel
{
    private IJourneyQuest _quest;

    public void Construct(IJourneyQuest quest)
    {
        _quest = quest;
    }

    internal void ChangeQuestState(QuestState state)
    {
        _quest.State = state;
    }

}
