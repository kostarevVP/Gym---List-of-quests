using UnityEngine;
using UnityEngine.UI;
using WKosArch.UIService.Views.Windows;

public class QuestWindowModel : WindowViewModel
{
    [Space]
    [SerializeField]
    private Transform _widgetRoot;
    [SerializeField]
    private ScrollRect _scrollRect;

    private QuestsListWidgetModel _activeVidget;

    internal async void OpenWidget(QuestState questState)
    {
        if(_activeVidget != null)
        {
            await _activeVidget.Widget.Hide();
        }
        _activeVidget = UI.ShowWidget<QuestsListWidgetModel>(_widgetRoot);
        _scrollRect.content = _activeVidget.GetComponent<RectTransform>();
        _activeVidget.InitState(questState);
    }
}
