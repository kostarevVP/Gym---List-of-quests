using WKosArch.Domain.Features;

public interface IQualityService : IFeature
{
    void SetFPSLimit(int targetFPS);
    void SetRenderPipeline(RenderingQuality renderingQuality);
}