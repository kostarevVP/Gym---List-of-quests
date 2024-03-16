public class CollectioinQuest : Quest, ICollectionQuest 
{
    public float ExecutionProgress { get => _executionProgress; set => value = _executionProgress; }

    public string StuffName { get => _stuffName; set => value = _stuffName; }

    public int Amount { get => _amount; set => value = _amount; }
    public int CurrentAmount { get => _currentAmount; set => value = _currentAmount; }

    private float _executionProgress;
    private string _stuffName;
    private int _amount;
    private int _currentAmount;

    public CollectioinQuest(string name, string descrition, string stuffName, int amount)
    {
        Name = name;
        Description = descrition;
        StuffName = stuffName;
        Amount = amount;
    }

    public override string ToString()
    {
        return $"Name={Name} {_stuffName} {_amount - _currentAmount}amount left";
    }
}
