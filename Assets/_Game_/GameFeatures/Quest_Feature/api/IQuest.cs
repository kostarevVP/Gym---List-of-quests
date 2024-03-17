using System;

public interface IQuest
{
    Action OnDataChanged { get; set; }

    public QuestState State { get; set; }
    bool IsComplete { get; set; }
    string Name { get; set; }
    string Description { get; set; }

}

public interface ICollectionQuest : IQuest
{
    string StuffName { get; set; }
    int Amount { get; set; }
    int CurrentAmount { get; set; }
    float ExecutionProgress { get; }
}

public interface IJourneyQuest : IQuest
{
    string PlaceArrival { get; set; }
}

[Serializable]
public enum QuestState
{
    Unknown = 0,
    New = 1,
    Active = 2,
    Disactive = 3,
}
