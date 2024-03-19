using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using WKosArch.Services.UIService.Common;

public class ScaleTransitionOut : Transition
{
    [SerializeField]
    private float _duration = 1f;
    [SerializeField]
    private Ease _ease = Ease.InOutExpo;


    protected override async UniTask PlayInternal()
    {
        RectTransform rectTransform  = GetComponent<RectTransform>();
        Sequence mySequence = DOTween.Sequence();
        _ = mySequence.Append(rectTransform.DOScale(Vector3.zero, 1f).SetEase(_ease));
        _ = mySequence.Join((rectTransform.DOSizeDelta(new Vector2(1f, 0f), _duration)).SetEase(_ease)) ;

        await mySequence.ToUniTask();
    }
}