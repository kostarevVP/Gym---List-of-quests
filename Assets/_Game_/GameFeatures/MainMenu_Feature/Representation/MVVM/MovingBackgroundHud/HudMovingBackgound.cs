using UnityEngine.UI;
using UnityEngine;
using WKosArch.UIService.Views.HUD;
using System.Resources;

public class HudMovingBackgound : Hud<MovingBackgoundHudViewModel>
{
    [Space]
    [SerializeField]
    private RawImage _rawImage;

    [SerializeField, Range(0, 10)]
    private float _scrollSpeed = 0.1f;

    [SerializeField, Range(-1, 1)]
    private float _xDirection = 1f;

    [SerializeField, Range(-1, 1)]
    private float _yDirection = 1f;
    


    protected override void AwakeInternal()
    {
        base.AwakeInternal();
        SetData();
    }

    private void SetData()
    {
        ViewModel.RawImage = _rawImage;
        ViewModel.ScrollSpeed = _scrollSpeed;
        ViewModel.MoveDirection = new Vector2(_xDirection, _yDirection);
        ViewModel.EnableMove = true;
    }
}