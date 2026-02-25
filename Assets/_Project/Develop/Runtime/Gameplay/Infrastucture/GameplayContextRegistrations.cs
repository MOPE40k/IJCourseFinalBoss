using UnityEngine;
using Infrastructure.DI;
using Runtime.Meta.Features.Sessions;
using Runtime.Meta.Features.Wallet;
using Runtime.Utils.DataManagement.DataProviders;
using Utils.AssetsManagement;
using Utils.ConfigsManagement;
using Utils.CoroutinesManagement;
using Utils.SceneManagement;
using Runtime.Ui.Gameplay;
using Runtime.Ui.Core;
using Runtime.Ui;

namespace Runtime.Gameplay.Infrastucture
{
    public class GameplayContextRegistrations
    {
        // References
        private static GameplayInputArgs _inputArgs = null;

        public static void Process(DIContainer container, GameplayInputArgs inputArgs)
        {
            _inputArgs = inputArgs;

            container.RegisterAsSingle(CreateGameplayUiRoot).NonLazy();
            container.RegisterAsSingle(CreateGameplayPresentersFactory);
            container.RegisterAsSingle(CreateGameplayScreenPresenter).NonLazy();
            container.RegisterAsSingle(CreateGameplayPopupService);
            container.RegisterAsSingle(CreateSequanceGenerationService);
            container.RegisterAsSingle(CreatePhraseCompareService);
            container.RegisterAsSingle(CreateGameplayCycle);
            container.RegisterAsSingle(CreateGameResultService);
        }

        private static GameplayUiRoot CreateGameplayUiRoot(DIContainer container)
        {
            ResourcesAssetsLoader resourcesAssetsLoader = container
                .Resolve<ResourcesAssetsLoader>();

            GameplayUiRoot gameplayUiRoot = resourcesAssetsLoader
                .Load<GameplayUiRoot>("Ui/Gameplay/GameplayUiRoot_Canvas");

            return GameObject.Instantiate(gameplayUiRoot);
        }

        private static GameplayPresentersFactory CreateGameplayPresentersFactory(DIContainer container)
            => new GameplayPresentersFactory(container);

        private static GameplayScreenPresenter CreateGameplayScreenPresenter(DIContainer container)
        {
            GameplayUiRoot uiRoot = container.Resolve<GameplayUiRoot>();

            GameplayScreenView gameplayScreenView = container
                .Resolve<ViewsFactory>()
                .Create<GameplayScreenView>(ViewIds.GameplayScreenView, uiRoot.HudLayer);

            GameplayScreenPresenter gameplayScreenPresenter = container
                .Resolve<GameplayPresentersFactory>()
                .CreateGameplayScreenPresenter(gameplayScreenView);

            return gameplayScreenPresenter;
        }

        private static GameplayPopupService CreateGameplayPopupService(DIContainer container)
            => new GameplayPopupService(
                container.Resolve<ViewsFactory>(),
                container.Resolve<ProjectPresentersFactory>(),
                container.Resolve<GameplayUiRoot>());

        private static SequenceGenerationService CreateSequanceGenerationService(DIContainer container)
            => new SequenceGenerationService();

        private static PhraseCompareService CreatePhraseCompareService(DIContainer container)
            => new PhraseCompareService();

        private static GameplayCycle CreateGameplayCycle(DIContainer container)
            => new GameplayCycle(
                container.Resolve<SequenceGenerationService>(),
                container.Resolve<GameSessionDetermineService>(),
                container.Resolve<SceneSwitcherService>(),
                container.Resolve<PlayerDataProvider>(),
                container.Resolve<ICoroutinePerformer>(),
                _inputArgs);

        private static GameSessionDetermineService CreateGameResultService(DIContainer container)
            => new GameSessionDetermineService(
                container.Resolve<PhraseCompareService>(),
                container.Resolve<ConfigsProviderService>(),
                container.Resolve<WalletService>(),
                container.Resolve<SessionsResultsCounterService>()
            );
    }
}