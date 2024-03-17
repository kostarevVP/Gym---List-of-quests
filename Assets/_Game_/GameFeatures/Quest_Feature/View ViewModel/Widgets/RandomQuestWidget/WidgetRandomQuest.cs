using UnityEngine;
using UnityEngine.UI;
using WKosArch.UIService.Views.Widgets;

public class WidgetRandomQuest : Widget<RandomQuestWidgetModel>
{
    [Space]
    [SerializeField]
    private Button _randomQuestButton;

    public override void Subscribe()
    {
        base.Subscribe();
        _randomQuestButton.onClick.AddListener(() => ViewModel.ActiveRandomQuest());
    }
}