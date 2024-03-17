public class CollectioinQuest : Quest, ICollectionQuest 
{
    public float ExecutionProgress { get => _amount / _currentAmount; } 
    public string StuffName { get => _stuffName; set => value = _stuffName; }

    public int Amount
    {
        get => _amount; set
        {
            if (_amount != value)
            {
                value = _amount;
                OnDataChanged?.Invoke(); 
            }
        }
    }
    public int CurrentAmount
    {
        get => _currentAmount; set
        {
            if (_currentAmount != value)
            {
                value = _currentAmount;
                OnDataChanged?.Invoke(); 
            }
        }
    }

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
