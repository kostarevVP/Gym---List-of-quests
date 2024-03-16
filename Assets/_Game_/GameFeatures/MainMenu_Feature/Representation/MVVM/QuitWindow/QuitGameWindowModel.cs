using Assets.LocalPackages.WKosArch.Scripts.Common.DIContainer;
using UnityEngine;
using WKosArch.UIService.Views.Windows;

public class QuitGameWindowModel : WindowViewModel
{
    private ISaveLoadService _saveLoadService;

    public override void InjectDI(IDIContainer container)
    {
        base.InjectDI(container);

        _saveLoadService = DiContainer.Resolve<ISaveLoadService>();
    }

    internal void CloseAplication()
    {
        _saveLoadService.SaveProgress();

        Application.Quit();
    }
}
