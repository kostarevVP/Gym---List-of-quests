using Assets.LocalPackages.WKosArch.Scripts.Common.DIContainer;
using WKosArch.Services.Scenes;
using WKosArch.UIService.Views.Windows;

public class RestartWindowModel : WindowViewModel
{
    private ISaveLoadService _saveLoadService;
    private ISceneManagementService _sceneManagementService;

    public override void InjectDI(IDIContainer container)
    {
        base.InjectDI(container);

        _saveLoadService = container.Resolve<ISaveLoadService>();
        _sceneManagementService = container.Resolve<ISceneManagementService>();
    }
   
    internal void RestartGame()
    {
        _saveLoadService.SaveProgress();
        _sceneManagementService.ReloadScene();
    }
}
