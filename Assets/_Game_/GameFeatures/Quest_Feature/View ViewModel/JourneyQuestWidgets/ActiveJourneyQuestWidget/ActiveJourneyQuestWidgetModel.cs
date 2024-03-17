using UnityEngine;
using UnityEngine.UI;
using WKosArch.UIService.Views.Widgets;

public class ActiveJourneyQuestWidgetModel : WidgetViewModel
{

}

public class WidgetActiveJourneyQuest : Widget<ActiveJourneyQuestWidgetModel>
{
    [Space]
    [SerializeField]
    private Button _endQuestButton;
    [SerializeField]
    private Button _cancelQuestButton;
}