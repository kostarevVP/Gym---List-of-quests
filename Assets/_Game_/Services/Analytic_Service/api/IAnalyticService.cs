using WKosArch.Domain.Features;

public interface IAnalyticService : IFeature
{
    void LogEvent(string name, string parameterName, string parameterValue);
    void LogEvent(string name, string parameterName, double parameterValue);
    void LogEvent(string name, string parameterName, long parameterValue);
    void LogEvent(string name, string parameterName, int parameterValue);
    void LogEvent(string name);
}
