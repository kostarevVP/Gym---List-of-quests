using System;

public interface IQuest
{
    public QuestState QuestState { get; }
    bool IsComplete { get; }
    string Name { get; }
    string Description { get; }
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

[Serializable]
public enum QuestState
{
    Unknown = 0,
    New = 1,
    Active = 2,
    Disactive = 3,
}
