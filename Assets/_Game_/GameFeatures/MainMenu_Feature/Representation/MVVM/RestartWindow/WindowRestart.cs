using UnityEngine;
using UnityEngine.UI;
using WKosArch.UIService.Views.Windows;

public class WindowRestart : Window<RestartWindowModel> 
{
    [Space]
    [SerializeField] private Button _confirmRestartButton;
    [SerializeField] private Button _cancelRestartButton;

    public override void Subscribe()
    {
        base.Subscribe();
        _confirmRestartButton.onClick.AddListener(ViewModel.RestartGame);
        _cancelRestartButton.onClick.AddListener(ViewModel.Close);
    }

    public override void Unsubscribe()
    {
        base.Unsubscribe();
        _confirmRestartButton.onClick.RemoveListener(ViewModel.RestartGame);
        _cancelRestartButton?.onClick.RemoveListener(ViewModel.Close);
    }
}
