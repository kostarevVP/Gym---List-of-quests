using WKosArch.UIService.Views.Widgets;

public class ActiveButtonsCollectionWidgetModel : WidgetViewModel
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

    protected override void SubscribeInternal()
    {
        base.SubscribeInternal();
        _quest.OnDataChanged += ChageValue;
    }

    protected override void UnsubscribeInternal()
    {
        base.UnsubscribeInternal();
        _quest.OnDataChanged -= ChageValue;
    }

    private void ChageValue()
    {
        if(Amount != _quest.Amount)
        {
            Amount = _quest.Amount;
            Refresh();
        }
        if (CurrentAmount != _quest.CurrentAmount)
        {
            CurrentAmount = _quest.CurrentAmount;
            Refresh();
        }
    }

    internal void ChangeCurrentAmoutn(int value)
    {
        var currentAmount = CurrentAmount;

        currentAmount += value;

        if(currentAmount < 0)
            return;

        _quest.CurrentAmount = currentAmount;

        if(currentAmount == Amount)
        {
            _quest.IsComplete = true;
            _quest.State = QuestState.Disactive;
        }
    }

    internal void CancelQuest()
    {
        _quest.State = QuestState.Disactive;
    }
}
