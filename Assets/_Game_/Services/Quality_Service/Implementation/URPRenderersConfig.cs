using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using WKosArch.Extentions;

[CreateAssetMenu(fileName = "URPRenderersConfig", menuName = "QualityConfig/URPRenderersConfig")]
public class URPRenderersConfig : ScriptableObject
{
    public RenderPipelineAsset LowQualityPipeline;
    public RenderPipelineAsset MediumQualityPipeline;
    public RenderPipelineAsset HighQualityPipeline;

    public Dictionary<RenderingQuality, RenderPipelineAsset> RendererQualityMap = new Dictionary<RenderingQuality, RenderPipelineAsset>();
   

    public void Init()
    {
        RendererQualityMap.Add(RenderingQuality.Low, LowQualityPipeline);
        RendererQualityMap.Add(RenderingQuality.Medium, MediumQualityPipeline);
        RendererQualityMap.Add(RenderingQuality.High, HighQualityPipeline);
    }
}
