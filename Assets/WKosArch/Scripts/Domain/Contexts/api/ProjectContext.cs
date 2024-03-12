using Assets.LocalPackages.WKosArch.Scripts.Common.DIContainer;
using System.Linq;
using UnityEngine;

namespace WKosArch.Domain.Contexts
{
    public sealed class ProjectContext : Context
    {
        [Space]
        [SerializeField] private SceneContext[] _sceneContexts;

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        public SceneContext GetSceneContext(string sceneName)
        {
            var result = _sceneContexts.FirstOrDefault(c => c.SceneName == sceneName);
            
            return result;
        }

        protected override IDIContainer CreateLocalContainer()
        {
            return new DIContainer();
        }
    }
}