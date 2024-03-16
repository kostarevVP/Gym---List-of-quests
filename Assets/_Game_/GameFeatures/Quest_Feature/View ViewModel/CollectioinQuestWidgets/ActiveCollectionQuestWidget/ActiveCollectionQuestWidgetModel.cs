using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WKosArch.UIService.Views.Widgets;

public class ActiveCollectionQuestWidgetModel : WidgetViewModel
{
    protected override void AwakeInternal()
    {
        base.AwakeInternal();
    }
}

public class WidgetActiveCollectionQuest : Widget<ActiveCollectionQuestWidgetModel>
{
    [Space]
    [SerializeField]
    private Button _plusButton;
    [SerializeField]
    private Button _minusButton;
    [SerializeField]
    private Button _cancelButton;
    [Space]
    [SerializeField]
    public TMP_Text Title;

    public override void Refresh()
    {
        base.Refresh();
    }
}