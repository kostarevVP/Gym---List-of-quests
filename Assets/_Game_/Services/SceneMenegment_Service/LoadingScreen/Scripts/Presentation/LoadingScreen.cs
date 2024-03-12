using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using UnityEngine;

namespace WKosArch.Services.Scenes
{
    public class LoadingScreen : MonoBehaviour, ILoadingScreen
    {
        [SerializeField] private GameObject _goContent;
        [SerializeField] private float _delayTime;

        public void Show(Action onComplete = null)
        {
            _goContent.SetActive(true);
            onComplete?.Invoke();
        }

        public async void Hide(Action onComplete = null)
        {
            //StartCoroutine(CloseLoadingScreenWithDelay(_delayTime));
            //SrartCoroutine not await end of enumerator thats why there is unitask awaiter
            await Coroutine(CloseLoadingScreenWithDelay(_delayTime));
            onComplete?.Invoke();
        }

        private async UniTask Coroutine(IEnumerator enumerator)
        {
            await enumerator;
        }

        private IEnumerator CloseLoadingScreenWithDelay(float delay)
        {

            yield return new WaitForSeconds(delay);

            _goContent.SetActive(false);
        }
    }
}