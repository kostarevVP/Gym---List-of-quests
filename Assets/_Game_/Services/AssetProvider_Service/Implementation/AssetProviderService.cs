using UnityEngine;

namespace WKosArch.Services.AssetProviderService
{
    public class AssetProviderService : IAssetProviderService
    {
        private bool _isReady = true;

        public bool IsReady => _isReady;
        

        public GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }

        public GameObject Instantiate(string path, Vector3 at)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, at, Quaternion.identity);
        }

        public GameObject Instantiate(string path, Vector3 at, Quaternion rotaion)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, at, rotaion);
        }

        public T Load<T>(string path) where T : Object
        {
            return Resources.Load<T>(path);
        }

        public T[] LoadAll<T>(string path) where T : Object
        {
            return Resources.LoadAll<T>(path);
        }

        public GameObject Load(string path)
        {
            return Resources.Load<GameObject>(path);
        }
    }
}
