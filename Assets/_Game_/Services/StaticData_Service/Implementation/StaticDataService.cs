using System.Collections.Generic;
using UnityEngine.Rendering;
using WKosArch.Extentions;
using WKosArch.Services.UIService;

namespace WKosArch.Services.StaticDataServices
{
    public class StaticDataService : IStaticDataService
    {
        private const string GameProgressPath = "NewGameProgressStaticData";
        private const string UISceneConfigsFolderPath = "SeneConfigs";
        private const string QualitySettinsPath = "URPRenderersConfig";

        private const string CollectingQuestsFolderPath = "CollectingQuests";
        private const string JourneyQuestsFolderPath = "JourneyQuests";



        public bool IsReady => _isReady;

        public GameProgressConfig GameProgressConfig => _gameProgressStaticData;

        public Dictionary<string, UISceneConfig> SceneConfigsMap => _sceneConfigsMap;

        public Dictionary<RenderingQuality, RenderPipelineAsset> RenderQualityConfigMap => _renderQualityConfigMap;

        public List<ICollectionQuest> ColectionQuests => _collectingQuestList;
        public List<IJourneyQuest> JourneyQuests => _journeyQuestList;


        private IAssetProviderService _assetProviderService;

        private GameProgressConfig _gameProgressStaticData;
        private Dictionary<string, UISceneConfig> _sceneConfigsMap = new();
        private Dictionary<RenderingQuality, RenderPipelineAsset> _renderQualityConfigMap = new();

        private List<ICollectionQuest> _collectingQuestList = new();
        private List<IJourneyQuest> _journeyQuestList = new();



        private bool _isReady;

        public StaticDataService(IAssetProviderService assetProviderService)
        {
            _assetProviderService = assetProviderService;

            LoadGameProgressConfig();
            LoadSceneConfigs();
            LoadQualityConfigs();

            LoadCollectionQuests();
            LoadJounreyQuests();

            _isReady = true;
        }

        public void Dispose() =>
            Clear();

        private void LoadGameProgressConfig()
        {
            _gameProgressStaticData = _assetProviderService.Load<GameProgressConfig>(GameProgressPath);
        }

        private void LoadSceneConfigs()
        {
            var scenesConfigs = _assetProviderService.LoadAll<UISceneConfig>(UISceneConfigsFolderPath);

            foreach (var sceneConfigs in scenesConfigs)
            {
                foreach (var scene in sceneConfigs.SceneName)
                {
                    if (!_sceneConfigsMap.ContainsKey(scene))
                        _sceneConfigsMap[scene] = sceneConfigs;
                    else
                        Log.PrintError($"You try add Scene WindowConfigs that is have another WindowConfig");
                }
            }
        }

        private void LoadCollectionQuests()
        {
            var questConfigs = _assetProviderService.LoadAll<CollectingQuestConfig>(CollectingQuestsFolderPath);

            foreach (var config in questConfigs)
            {
                ICollectionQuest quest = new CollectioinQuest(
                    config.Name,
                    config.Description,
                    config.StuffName,
                    config.Amount);

                _collectingQuestList.Add(quest);
            }
        }

        private void LoadJounreyQuests()
        {
            var questConfigs = _assetProviderService.LoadAll<JourneyQuestConfig>(JourneyQuestsFolderPath);

            foreach (var config in questConfigs)
            {
                IJourneyQuest quest = new JourneyQuest(
                    config.Name,
                    config.Description,
                    config.PlaceArrival);

                _journeyQuestList.Add(quest);
            }
        }

        private void LoadQualityConfigs()
        {
            var qualityConfig = _assetProviderService.Load<URPRenderersConfig>(QualitySettinsPath);
            qualityConfig.Init();
            _renderQualityConfigMap = qualityConfig.RendererQualityMap;
        }


        private void Clear()
        {
            _gameProgressStaticData = null;
            _sceneConfigsMap.Clear();
            _renderQualityConfigMap.Clear();

            _collectingQuestList.Clear();
            _journeyQuestList.Clear();
        }
    }
}
