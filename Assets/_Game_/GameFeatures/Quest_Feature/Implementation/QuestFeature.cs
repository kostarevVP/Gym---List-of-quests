using System.Collections.Generic;

public class QuestFeature : IQuestFeature
{
    public bool IsReady => _isReady;
    public List<IQuest> Quests => _quests;


    private bool _isReady;

    private List<IQuest> _quests;

    public QuestFeature(List<IQuest> quests)
    {
        _quests = quests;

        _isReady = true;
    }

    public void SaveProgress(GameProgress progress)
    {
        progress.Quests = _quests;
    }

    public void LoadProgress(GameProgress progress)
    {
        if (progress.Quests != null)
            _quests = progress.Quests;
    }
}
