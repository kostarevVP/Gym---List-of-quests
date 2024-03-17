using WKosArch.Services.Scenes;
using WKosArch.UIService.Views.Windows;

public class RestartWindowModel : WindowViewModel
{
    private ISaveLoadService _saveLoadService => DiContainer.Resolve<ISaveLoadService>();
    private ISceneManagementService _sceneManagementService => DiContainer.Resolve<ISceneManagementService>();

    internal void RestartGame()
    {
        _saveLoadService.SaveProgress();
        _sceneManagementService.ReloadScene();
    }
}
