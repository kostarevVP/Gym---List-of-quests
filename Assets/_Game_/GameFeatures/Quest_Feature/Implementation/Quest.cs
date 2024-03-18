using System;

[Serializable]
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
                _questSate = value;
                OnDataChanged?.Invoke();
            }
        }
    }

    public string Name { get => _name; set => _name = value; }

    public string Description { get => _descrition; set => _descrition = value; }

    private bool _isDone;
    private QuestState _questSate;
    private string _name;
    private string _descrition;

}
