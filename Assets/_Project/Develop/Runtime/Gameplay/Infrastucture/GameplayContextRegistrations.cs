using Infrastructure.DI;
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

            container.RegisterAsSingle(CreateSequanceGenerationService)
                .RegisterAsSingle(CreatePhraseCompareService)
                .RegisterAsSingle(CreateGameplayCycle)
                .RegisterAsSingle(CreateGameResultService);
        }

        private static SequanceGenerationService CreateSequanceGenerationService(DIContainer container)
            => new SequanceGenerationService();

        private static PhraseCompareService CreatePhraseCompareService(DIContainer container)
            => new PhraseCompareService();

        private static GameplayCycle CreateGameplayCycle(DIContainer container)
            => new GameplayCycle(container, _inputArgs);

        private static GameResultService CreateGameResultService(DIContainer container)
            => new GameResultService(
                container.Resolve<PhraseCompareService>(),
                container.Resolve<SceneSwitcherService>(),
                container.Resolve<ICoroutinePerformer>()
            );
    }
}