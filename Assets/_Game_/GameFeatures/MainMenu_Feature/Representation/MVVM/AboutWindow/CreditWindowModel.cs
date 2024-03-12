using UnityEngine;
using WKosArch.UIService.Views.Windows;


public class CreditWindowModel : WindowViewModel
{
    internal void OpenLink(string link)
    {
        Application.OpenURL(link);
    }
}
