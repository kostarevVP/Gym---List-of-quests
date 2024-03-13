using UnityEngine;
using UnityEngine.UI;
using WKosArch.UIService.Views.Windows;

public class MovingBackgroundWindowModel : WindowViewModel
{
    public float ScrollSpeed {  get; set; }
    public Vector2 MoveDirection { get; set; }
    public RawImage RawImage { get; set; }

    public bool EnableMove {  get; set; }

    private void Update()
    {
        if (EnableMove)
        {
            var offset = MoveDirection * ScrollSpeed * Time.deltaTime;

            RawImage.uvRect = new Rect(RawImage.uvRect.position + offset, RawImage.uvRect.size); 
        }
    }
}
