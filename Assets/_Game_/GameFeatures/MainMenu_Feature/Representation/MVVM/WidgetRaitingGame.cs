using UnityEngine;
using UnityEngine.UI;
using WKosArch.UIService.Views.Widgets;

public class WidgetRaitingGame : Widget<RaitingGameWidgetModel>
{
    [SerializeField] private Sprite _emptyStarImage;
    [SerializeField] private Sprite _fullStarImage;
    [Space]
    [SerializeField] private Button[] _starImages; // Масив зображень зірок
    [Space]
    [SerializeField] private string _gameLinkPlayMarket;
}