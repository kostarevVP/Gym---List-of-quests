using System;
using WKosArch.Extentions;
using WKosArch.UIService.Views.Widgets;

public class QuestsListWidgetModel : WidgetViewModel
{
    private IQuestFeature _questFeature => DiContainer.Resolve<IQuestFeature>();
    protected override void AwakeInternal()
    {
        base.AwakeInternal();
    }

    internal void InitState(QuestState quastState)
    {

    }

    private void InitDisactiveState(IQuest quest)
    {
        Log.PrintYellow($"InitDisactiveState={_questFeature.Quests.Count}");

    }

    private void InitActiveState(IQuest quest)
    {
        throw new NotImplementedException();
    }

    private void InitNewState(IQuest quest)
    {
        if (quest is ICollectionQuest)
        {
            //UI.ShowWidget<WidgetDisactiveCollectionQuest>
        }
    }
}
