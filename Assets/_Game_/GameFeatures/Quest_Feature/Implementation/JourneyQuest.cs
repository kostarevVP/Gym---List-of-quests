using System;

[Serializable]
public class JourneyQuest : Quest, IJourneyQuest
{
    public string PlaceArrival { get => _placeArrival; set => _placeArrival = value; }

    private string _placeArrival;
}
