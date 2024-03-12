public class JourneyQuest : IJourneyQuest
{
    public bool IsDone => _isDone;

    public string Name => _name;

    public string Description => _descrition;

    public float ExecutionProgress => _executionProgress;

    public string PlaceArrival => _placeArrival;

    private bool _isDone;

    private string _name;
    private string _descrition;
    private float _executionProgress;
    private string _placeArrival;

    public JourneyQuest(string name, string descrition, string placeArrival)
    {
        _name = name;
        _descrition = descrition;
        _placeArrival = placeArrival;
    }

    public override string ToString()
    {
        return $"Name={_name} went to {_placeArrival} {_executionProgress * 100}percent left";
    }
}
