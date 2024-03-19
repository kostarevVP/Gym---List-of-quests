using UnityEngine;
using UnityEngine.UI;
using WKosArch.UIService.Views.Windows;

public class WindowHomeSettingButton : Window<HomeSettingButtonViewModel>   
{
    [Space]
    [SerializeField] private Button _settingButton;
    [Space]
    [SerializeField] private Button _openQuestButton;

    public override void Subscribe()
    {
        base.Subscribe();
        _settingButton.onClick.AddListener(ViewModel.OpenMainMenu);
        _openQuestButton.onClick.AddListener(ViewModel.OpenQuestWindow);
    }

    public override void Unsubscribe()
    {
        base.Unsubscribe();
        _settingButton.onClick.RemoveListener(ViewModel.OpenMainMenu);
        _openQuestButton.onClick.RemoveListener(ViewModel.OpenQuestWindow);

    }

}
