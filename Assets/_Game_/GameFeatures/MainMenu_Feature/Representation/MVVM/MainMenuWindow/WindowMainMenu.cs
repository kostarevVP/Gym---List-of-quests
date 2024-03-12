using UnityEngine;
using UnityEngine.UI;
using WKosArch.UIService.Views.Windows;

public class WindowMainMenu : Window<MainMenuWindowModel>
{
    [Space]
    [SerializeField] protected Button AboutButton;
    [SerializeField] protected Button SoundButton;
    [SerializeField] protected Button QuitButton;
    [SerializeField] protected Button RestartButton;

    public override void Subscribe()
    {
        base.Subscribe();
        AboutButton.onClick.AddListener(ViewModel.OpenAboutWindow);
        SoundButton.onClick.AddListener(ViewModel.OpenSoundWindow);
        QuitButton.onClick.AddListener(ViewModel.OpenQuitGameWindow);
        RestartButton.onClick.AddListener(ViewModel.OpenRestartWindow);
    }

    public override void Unsubscribe()
    {
        base.Unsubscribe();
        AboutButton.onClick.RemoveListener(ViewModel.OpenAboutWindow);
        SoundButton.onClick.RemoveListener(ViewModel.OpenSoundWindow);
        QuitButton.onClick.RemoveListener(ViewModel.OpenQuitGameWindow);
        RestartButton.onClick.RemoveListener(ViewModel.OpenRestartWindow);
    }
}
