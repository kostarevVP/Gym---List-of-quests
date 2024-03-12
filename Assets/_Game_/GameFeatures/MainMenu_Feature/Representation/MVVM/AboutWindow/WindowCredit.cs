using UnityEngine;
using UnityEngine.UI;
using WKosArch.UIService.Views.Windows;

public class WindowCredit : Window<CreditWindowModel>
{
    [Space]
    [SerializeField] private Button _VladLinkButton;
    [SerializeField] private Button _VadymLinkButton;

    [field: SerializeField] private string VladLink;
    [field: SerializeField] private string VadymLink;

    public override void Subscribe()
    {
        base.Subscribe();
        _VladLinkButton?.onClick.AddListener(() => ViewModel.OpenLink(VladLink));
        _VadymLinkButton?.onClick.AddListener(() => ViewModel.OpenLink(VadymLink));
    }

    public override void Unsubscribe()
    {
        base.Unsubscribe();
        _VladLinkButton?.onClick.RemoveListener(() => ViewModel.OpenLink(VladLink));
        _VadymLinkButton?.onClick.RemoveListener(() => ViewModel.OpenLink(VadymLink));
    }
}
