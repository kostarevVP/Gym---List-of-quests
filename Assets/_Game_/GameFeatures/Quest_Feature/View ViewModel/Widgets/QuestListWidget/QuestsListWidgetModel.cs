using WKosArch.Extentions;
using WKosArch.UIService.Views.Widgets;

public class QuestsListWidgetModel : WidgetViewModel
{
    private IQuestFeature _questFeature => DiContainer.Resolve<IQuestFeature>();


    internal void InitState(QuestState questState)
    {
        foreach(var quest in  _questFeature.Quests)
        {
            if(quest.State == questState)
            {
                var baseWidget = UI.ShowWidget<QuestBaseWidgetModel>(this.transform);
                baseWidget.Construct(quest);
            }
        }
    }

}
