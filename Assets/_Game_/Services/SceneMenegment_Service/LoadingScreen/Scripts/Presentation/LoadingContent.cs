using UnityEngine;

public class LoadingContent : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _scaleFactor = 1f;

    private void Awake()
    {
        SetToCenterScreen();
    }

    private void SetToCenterScreen()
    {
        var canvas = GetComponentInChildren<Canvas>();
        var gameObject = GameObject.Instantiate(_prefab, canvas.transform);
        var rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.pivot = new Vector2(0.5f, 0.5f);
        rectTransform.anchoredPosition = Vector2.zero;

        ScaleObject(rectTransform);
    }

    private void ScaleObject(RectTransform rectTransform)
    {
        rectTransform.localScale = Vector3.one * _scaleFactor;
    }
}
