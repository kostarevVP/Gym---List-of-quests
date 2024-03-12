using UnityEngine;

[CreateAssetMenu(fileName = "_JourneyQuestConfig", menuName = "QuestConfig/Configs/JourneyQuestConfig")]
public class JourneyQuestConfig : ScriptableObject
{
    public string Name;
    [TextArea(3, 20)]
    public string Description;
    public string PlaceArrival;
}
