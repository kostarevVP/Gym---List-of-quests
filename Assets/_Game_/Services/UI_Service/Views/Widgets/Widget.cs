using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using WKosArch.Services.UIService.Common;

namespace WKosArch.UIService.Views.Widgets
{
    public abstract class Widget<TWidgetViewModel> : View<TWidgetViewModel>, IWidget<TWidgetViewModel>
        where TWidgetViewModel : WidgetViewModel
    {
        public event Action<WidgetViewModel> Hidden;
        public event Action<WidgetViewModel> Destroyed;

        [Header("Transitions")]
        [SerializeField] private Transition _transitionIn = default;
        [SerializeField] private Transition _transitionOut = default;

        public bool IsShown { get; private set; }

        public async UniTask<IWidget> Show()
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

        public async UniTask<IWidget> Hide(bool forced = false)
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

        public IWidget HideInstantly()
        {
            if (ViewModel.IsSingleInstance)
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

       
    }
}
