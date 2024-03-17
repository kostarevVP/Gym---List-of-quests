using WKosArch.Extentions;
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
    }

    internal void ChangeState(QuestState state)
    {
        Log.PrintYellow($"{_quest.Name} {_quest.State}");

        _quest.State = state;
        Log.PrintYellow($"{_quest.Name} {_quest.State}");
    }
}
