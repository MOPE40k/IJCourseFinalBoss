using System;
using System.Collections;
using System.Collections.Generic;
using Runtime.Configs;
using UnityEngine;
using Utils.AssetsManagement;

namespace Utils.ConfigsManagement
{
    public class ResourcesConfigsLoader : IConfigsLoader
    {
        // References
        private readonly ResourcesAssetsLoader _resourcesAssetsLoader = null;

        private readonly Dictionary<Type, string> _configsResourcesPaths = new()
        {
            {typeof(DigitsSetConfig), "Configs/DigitsSetConfig"},
            {typeof(LettersSetConfig), "Configs/LettersSetConfig"}
        };

        public ResourcesConfigsLoader(ResourcesAssetsLoader resourcesAssetsLoader)
            => _resourcesAssetsLoader = resourcesAssetsLoader;

        public IEnumerator LoadAsync(Action<Dictionary<Type, object>> onConfigsLoaded)
        {
            Dictionary<Type, object> loadedConfigs = new Dictionary<Type, object>();

            foreach (KeyValuePair<Type, string> configResourcesPath in _configsResourcesPaths)
            {
                ScriptableObject config = _resourcesAssetsLoader.Load<ScriptableObject>(configResourcesPath.Value);

                loadedConfigs.Add(configResourcesPath.Key, config);

                yield return null;
            }

            onConfigsLoaded?.Invoke(loadedConfigs);
        }
    }
}