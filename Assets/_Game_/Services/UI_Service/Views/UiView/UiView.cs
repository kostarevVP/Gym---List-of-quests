using System;
using WKosArch.UIService.Views;
using Cysharp.Threading.Tasks;
using UnityEngine;
using WKosArch.Services.UIService.Common;

namespace Assets._Game_.Services.UI_Service.Views.UiView
{
    public abstract class UiView<TUiViewModel> : View<TUiViewModel>, IUiView<TUiViewModel>
        where TUiViewModel : UiViewModel
    {
        public event Action<UiViewModel> Hidden;
        public event Action<UiViewModel> Destroyed;

        [Header("Transitions")]
        [SerializeField] private Transition _transitionIn = default;
        [SerializeField] private Transition _transitionOut = default;

        public bool IsShown { get; private set; }

        public async UniTask<IUiView> Show()
        {
            IsShown = true;

            gameObject.SetActive(true);
            transform.SetAsLastSibling();

            if (_transitionIn != null)
            {
                await _transitionIn.Play();
            }

            return this;
        }

        public async UniTask<IUiView> Hide(bool forced = false)
        {
            if (_transitionIn != null && _transitionIn.IsPlaying && !forced)
            {
                return this;
            }

            if (_transitionOut != null && !forced)
            {
                if (_transitionOut.IsPlaying)
                {
                    return this;
                }

                await _transitionOut.Play();
            }

            HideInstantly();

            IsShown = false;
            return this;
        }

        public IUiView HideInstantly()
        {
            if (ViewModel.WindowSettings.IsPreCached)
            {
                gameObject.SetActive(false);
                Hidden?.Invoke(ViewModel);
            }
            else
            {
                Destroy(gameObject);
            }

            return this;
        }

        protected virtual void OnDestroy()
        {
            Destroyed?.Invoke(ViewModel);
        }

        //public override void Subscribe()
        //{
        //    base.Subscribe();
        //}

        //public override void Unsubscribe()
        //{
        //    base.Unsubscribe();
        //}
    }
}
