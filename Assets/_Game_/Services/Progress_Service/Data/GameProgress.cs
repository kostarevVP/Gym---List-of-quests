using System;
using System.Collections.Generic;

[Serializable]
public class GameProgress
{
    public int SceneIndex;

    public List<IQuest> Quests;
    public IQuest[] QuestArr = new IQuest[] {new CollectioinQuest()};
}
