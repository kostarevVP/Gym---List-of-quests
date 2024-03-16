using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using WKosArch.UIService.Views.Windows;

public class WindowQuestWindowModel : Window<QuestWindowModel>
{
    [Space]
    [SerializeField]
    private Button _activeQuestsButton;
    [SerializeField]
    private Button _disactiveQuestsButton;
    [SerializeField]
    private Button _newQuestsButton;
    [Space]
    [SerializeField]
    private Transform _widgetRoot;


    protected override void AwakeInternal()
    {
        base.AwakeInternal();
        SetData();
    }

    public override void Subscribe()
    {
        base.Subscribe();
        _activeQuestsButton.onClick.AddListener(() => ViewModel.OpenWidget(QuestState.Active));
        _disactiveQuestsButton.onClick.AddListener(() => ViewModel.OpenWidget(QuestState.Disactive));
        _newQuestsButton.onClick.AddListener(() => ViewModel.OpenWidget(QuestState.New));
    }


    private void SetData()
    {
        ViewModel.WidgetRoot = _widgetRoot;
    }

}