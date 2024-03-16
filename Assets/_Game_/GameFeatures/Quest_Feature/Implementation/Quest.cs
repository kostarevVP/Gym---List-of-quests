public abstract class Quest : IQuest
{
    public bool IsComplete => _isDone;

    public string Name => _name;

    public string Description => _descrition;

    public float ExecutionProgress => _executionProgress;

    public QuestState QuestState => _questState;

    private bool _isDone;
    private string _name;
    private string _descrition;
    private float _executionProgress;
    private QuestState _questState;

    public Quest(string name, string descrition)
    {
        _name = name;
        _descrition = descrition;
    }
}
