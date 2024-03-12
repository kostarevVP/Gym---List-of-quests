using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using WKosArch.Extentions;

public class QualityService : IQualityService
{
    private Dictionary<RenderingQuality, RenderPipelineAsset> _renderQualityConfigMap;
    private bool _isReady;

    public bool IsReady => _isReady;

    public QualityService(Dictionary<RenderingQuality, RenderPipelineAsset> renderQualityConfigMap)
    {
        _renderQualityConfigMap = renderQualityConfigMap;
        _isReady = true;
    }

    public void SetFPSLimit(int targetFPS)
    {
        Application.targetFrameRate = targetFPS;
    }

    public void SetRenderPipeline(RenderingQuality renderingQuality)
    {
        if (_renderQualityConfigMap.TryGetValue(renderingQuality, out var renderPipelineAsset))
        {
            GraphicsSettings.renderPipelineAsset = renderPipelineAsset;
        }
        else
        {
            Log.PrintWarning($"Not find {renderingQuality} RenderingQuality in URPRenderersConfig");
        }
    }
}

public enum RenderingQuality
{
    Low,
    Medium,
    High,
    Ultra
}
