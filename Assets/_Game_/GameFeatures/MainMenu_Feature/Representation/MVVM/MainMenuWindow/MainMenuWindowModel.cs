using WKosArch.Services.SoundService;
using WKosArch.UIService.Views.Windows;

public partial class MainMenuWindowModel : WindowViewModel
{
    internal void OpenAboutWindow() => 
        UI.Show<AboutUsWindowModel>();

    internal void OpenQuitGameWindow() => 
        UI.Show<QuitGameWindowModel>();

    internal void OpenRestartWindow() => 
        UI.Show<RestartWindowModel>();

    internal void OpenSoundWindow() => 
        UI.Show<AudioSettingViewModel>();
}
