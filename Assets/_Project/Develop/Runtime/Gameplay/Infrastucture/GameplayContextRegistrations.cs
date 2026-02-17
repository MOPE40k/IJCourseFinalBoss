using Infrastructure.DI;
using Runtime.Meta.Features.Sessions;
using Runtime.Meta.Features.Wallet;
using Runtime.Utils.DataManagement.DataProviders;
using Runtime.Utils.Stats;
using Utils.ConfigsManagement;
using Utils.CoroutinesManagement;
using Utils.SceneManagement;

namespace Runtime.Gameplay.Infrastucture
{
    public class GameplayContextRegistrations
    {
        // References
        private static GameplayInputArgs _inputArgs = null;

        public static void Process(DIContainer container, GameplayInputArgs inputArgs)
        {
            _inputArgs = inputArgs;

            container.RegisterAsSingle(CreateSequanceGenerationService);
            container.RegisterAsSingle(CreatePhraseCompareService);
            container.RegisterAsSingle(CreateGameplayCycle);
            container.RegisterAsSingle(CreateGameResultService);
        }

        private static SequanceGenerationService CreateSequanceGenerationService(DIContainer container)
            => new SequanceGenerationService();

        private static PhraseCompareService CreatePhraseCompareService(DIContainer container)
            => new PhraseCompareService();

        private static GameplayCycle CreateGameplayCycle(DIContainer container)
            => new GameplayCycle(container, _inputArgs);

        private static GameSessionDetermineService CreateGameResultService(DIContainer container)
            => new GameSessionDetermineService(
                container.Resolve<PhraseCompareService>(),
                container.Resolve<SceneSwitcherService>(),
                container.Resolve<ICoroutinePerformer>(),
                container.Resolve<ConfigsProviderService>(),
                container.Resolve<PlayerDataProvider>(),
                container.Resolve<WalletService>(),
                container.Resolve<SessionConditionCounterService>(),
                container.Resolve<StatsShowService>()
            );
    }
}