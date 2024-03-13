using UnityEngine.UI;
using UnityEngine;
using WKosArch.UIService.Views.HUD;

public class MovingBackgoundHudViewModel : HudViewModel
{
    public float ScrollSpeed { get; set; }
    public Vector2 MoveDirection { get; set; }
    public RawImage RawImage { get; set; }

    public bool EnableMove { get; set; }

    private void Update()
    {
        if (EnableMove)
        {
            var offset = MoveDirection * ScrollSpeed * Time.deltaTime;

            RawImage.uvRect = new Rect(RawImage.uvRect.position + offset, RawImage.uvRect.size);
        }
    }
}
