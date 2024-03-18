using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using WKosArch.UIService.Views.Widgets;

public class WidgetSlider : Widget<SliderWidgetModel>
{
    [Space]
    [SerializeField]
    private Slider _slider;

    public override void Refresh()
    {
        base.Refresh();
        _slider.DOValue(ViewModel.ExecutionProgress, 0.3f);
    }
}