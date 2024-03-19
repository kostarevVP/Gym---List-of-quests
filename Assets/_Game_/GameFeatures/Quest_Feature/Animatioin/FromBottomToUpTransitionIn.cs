using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using WKosArch.Services.UIService.Common;

public class FromBottomToUpTransitionIn : Transition
{
    [SerializeField]
    private float _duration = 0.3f;
    [SerializeField]
    private Ease _ease = Ease.InCirc;

    protected override async UniTask PlayInternal()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();

        Vector2 offscreenPosition = new Vector2(rectTransform.anchoredPosition.x, rectTransform.rect.height);

        await rectTransform.DOAnchorPos(rectTransform.anchoredPosition, _duration).SetEase(_ease).From(offscreenPosition).ToUniTask();
    }
}
