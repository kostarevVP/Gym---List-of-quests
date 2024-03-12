using WKosArch.Domain.Contexts;
using WKosArch.Domain.Features;
using WKosArch.Services.Scenes;
using Assets.LocalPackages.WKosArch.Scripts.Common.DIContainer;
using WKosArch.Services.StaticDataServices;
using UnityEngine;
using WKosArch.Extentions;

namespace  WKosArch.Services.UIService

{
    [CreateAssetMenu(fileName = "UIService_Installer", menuName = "Game/Installers/UIService_Installer")]
    public class UIService_Installer : FeatureInstaller
    {
        private IUIService _service;
        public override IFeature Create(IDIContainer container)
        {
            var sceneMenegmentService = container.Resolve<ISceneManagementService>();
            var staticDataService = container.Resolve<IStaticDataService>();

            _service = new UIService(staticDataService, sceneMenegmentService, container);

            container.Bind(_service);
            container.Bind(_service.UI);

            Log.PrintColor($"[UIService] Create and Bind", Color.cyan);
            Log.PrintColor($"[UI] Create and Bind", Color.cyan);

            return _service;
        }

        public override void Dispose()
        {
            
        }
    }
}