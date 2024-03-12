using System;
using Assets.LocalPackages.WKosArch.Scripts.Common.DIContainer;
using WKosArch.Domain.Features;
using UnityEngine;

namespace WKosArch.Domain.Contexts
{
    public abstract class FeatureInstaller : ScriptableObject, IFeatureInstaller, IDisposable
    {
        public abstract IFeature Create(IDIContainer container);
        public abstract void Dispose();
    }
}