using UnityEngine;
using UnityEngine.UI;
using WKosArch.UIService.Views.Widgets;

public class WidgetActiveStateButtonsJourney : Widget<ActiveStateButtonsJourneyWidgetModel>
{
    [Space]
    [SerializeField]
    private Button _endQuestButton;
    [SerializeField] 
    private Button _cancelQuestButton;



    public override void Subscribe()
    {
        base.Subscribe();
        _endQuestButton.onClick.AddListener(() => ViewModel.EndSuccess());
        _cancelQuestButton.onClick.AddListener(() => ViewModel.CancelQuest());
    }
}