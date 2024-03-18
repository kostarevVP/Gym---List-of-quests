using Cysharp.Threading.Tasks;
using UnityEngine;

namespace WKosArch.Services.UIService.Common
{
    public abstract class Transition : MonoBehaviour
    {
        public bool IsPlaying { get; private set; }

        public async UniTask Play()
        {
            IsPlaying = true;

            await PlayInternal();

            IsPlaying = false;
        }

        protected abstract UniTask PlayInternal();
    }
}