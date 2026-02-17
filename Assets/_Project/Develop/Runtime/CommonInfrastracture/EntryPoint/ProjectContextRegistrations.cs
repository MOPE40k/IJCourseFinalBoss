using Infrastructure.DI;
using Utils.CoroutinesManagement;
using Utils.AssetsManagement;
using Utils.ConfigsManagement;
using UnityEngine;
using Utils.SceneManagement;
using Utils.LoadingScreen;
using System;
using Runtime.Meta.Features.Wallet;
using System.Collections.Generic;
using Utils.Reactive;

namespace Infrastracture.EntryPoint
{
    public class ProjectContextRegistrations
    {
        // Consts
        public static readonly string UtilsPath = "Utils/";
        public static readonly string CoroutinePerformerPrefabName = "CoroutinePerformer";
        public static readonly string LoadingScreenPrefabName = "LoadingScreen";

        public static void Process(DIContainer container)
        {
            container.RegisterAsSingle(CreateResourcesAssetsLoader)
                .RegisterAsSingle<ICoroutinePerformer>(CreateCoroutinePerformer)
                .RegisterAsSingle<ILoadingScreen>(CreateLoadingScreen)
                .RegisterAsSingle(CreateConfigsProviderService)
                .RegisterAsSingle(CreateSceneLoaderService)
                .RegisterAsSingle(CreateSceneSwitcherService)
                .RegisterAsSingle(CreateWalletService);
        }

        private static CoroutinePerformer CreateCoroutinePerformer(DIContainer container)
        {
            ResourcesAssetsLoader resourcesAssetsLoader = container.Resolve<ResourcesAssetsLoader>();

            CoroutinePerformer coroutinePerformer = resourcesAssetsLoader
                .Load<CoroutinePerformer>(UtilsPath + CoroutinePerformerPrefabName);

            return GameObject.Instantiate(coroutinePerformer);
        }

        private static StandartLoadingScreen CreateLoadingScreen(DIContainer container)
        {
            ResourcesAssetsLoader resourcesAssetsLoader = container.Resolve<ResourcesAssetsLoader>();

            StandartLoadingScreen standartLoadingScreen = resourcesAssetsLoader
                .Load<StandartLoadingScreen>(UtilsPath + LoadingScreenPrefabName);

            return GameObject.Instantiate(standartLoadingScreen);
        }

        private static ResourcesAssetsLoader CreateResourcesAssetsLoader(DIContainer container)
            => new ResourcesAssetsLoader();

        private static ConfigsProviderService CreateConfigsProviderService(DIContainer container)
        {
            ResourcesAssetsLoader resourcesAssetsLoader = container.Resolve<ResourcesAssetsLoader>();

            ResourcesConfigsLoader resourcesConfigsLoader = new ResourcesConfigsLoader(resourcesAssetsLoader);

            return new ConfigsProviderService(new IConfigsLoader[]
            {
                resourcesConfigsLoader
            });
        }

        private static SceneLoaderService CreateSceneLoaderService(DIContainer container)
            => new SceneLoaderService();

        private static SceneSwitcherService CreateSceneSwitcherService(DIContainer container)
            => new SceneSwitcherService(
                container.Resolve<SceneLoaderService>(),
                container.Resolve<ILoadingScreen>(),
                container
            );

        private static WalletService CreateWalletService(DIContainer container)
        {
            Dictionary<CurrencyTypes, ReactiveVeriable<int>> currencies = new();

            foreach (CurrencyTypes type in Enum.GetValues(typeof(CurrencyTypes)))
                currencies[type] = new ReactiveVeriable<int>();

            return new WalletService(currencies);
        }
    }
}