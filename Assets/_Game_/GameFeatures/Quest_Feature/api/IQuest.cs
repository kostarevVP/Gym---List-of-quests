public interface IQuest
{
    string Name { get; }
    string Description { get; }
    bool IsDone { get; }
    float ExecutionProgress { get; }
}

public interface ICountQuest : IQuest
{
    string StuffName { get; }   
    int Count { get; }
    int CurrentCount { get; }
}

public interface IPointQuest : IQuest
{
    string PointName { get; }
}
