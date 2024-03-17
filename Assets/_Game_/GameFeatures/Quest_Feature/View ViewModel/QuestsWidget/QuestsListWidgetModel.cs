using System;
using UnityEngine;
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
        var questBaseWidget = UI.ShowWidget<QuestBaseWidgetModel>(this.GetComponent<RectTransform>());
    }

}
