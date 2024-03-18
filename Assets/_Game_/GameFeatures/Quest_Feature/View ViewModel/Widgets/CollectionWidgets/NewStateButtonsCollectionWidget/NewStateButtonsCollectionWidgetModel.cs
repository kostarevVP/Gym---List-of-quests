using WKosArch.UIService.Views.Widgets;

public class NewStateButtonsCollectionWidgetModel : WidgetViewModel
{
    public int Amount { get; private set; }
    public int CurrentAmount { get; private set; }

    private ICollectionQuest _quest;

    public void Construct(ICollectionQuest quest)
    {
        _quest = quest;

        Amount = _quest.Amount;
        CurrentAmount = _quest.CurrentAmount;
        Refresh();
    }

    internal void ChangeState(QuestState state)
    {
        _quest.State = state;
    }
}
