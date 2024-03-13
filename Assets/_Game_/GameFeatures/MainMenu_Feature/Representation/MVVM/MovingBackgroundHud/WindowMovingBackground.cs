
using System;
using UnityEngine;
using UnityEngine.UI;
using WKosArch.UIService.Views.Windows;

public class WindowMovingBackground : Window<MovingBackgroundWindowModel>
{
    private RawImage _image;

    [SerializeField, Range(0, 10)]
    private float _scrollSpeed = 0.1f;

    [SerializeField, Range(-1, 1)] 
    private float _xDirection = 1f;

    [SerializeField, Range(-1, 1)] 
    private float _yDirection = 1f;


    protected override void AwakeInternal()
    {
        base.AwakeInternal();
        _image = GetComponent<RawImage>();
        SetData();
    }

    private void SetData()
    {
        ViewModel.RawImage = _image;
        ViewModel.ScrollSpeed = _scrollSpeed;
        ViewModel.MoveDirection = new Vector2(_xDirection, _yDirection);
        ViewModel.EnableMove = true;
    }
}