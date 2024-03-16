using Cysharp.Threading.Tasks.Triggers;
using UnityEngine;
using WKosArch.UIService.Views.Windows;

public class QuestWindowModel : WindowViewModel
{
    public Transform WidgetRoot { get; set; }

    internal void OpenWidget(QuestState quastState)
    {
        UI.ShowWidget<QuestsListWidgetModel>(WidgetRoot).InitState(quastState);
    }
}
