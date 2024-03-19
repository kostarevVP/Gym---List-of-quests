using UnityEngine;
using UnityEngine.UI;
using WKosArch.UIService.Views.Windows;

public class WindowQuestButton : Window<QuestButtonWindowModel>
{
    [Space]
    [SerializeField]
    private Button _questButton;

    public override void Subscribe()
    {
        base.Subscribe();
        _questButton.onClick.AddListener(() => ViewModel.OpenQuestWindow());
    }
}