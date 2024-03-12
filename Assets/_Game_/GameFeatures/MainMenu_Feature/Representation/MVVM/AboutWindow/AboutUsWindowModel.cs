using UnityEngine;
using WKosArch.UIService.Views.Windows;

public class AboutUsWindowModel : WindowViewModel
{
    internal void OpenLink(string link)
    {
        Application.OpenURL(link);
    }
}
