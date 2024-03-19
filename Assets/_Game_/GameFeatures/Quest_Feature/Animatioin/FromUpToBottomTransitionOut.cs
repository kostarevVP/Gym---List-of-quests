using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using WKosArch.Services.UIService.Common;

public class FromUpToBottomTransitionOut : Transition
{
    [SerializeField]
    private float _duration = 0.3f;
    [SerializeField]
    private Ease _ease = Ease.OutCirc;

    protected override async UniTask PlayInternal()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();

        await rectTransform.DOAnchorPos(new Vector2(rectTransform.anchoredPosition.x, -rectTransform.rect.height), _duration).SetEase(_ease).ToUniTask();
    }
}
