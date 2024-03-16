using WKosArch.Domain.Features;
using System.Collections.Generic;
using WKosArch.Services.UIService;
using UnityEngine.Rendering;

namespace WKosArch.Services.StaticDataServices
{
	public interface IStaticDataService : IFeature
	{
		GameProgressConfig GameProgressConfig { get; }
		Dictionary<string, UISceneConfig> SceneConfigsMap { get; }
        Dictionary<RenderingQuality, RenderPipelineAsset> RenderQualityConfigMap { get; }
        List<IQuest> QuestsList { get; }
    } 
}