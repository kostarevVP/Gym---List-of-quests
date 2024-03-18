using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WKosArch.UIService.Views.Widgets;

public class WidgetRandomQuest : Widget<RandomQuestWidgetModel>
{
    [Space]
    [SerializeField]
    private Button _randomQuestButton;
    [Space]
    [SerializeField]
    private TextMeshProUGUI _buttonTMPro;
    [SerializeField]
    private string _IfHasQuest;
    [SerializeField]
    private string _IfHasNotQuest;

    public override void Refresh()
    {
        base.Refresh();

        if (ViewModel.HasQuest)
        {
            _randomQuestButton.interactable = true;
            _buttonTMPro.text = _IfHasQuest;
        }
        else
        {
            _randomQuestButton.interactable = false;
            _buttonTMPro.text = _IfHasNotQuest;
        }
    }

    public override void Subscribe()
    {
        base.Subscribe();
        _randomQuestButton.onClick.AddListener(() => ViewModel.ActiveRandomQuest());
    }
}