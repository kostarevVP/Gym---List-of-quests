using TMPro;
using UnityEngine;
using WKosArch.UIService.Views.Widgets;

public class WidgetQuestBaseWidgetModel : Widget<QuestBaseWidgetModel>
{
    [Space]
    [SerializeField]
    private TextMeshProUGUI TitleTMProUGUI;
    [SerializeField]
    private TextMeshProUGUI DescriptionTMProUGUI;

    public override void Refresh()
    {
        base.Refresh();
        TitleTMProUGUI.text = ViewModel.Title;
        DescriptionTMProUGUI.text = ViewModel.Description;
    }
}