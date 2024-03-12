public class CollectioinQuest : ICollectionQuest 
{
    public bool IsDone => _isDone;

    public string Name => _name;

    public string Description => _descrition;

    public float ExecutionProgress => _executionProgress;

    public string StuffName => _stuffName;

    public int Amount => _amount;
    public int CurrentAmount => _currentAmount;


    private bool _isDone;
    private int _currentAmount;

    private string _name;
    private string _descrition;
    private float _executionProgress;
    private string _stuffName;
    private int _amount;


    public CollectioinQuest(string name, string descrition, string stuffName, int amount)
    {
        _name = name;
        _descrition = descrition;
        _stuffName = stuffName;
        _amount = amount;
    }

    public override string ToString()
    {
        return $"Name={_name} {_stuffName} {_amount - _currentAmount}amount left";
    }
}
