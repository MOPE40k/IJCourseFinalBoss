using UnityEngine;

namespace Utils.AssetsManagement
{
    public class ResourcesAssetsLoader
    {
        public T Load<T>(string resourcePath) where T : UnityEngine.Object
            => Resources.Load<T>(resourcePath);
    }
}