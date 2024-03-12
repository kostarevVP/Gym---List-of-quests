public interface IQuest
{
    string Name { get; }
    string Description { get; }
    bool IsDone { get; }
    float ExecutionProgress { get; }
}

public interface ICollectionQuest : IQuest
{
    string StuffName { get; }   
    int Amount { get; }
    int CurrentAmount { get; }
}

public interface IJourneyQuest : IQuest
{
    string PlaceArrival { get; }
}
