using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WKosArch.UIService.Views.Widgets;

public class WidgetDisactiveStateButtonsCollection : Widget<DisactiveStateButtonsCollectionWidgetModel>
{
    [Space]
    [SerializeField]
    private Button _activateButton;
    [SerializeField]
    private TextMeshProUGUI _amountTMPro;
    [SerializeField] 
    private Button _deleteFromListButton;

    public override void Refresh()
    {
        base.Refresh();
        _amountTMPro.text = $"{ViewModel.CurrentAmount} / {ViewModel.Amount}";

    }

    public override void Subscribe()
    {
        base.Subscribe();
        _activateButton.onClick.AddListener(() => ViewModel.ChangeState(QuestState.Active));
        _deleteFromListButton.onClick.AddListener(() => ViewModel.ChangeState(QuestState.New));
    }
}