public abstract class Quest : IQuest
{
    public bool IsComplete { get => _isDone; set => value = _isDone; }

    public QuestState State { get => _questSate; set => value = _questSate; }

    public string Name { get => _name; set => value = _name; }

    public string Description { get => _descrition; set => value = _descrition; }


    private bool _isDone;
    private QuestState _questSate;
    private string _name;
    private string _descrition;

}
