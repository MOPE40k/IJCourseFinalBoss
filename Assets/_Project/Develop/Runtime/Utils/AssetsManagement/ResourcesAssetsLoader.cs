using UnityEngine;

namespace Utils.AssetsManagement
{
    public class ResourcesAssetsLoader : IService
    {
        public T Load<T>(string resourcePath) where T : UnityEngine.Object
            => Resources.Load<T>(resourcePath);
    }
}