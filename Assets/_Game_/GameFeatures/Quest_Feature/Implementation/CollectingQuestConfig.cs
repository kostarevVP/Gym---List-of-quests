using UnityEngine;

[CreateAssetMenu(fileName = "_CollectingQuestConfig", menuName = "QuestConfig/Configs/CollectingQuestConfig")]
public class CollectingQuestConfig : ScriptableObject
{
    public string Name;
    [TextArea(3, 20)]
    public string Description;
    public string StuffName;
    public int Amount;
}
