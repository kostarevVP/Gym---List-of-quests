public class JourneyQuest : Quest, IJourneyQuest
{
    public string PlaceArrival { get => _placeArrival; set => value = _placeArrival; }

    private float _executionProgress;
    private string _placeArrival;

    public JourneyQuest(string name, string descrition, string placeArrival)
    {
        Name = name;
        Description = descrition;
        PlaceArrival = placeArrival;
    }

    public override string ToString()
    {
        return $"Name={Name} went to {_placeArrival} {_executionProgress * 100}percent left";
    }
}
