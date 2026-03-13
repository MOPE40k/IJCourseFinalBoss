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
using Runtime.Gameplay.EntitiesCore;
using Runtime.Gameplay.EntitiesCore.Mono;
using Runtime.Gameplay.Features.Ai;
using Runtime.Gameplay.Features.InputFeature;

namespace Runtime.Gameplay.Infrastucture
{
    public class GameplayContextRegistrations
    {
        // References
        private static GameplayInputArgs _inputArgs = null;

        public static void Process(DIContainer container, GameplayInputArgs inputArgs)
        {
            _inputArgs = inputArgs;

            container.RegisterAsSingle(CreateEntitiesFactory);
            container.RegisterAsSingle(CreateEntitiesLifeContext);
            container.RegisterAsSingle(CreateMonoEntitiesFactory).NonLazy();
            container.RegisterAsSingle(CreateCollidersRegistryService);
            container.RegisterAsSingle(CreateBrainsFactory);
            container.RegisterAsSingle(CreateAiBrainsContext);
            container.RegisterAsSingle<IInputService>(CreateDesktopInput);

            // container.RegisterAsSingle(CreateGameplayUiRoot).NonLazy();
            // container.RegisterAsSingle(CreateGameplayPresentersFactory);
            // container.RegisterAsSingle(CreateGameplayScreenPresenter).NonLazy();
            // container.RegisterAsSingle(CreateGameplayPopupService);
            // container.RegisterAsSingle(CreateSequanceGenerationService);
            // container.RegisterAsSingle(CreatePhraseCompareService);
            // container.RegisterAsSingle(CreateGameplayCycle);
            // container.RegisterAsSingle(CreateGameResultService);
        }

        private static EntitiesFactory CreateEntitiesFactory(DIContainer container)
            => new EntitiesFactory(container);

        private static EntitiesLifeContext CreateEntitiesLifeContext(DIContainer container)
            => new EntitiesLifeContext();

        private static MonoEntitiesFactory CreateMonoEntitiesFactory(DIContainer container)
            => new MonoEntitiesFactory(
                container.Resolve<ResourcesAssetsLoader>(),
                container.Resolve<EntitiesLifeContext>(),
                container.Resolve<CollidersRegistryService>());

        private static CollidersRegistryService CreateCollidersRegistryService(DIContainer container)
            => new CollidersRegistryService();

        private static BrainsFactory CreateBrainsFactory(DIContainer container)
            => new BrainsFactory(container);

        private static AiBrainsContext CreateAiBrainsContext(DIContainer container)
            => new AiBrainsContext();

        private static DesktopInput CreateDesktopInput(DIContainer container)
            => new DesktopInput();

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