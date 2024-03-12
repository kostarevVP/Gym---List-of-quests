using UnityEngine;

namespace WKosArch.UIService.Views
{
    public abstract class View<TViewModel> : MonoBehaviour, IView<TViewModel> where TViewModel : ViewModel
    {
        public bool IsActive => gameObject.activeInHierarchy;
        public TViewModel ViewModel { get; private set; }

        private void Awake()
        {
            ViewModel = GetComponent<TViewModel>();

            AwakeInternal();
        }

        protected virtual void AwakeInternal() { }


        public virtual void Refresh() { }
        public virtual void Subscribe() { }
        public virtual void Unsubscribe() { }
    }
}