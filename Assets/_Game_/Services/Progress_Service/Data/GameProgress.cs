using System;
using System.Collections.Generic;

[Serializable]
public class GameProgress
{
    public int SceneIndex;

    public List<IQuest> Quests;
}
