using Assets.LocalPackages.WKosArch.Scripts.Common.DIContainer;
using WKosArch.Application;
using UnityEngine;

namespace WKosArch.Domain.Contexts
{
    public sealed class SceneContext : Context
    {
        [Space]
#if UNITY_EDITOR
        [SerializeField] private UnityEditor.SceneAsset _scene;
#endif
        [HideInInspector] public string SceneName;

        private void OnValidate()
        {
#if UNITY_EDITOR
            if (_scene != null)
            {
                SceneName = _scene.name;
            }
#endif
        }

        protected override IDIContainer CreateLocalContainer()
        {
            var rootContainer = Game.ProjectContext.Container;
            return new DIContainer(rootContainer);
        }
    }
}