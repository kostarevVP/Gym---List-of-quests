using UnityEngine;
using UnityEngine.UI;
using WKosArch.UIService.Views.Windows;

public class WindowQuests : Window<QuestWindowModel>
{
    [Space]
    [SerializeField]
    private Button _activeQuestsButton;
    [SerializeField]
    private Button _disactiveQuestsButton;
    [SerializeField]
    private Button _newQuestsButton;

    public override void Refresh()
    {
        base.Refresh();

        _newQuestsButton.image.color = _newQuestsButton.colors.normalColor;
        _activeQuestsButton.image.color = _activeQuestsButton.colors.normalColor;
        _disactiveQuestsButton.image.color = _disactiveQuestsButton.colors.normalColor;


        switch (ViewModel.QuestState)
        {
            case QuestState.New:
                _newQuestsButton.image.color = _newQuestsButton.colors.pressedColor;
                break;
            case QuestState.Active:
                _activeQuestsButton.image.color = _activeQuestsButton.colors.pressedColor;
                break;
            case QuestState.Disactive:
                _disactiveQuestsButton.image.color = _disactiveQuestsButton.colors.pressedColor;
                break;
        }
    }

    public override void Subscribe()
    {
        base.Subscribe();
        _activeQuestsButton.onClick.AddListener(() => ViewModel.OpenWidget(QuestState.Active));
        _disactiveQuestsButton.onClick.AddListener(() => ViewModel.OpenWidget(QuestState.Disactive));
        _newQuestsButton.onClick.AddListener(() => ViewModel.OpenWidget(QuestState.New));
    }

}