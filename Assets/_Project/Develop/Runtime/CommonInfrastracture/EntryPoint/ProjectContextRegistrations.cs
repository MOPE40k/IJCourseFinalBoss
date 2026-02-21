using System;
using Infrastructure.DI;
using Utils.CoroutinesManagement;
using Utils.AssetsManagement;
using Utils.ConfigsManagement;
using UnityEngine;
using Utils.SceneManagement;
using Utils.LoadingScreen;
using Runtime.Meta.Features.Wallet;
using System.Collections.Generic;
using Utils.Reactive;
using Runtime.Utils.DataManagement;
using Utils.DataManagement.KeyStorage;
using Utils.DataManagement.Serializers;
using Runtime.Utils.Stats;
using Runtime.Utils.DataManagement.DataRepository;
using Runtime.Utils.DataManagement.DataProviders;
using Runtime.Meta.Features.Sessions;

namespace Infrastracture.EntryPoint
{
    public class ProjectContextRegistrations
    {
        // Consts
        public static readonly string UtilsPath = "Utils/";
        public static readonly string CoroutinePerformerPrefabName = "CoroutinePerformer";
        public static readonly string LoadingScreenPrefabName = "LoadingScreen";
        public static readonly string LocalDataFileExtension = "json";

        public static void Process(DIContainer container)
        {
            container.RegisterAsSingle(CreateResourcesAssetsLoader);
            container.RegisterAsSingle<ICoroutinePerformer>(CreateCoroutinePerformer);
            container.RegisterAsSingle<ILoadingScreen>(CreateLoadingScreen);
            container.RegisterAsSingle(CreateConfigsProviderService);
            container.RegisterAsSingle(CreateSceneLoaderService);
            container.RegisterAsSingle(CreateSceneSwitcherService);
            container.RegisterAsSingle(CreateWalletService).NonLazy();
            container.RegisterAsSingle(CreateSessionConditionCounterService).NonLazy();
            container.RegisterAsSingle<ISaveLoadService>(CreateSaveLoadService);
            container.RegisterAsSingle(CreatePlayerDataProvider);
            container.RegisterAsSingle(CreateStatsShowService);
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

            return new WalletService(
                currencies,
                container.Resolve<PlayerDataProvider>());
        }

        private static SessionConditionCounterService CreateSessionConditionCounterService(DIContainer container)
        {
            Dictionary<SessionEndConditionTypes, ReactiveVeriable<int>> sessionsResults = new();

            foreach (SessionEndConditionTypes type in Enum.GetValues(typeof(SessionEndConditionTypes)))
                sessionsResults[type] = new ReactiveVeriable<int>();

            return new SessionConditionCounterService(
                sessionsResults,
                container.Resolve<PlayerDataProvider>()
            );
        }

        private static SaveLoadService CreateSaveLoadService(DIContainer container)
        {
            IDataKeysStorage keysStorage = new MapDataKeysStorage();
            IDataSerializer serializer = new JsonSerializer();

            string persistantDataPath = Application.isEditor
                ? Application.dataPath
                : Application.persistentDataPath;

            IDataRepository repository = new LocalFileDataRepository(persistantDataPath, LocalDataFileExtension);

            return new SaveLoadService(keysStorage, serializer, repository);
        }

        private static PlayerDataProvider CreatePlayerDataProvider(DIContainer container)
            => new PlayerDataProvider(
                container.Resolve<ISaveLoadService>(),
                container.Resolve<ConfigsProviderService>()
            );

        private static StatsShowService CreateStatsShowService(DIContainer container)
            => new StatsShowService(
                container.Resolve<SessionConditionCounterService>(),
                container.Resolve<WalletService>()
            );
    }
}