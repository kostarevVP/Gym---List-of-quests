using WKosArch.UIService.Views.Widgets;

public class DisactiveStateButtonsCollectionWidgetModel : WidgetViewModel
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
        if (state == QuestState.New)
        {
            _quest.State = QuestState.New;
            _quest.IsComplete = false;
            _quest.CurrentAmount = 0;
        }
        if (state == QuestState.Active)
        {
            _quest.State = state;

            if (_quest.IsComplete)
            {
                _quest.IsComplete = false;
                _quest.CurrentAmount = 0;
            }
        }
        Refresh();
    }
}
