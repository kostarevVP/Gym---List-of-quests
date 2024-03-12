using Assets.LocalPackages.WKosArch.Scripts.Common.DIContainer;
using UnityEngine;

namespace WKosArch.Common.DIContainer
{
    public static class DI
    {
        private static IDIContainer _dIcontainer = null;

        public static void AddDIContainer(IDIContainer dIcontainer)
        {
            _dIcontainer = dIcontainer;
        }

        public static TResolve GetResolve<TResolve>() where TResolve : class
        {
            return _dIcontainer.Resolve<TResolve>();
        }

        public static void Bind<TResolve>(TResolve instance) where TResolve : class
        {
            _dIcontainer?.Bind(instance);
        }

        //need for not Reload Domain each time
        // ProjectSetting > Editor > Enter Play Mode Setting
        [RuntimeInitializeOnLoadMethod]
        static void Init()
        {
            _dIcontainer = null;
        }
    }
}