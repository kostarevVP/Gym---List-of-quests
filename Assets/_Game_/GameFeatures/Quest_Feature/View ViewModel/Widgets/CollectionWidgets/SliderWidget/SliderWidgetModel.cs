using WKosArch.UIService.Views.Widgets;

public class SliderWidgetModel : WidgetViewModel
{
    public float ExecutionProgress { get; private set; }

    private ICollectionQuest _quest;

    public void Construct(ICollectionQuest quest)
    {
        _quest = quest;
        ExecutionProgress = _quest.ExecutionProgress;

        _quest.OnDataChanged += ChageValue;
        Refresh();
    }


    protected override void UnsubscribeInternal()
    {
        base.UnsubscribeInternal();
        _quest.OnDataChanged -= ChageValue;
    }

    public void ChageValue()
    {
        if (_quest.ExecutionProgress != ExecutionProgress)
        {
            ExecutionProgress = _quest.ExecutionProgress;
            Refresh();
        }
    }
}
