using System;
using System.Collections;
using System.Collections.Generic;
using Runtime.Configs.Gameplay.Gamemodes;
using Runtime.Configs.Gameplay.Levels;
using Runtime.Configs.Meta.SessionResult;
using Runtime.Configs.Meta.Wallet;
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
            {typeof(DigitsSetConfig), "Configs/Gameplay/Gamemodes/DigitsSetConfig"},
            {typeof(LettersSetConfig), "Configs/Gameplay/Gamemodes/LettersSetConfig"},
            {typeof(StartWalletConfig), "Configs/Meta/Wallet/StartWalletConfig"},
            {typeof(ActionsCostsConfig), "Configs/Meta/ActionsCosts/ActionCostsConfig"},
            {typeof(CurrencyIconsConfig), "Configs/Meta/Wallet/CurrencyIconsConfig"},
            {typeof(SessionResultIconConfig), "Configs/Meta/SessionsResults/SessionResultIconConfig"},
            {typeof(LevelsListConfig), "Configs/Gameplay/Levels/LevelsListConfig"}
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