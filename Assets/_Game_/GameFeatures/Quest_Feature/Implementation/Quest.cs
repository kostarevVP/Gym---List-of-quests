public abstract class Quest : IQuest
{
    public bool IsDone => _isDone;

    public string Name => _name;

    public string Description => _descrition;

    public float ExecutionProgress => _executionProgress;

    private bool _isDone;
    private string _name;
    private string _descrition;
    private float _executionProgress;

    public Quest(string name, string descrition)
    {
        _name = name;
        _descrition = descrition;
    }
}
