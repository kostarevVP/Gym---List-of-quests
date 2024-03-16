using UnityEngine;
using UnityEngine.UI;
using WKosArch.UIService.Views.Windows;

public class WindowQuests : Window<QuestWindowModel>
{
    [Space]
    [SerializeField]
    private Button _activeQuestsButton;
    [SerializeField]
    private Transform _widgetRoot;


    protected override void AwakeInternal()
    {
        base.AwakeInternal();
    }

    public override void Subscribe()
    {
        base.Subscribe();
        _activeQuestsButton.onClick.AddListener(OpenWidget);
    }


    public override void Unsubscribe()
    {
        base.Unsubscribe();
        _activeQuestsButton.onClick.RemoveListener(OpenWidget);
    }

    public void OpenWidget()
    {
        //ViewModel.OpenWidget();
        
    }
}