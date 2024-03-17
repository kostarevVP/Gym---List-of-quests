using WKosArch.UIService.Views.Widgets;

public class QuestBaseWidgetModel : WidgetViewModel
{
    public string Title { get; private set; }
    public string Description { get; private set; }

    private ICollectionQuest _quest;

    public void Construct(ICollectionQuest quest)
    {
        _quest = quest;

        Title = _quest.Name;
        Description = _quest.Description;
    }
}
