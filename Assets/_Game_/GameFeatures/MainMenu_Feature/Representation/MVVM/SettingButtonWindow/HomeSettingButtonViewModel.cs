using WKosArch.UIService.Views.Windows;

public class HomeSettingButtonViewModel : WindowViewModel, IHomeWindow
{
    protected override void AwakeInternal()
    {
        base.AwakeInternal();
    }

    internal void OpenMainMenu()
    {
        UI.Show<MainMenuWindowModel>();
    }
}
