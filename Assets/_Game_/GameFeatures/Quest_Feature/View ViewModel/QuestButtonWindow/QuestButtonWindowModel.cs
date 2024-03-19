using WKosArch.UIService.Views.Windows;

public class QuestButtonWindowModel : WindowViewModel, IHomeWindow
{
    internal void OpenQuestWindow()
    {
        UI.Show<QuestWindowModel>();
    }
}
