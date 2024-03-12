using System;

namespace WKosArch.Services.Scenes
{
    public interface ILoadingScreen
    {
        void Show(Action onComplete = null);
        void Hide(Action onComplete = null);
    }
}