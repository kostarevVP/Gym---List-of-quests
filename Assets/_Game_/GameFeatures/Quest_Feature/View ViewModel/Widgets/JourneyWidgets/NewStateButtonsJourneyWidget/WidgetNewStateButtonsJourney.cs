using UnityEngine;
using UnityEngine.UI;
using WKosArch.UIService.Views.Widgets;

public class WidgetNewStateButtonsJourney : Widget<NewStateButtonsJourneyWidgetModel>
{
    [Space]
    [SerializeField]
    private Button _activeQuestButton;



    public override void Subscribe()
    {
        base.Subscribe();
        _activeQuestButton.onClick.AddListener(() => ViewModel.ChangeQuestState(QuestState.Active));
    }

}