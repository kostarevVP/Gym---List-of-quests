using System;
using System.Collections.Generic;

namespace Assets.LocalPackages.WKosArch.Scripts.Common.DIContainer
{
    public interface IDIContainer : IDisposable
    {
        bool IsRoot { get; }
        IDIContainer ChildContainer { get; set; }
        Dictionary<Type, object> Instances { get; }

        void Bind<T>(T instance) where T : class;
        T Resolve<T>() where T : class;
    }
}
