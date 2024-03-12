using UnityEngine;
using UnityEngine.UI;
using WKosArch.UIService.Views.Windows;

public class WindowQuitGame : Window<QuitGameWindowModel> 
{
    [Space]
    [SerializeField] private Button _confirmExitButton;
    [SerializeField] private Button _cancelExitButton;

    public override void Subscribe()
    {
        base.Subscribe();
        _confirmExitButton.onClick.AddListener(ViewModel.CloseAplication);
        _cancelExitButton.onClick.AddListener(ViewModel.Close);
    }

    public override void Unsubscribe()
    {
        base.Unsubscribe();
        _confirmExitButton.onClick.RemoveListener(ViewModel.CloseAplication);
        _cancelExitButton?.onClick.RemoveListener(ViewModel.Close);
    }
}
