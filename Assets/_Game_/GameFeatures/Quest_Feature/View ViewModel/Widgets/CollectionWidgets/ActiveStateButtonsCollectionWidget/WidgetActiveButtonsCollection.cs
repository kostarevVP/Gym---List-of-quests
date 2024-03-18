using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WKosArch.UIService.Views.Widgets;

public class WidgetActiveButtonsCollection   : Widget<ActiveButtonsCollectionWidgetModel>
{
    [Space]
    [SerializeField]
    private Button _minusButton;
    [SerializeField]
    private Button _plusButton;
    [SerializeField]
    private TextMeshProUGUI _amountTMPro;
    [SerializeField]
    private Button _cancelButton;

    public override void Refresh()
    {
        base.Refresh();
        _amountTMPro.text = $"{ViewModel.CurrentAmount} / {ViewModel.Amount}";
    }

    public override void Subscribe()
    {
        base.Subscribe();
        _minusButton.onClick.AddListener(() => ChangeCurrentAmount(-1));
        _plusButton.onClick.AddListener(() => ChangeCurrentAmount(1));

        _cancelButton.onClick.AddListener(() => CancelQuest());
    }

    private void ChangeCurrentAmount(int value)
    {
        ViewModel.ChangeCurrentAmount(value);
    }

    private void CancelQuest()
    {
        ViewModel.CancelQuest();
    }
}