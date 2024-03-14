using UnityEngine;
using UnityEngine.UI;
using WKosArch.UIService.Views.Windows;

public class QuestWindowModel : WindowViewModel
{

}

public class WindowQuestWindowModel : Window<QuestWindowModel>
{
    [SerializeField]
    private Button _activeQuests;
}