using Runtime.Ui.MainMenu;
using Infrastructure.DI;
using Runtime.Meta.Features.Stats;
using Runtime.Meta.Features.Wallet;
using Runtime.Utils.ConfigsManagement;
using Runtime.Utils.DataManagement.DataProviders;
using UnityEngine;
using Utils.AssetsManagement;
using Utils.ConfigsManagement;
using Utils.CoroutinesManagement;
using Utils.SceneManagement;
using Runtime.Ui.Core;
using Runtime.Ui;

namespace Runtime.Meta.Infrastructure
{
    public class MainMenuContextRegistrations
    {
        public static void Process(DIContainer container)
        {
            container.RegisterAsSingle(CreateGamemodeConfigProvider);
            container.RegisterAsSingle(CreateResetStatsService);
            container.RegisterAsSingle(CreateMainMenuUiRoot).NonLazy();
            container.RegisterAsSingle(CreateMainMenuPresentersFactory);
            container.RegisterAsSingle(CreateMainMenuScreenPresenter).NonLazy();
            container.RegisterAsSingle(CreateMainMenuPopupService);
        }

        private static GamemodeConfigProvider CreateGamemodeConfigProvider(DIContainer container)
            => new GamemodeConfigProvider(
                container.Resolve<ConfigsProviderService>(),
                container.Resolve<SceneSwitcherService>(),
                container.Resolve<ICoroutinePerformer>()
            );

        private static ResetStatsService CreateResetStatsService(DIContainer container)
            => new ResetStatsService(
                container.Resolve<WalletService>(),
                container.Resolve<PlayerDataProvider>(),
                container.Resolve<ConfigsProviderService>(),
                container.Resolve<ICoroutinePerformer>()
            );

        private static MainMenuUiRoot CreateMainMenuUiRoot(DIContainer container)
        {
            ResourcesAssetsLoader resourcesAssetsLoader = container.Resolve<ResourcesAssetsLoader>();

            MainMenuUiRoot mainMenuUiRoot = resourcesAssetsLoader.Load<MainMenuUiRoot>("Ui/MainMenu/MainMenuUiRoot_Canvas");

            return GameObject.Instantiate(mainMenuUiRoot);
        }

        private static MainMenuPresentersFactory CreateMainMenuPresentersFactory(DIContainer container)
            => new MainMenuPresentersFactory(container);

        private static MainMenuScreenPresenter CreateMainMenuScreenPresenter(DIContainer container)
        {
            MainMenuUiRoot mainMenuUiRoot = container.Resolve<MainMenuUiRoot>();

            MainMenuScreenView mainMenuScreenView = container
                .Resolve<ViewsFactory>()
                .Create<MainMenuScreenView>(ViewIds.MainMenuScreenView, mainMenuUiRoot.HudLayer);

            MainMenuScreenPresenter mainMenuScreenPresenter = container
                .Resolve<MainMenuPresentersFactory>()
                .CreatMainMenuScreenPresenter(mainMenuScreenView);

            return mainMenuScreenPresenter;
        }

        private static MainMenuPopupService CreateMainMenuPopupService(DIContainer container)
        {
            return new MainMenuPopupService(
                container.Resolve<ViewsFactory>(),
                container.Resolve<ProjectPresentersFactory>(),
                container.Resolve<MainMenuUiRoot>()
            );
        }
    }
}