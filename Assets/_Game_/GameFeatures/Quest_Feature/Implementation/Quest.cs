using System;

public abstract class Quest : IQuest
{
    //занаю что надо разобратся с Obserevble
    public Action OnDataChanged { get; set; }


    public bool IsComplete
    {
        get => _isDone; set
        {
            if (_isDone != value)
            {
                _isDone = value;
                OnDataChanged?.Invoke();
            }
        }
    }

    public QuestState State
    {
        get => _questSate; set
        {
            if (_questSate != value)
            {
                value = _questSate;
                OnDataChanged?.Invoke();
            }
        }
    }

    public string Name { get => _name; set => value = _name; }

    public string Description { get => _descrition; set => value = _descrition; }

    private bool _isDone;
    private QuestState _questSate;
    private string _name;
    private string _descrition;

}
