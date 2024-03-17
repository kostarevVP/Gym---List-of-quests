using UnityEngine;
using UnityEngine.UI;
using WKosArch.UIService.Views.Widgets;

public class WidgetDisactiveStateButtonsJourney : Widget<DisactiveStateButtonsJourneyWidgetModel>
{
    [Space]
    [SerializeField]
    private Button _activeQuestButton;
    [SerializeField]
    private Button _cancelQuestButton;



    public override void Subscribe()
    {
        base.Subscribe();
        _activeQuestButton.onClick.AddListener(() => ViewModel.ChangeQuestState(QuestState.Active));
        _cancelQuestButton.onClick.AddListener(() => ViewModel.ChangeQuestState(QuestState.New));
    }
}