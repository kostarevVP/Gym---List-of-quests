using System;

[Serializable]
public class CollectioinQuest : Quest, ICollectionQuest 
{
    public float ExecutionProgress { get => (float)_currentAmount / _amount; } 
    public string StuffName { get => _stuffName; set => _stuffName = value; }

    public int Amount
    {
        get => _amount; set
        {
            if (_amount != value)
            {
                _amount = value;
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
                _currentAmount = value;
                OnDataChanged?.Invoke(); 
            }
        }
    }

    private string _stuffName;
    private int _amount;
    private int _currentAmount;
}
