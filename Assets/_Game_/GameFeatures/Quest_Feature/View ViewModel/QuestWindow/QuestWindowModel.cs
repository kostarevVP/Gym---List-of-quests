using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WKosArch.UIService.Views.Windows;

public class QuestWindowModel : WindowViewModel
{
    public QuestState QuestState => _currentQuestState;
    [Space]
    [SerializeField]
    private Transform _widgetRoot;
    [SerializeField]
    private ScrollRect _scrollRect;

    private QuestsListWidgetModel _activeVidget;
    private QuestState _currentQuestState;
    private List<IQuest> _questList => DiContainer.Resolve<IQuestFeature>().Quests;

    internal async void OpenWidget(QuestState questState)
    {
        _currentQuestState = questState;
        Refresh();

        if (_activeVidget != null)
        {
            await _activeVidget.Widget.Hide();
        }

        _activeVidget = UI.ShowWidget<QuestsListWidgetModel>(_widgetRoot);
        _scrollRect.content = _activeVidget.GetComponent<RectTransform>();
        _activeVidget.InitState(questState);
    }

    protected override void SubscribeInternal()
    {
        base.SubscribeInternal();

        bool hasActiveQuest = false;
        foreach (var quest in _questList)
        {
            if (quest.State == QuestState.Active)
            {
                hasActiveQuest = true;
                break;
            }
        }

        if (hasActiveQuest)
        {
            OpenWidget(QuestState.Active);
        }
        else
        {
            OpenWidget(QuestState.New);
        }
    }
}
