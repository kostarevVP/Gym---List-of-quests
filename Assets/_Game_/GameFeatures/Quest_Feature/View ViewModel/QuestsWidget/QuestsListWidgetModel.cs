using System;
using WKosArch.Extentions;
using WKosArch.UIService.Views.Widgets;

public class QuestsListWidgetModel : WidgetViewModel
{
    protected override void AwakeInternal()
    {
        base.AwakeInternal();
        Log.PrintYellow("QuestsListWidgetModel AwakeInternal");

    }

    internal void InitState(QuestState quastState)
    {
        Log.PrintYellow("QuestsListWidgetModel InitState");
    }
}
