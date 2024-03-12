using UnityEngine;
using UnityEngine.UI;
using WKosArch.UIService.Views.Windows;

public class WindowHomeSettingButton : Window<HomeSettingButtonViewModel>   
{
    [Space]
    [SerializeField] private Button _settingButton;

    public override void Subscribe()
    {
        base.Subscribe();
        _settingButton.onClick.AddListener(ViewModel.OpenMainMenu);
    }

    public override void Unsubscribe()
    {
        base.Unsubscribe();
        _settingButton.onClick.RemoveListener(ViewModel.OpenMainMenu);
    }

}
