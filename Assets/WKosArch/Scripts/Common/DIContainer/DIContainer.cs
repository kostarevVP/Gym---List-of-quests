using System;
using System.Collections.Generic;

namespace Assets.LocalPackages.WKosArch.Scripts.Common.DIContainer
{
    public class DIContainer : IDIContainer
    {
        public bool IsRoot => _parentContainer == null;
        public IDIContainer ChildContainer { get; set; }
        public Dictionary<Type, object> Instances => _instances;

        private readonly Dictionary<Type, object> _instances = new();
        private readonly IDIContainer _parentContainer;

        public DIContainer() { }

        public DIContainer(IDIContainer parentContainer)
        {
            _parentContainer = parentContainer;
            _parentContainer.ChildContainer = this;
        }

        public void Bind<T>(T instance) where T : class
        {
            var type = typeof(T);

            if (_instances.ContainsKey(type))
            {
                throw new Exception($"You cannot add the same type of instance to container twice. Type: {type}");
            }

            _instances[type] = instance;
        }

        public T Resolve<T>() where T : class
        {
            var type = typeof(T);

            if (_instances.TryGetValue(type, out var foundInstance))
            {
                return (T)foundInstance;
            }

            if (ChildContainer != null && ChildContainer.Instances.TryGetValue(type, out var foundInstanceInChild))
            {
                return (T)foundInstanceInChild;
            }

            if (!IsRoot)
            {
                return _parentContainer.Resolve<T>();
            }

            throw new Exception($"There is no instance of type registered. Type: {type}");
        }

        public void Dispose()
        {
            _instances.Clear();
        }

        public override string ToString()
        {
            string str = $"IsRoot={IsRoot}\n";

            str += "Instances service:\n";
            foreach (var kvp in Instances)
            {
                str += $"  - {kvp.Key.Name}: {kvp.Value}\n";
            }

            return str;
        }
    }
}
