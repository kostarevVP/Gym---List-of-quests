using UnityEngine;
using WKosArch.UIService.Views.Windows;

public class QuestWindowModel : WindowViewModel
{
    public Transform WidgetRoot { get; set; }

    internal void OpenWidget()
    {
        UI.ShowWidget<QuestsListWidgetModel>(WidgetRoot);
    }
}
