using WKosArch.Extentions;
using WKosArch.UIService.Views.Widgets;

public class QuestBaseWidgetModel : WidgetViewModel
{
    public string Title { get; private set; }
    public string Description { get; private set; }

    private IQuest _quest;

    public void Construct(IQuest quest)
    {
        _quest = quest;

        Title = _quest.Name;
        Description = _quest.Description;
        Refresh();

        switch (_quest.State)
        {
            case QuestState.New:
                AddNewStateWidgets();
                break;
            case QuestState.Active:
                AddActiveStateWidgets();
                break;
            case QuestState.Disactive:
                AddDisactiveStateWidgets();
                break;
        }
    }

    private void AddNewStateWidgets()
    {
        if(_quest is ICollectionQuest)
        {
            var buttonsWidget = UI.ShowWidget<NewStateButtonsCollectionWidgetModel>(this.transform);
            buttonsWidget.Construct(_quest as ICollectionQuest);
        }
        if(_quest is IJourneyQuest)
        {
            var buttonsWidget = UI.ShowWidget<NewStateButtonsJourneyWidgetModel>(this.transform);
            buttonsWidget.Construct(_quest as IJourneyQuest);
        }
    }

    private void AddActiveStateWidgets()
    {
        if (_quest is ICollectionQuest)
        {
            var sliderWidget = UI.ShowWidget<SliderWidgetModel>(this.transform);
            sliderWidget.Construct(_quest as ICollectionQuest);
            var buttonsWidget = UI.ShowWidget<ActiveButtonsCollectionWidgetModel>(this.transform);
            buttonsWidget.Construct(_quest as ICollectionQuest);
        }
        if (_quest is IJourneyQuest)
        {
            var buttonsWidget = UI.ShowWidget<ActiveStateButtonsJourneyWidgetModel>(this.transform);
            buttonsWidget.Construct(_quest as IJourneyQuest);
        }
    }

    private void AddDisactiveStateWidgets()
    {
        if (_quest is ICollectionQuest)
        {
            var sliderWidget = UI.ShowWidget<SliderWidgetModel>(this.transform);
            sliderWidget.Construct(_quest as ICollectionQuest);
            var buttonsWidget = UI.ShowWidget<DisactiveStateButtonsCollectionWidgetModel>(this.transform);
            buttonsWidget.Construct(_quest as ICollectionQuest);
        }
        if (_quest is IJourneyQuest)
        {
            var buttonsWidget = UI.ShowWidget<DisactiveStateButtonsJourneyWidgetModel>(this.transform);
            buttonsWidget.Construct(_quest as IJourneyQuest);
        }
    }
}
