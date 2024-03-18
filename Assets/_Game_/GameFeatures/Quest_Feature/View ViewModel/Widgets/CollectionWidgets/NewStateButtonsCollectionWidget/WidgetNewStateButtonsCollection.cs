using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WKosArch.UIService.Views.Widgets;

public class WidgetNewStateButtonsCollection : Widget<NewStateButtonsCollectionWidgetModel>
{
    [Space]
    [SerializeField]
    private Button _activateButton;
    [SerializeField]
    private TextMeshProUGUI _amountTMPro;

    public override void Refresh()
    {
        base.Refresh();
        _amountTMPro.text = $"{ViewModel.CurrentAmount} / {ViewModel.Amount}";
    }

    public override void Subscribe()
    {
        base.Subscribe();
        _activateButton.onClick.AddListener(ChangeState);
    }

    private void ChangeState()
    {
        ViewModel.ChangeState(QuestState.Active);
    }
}