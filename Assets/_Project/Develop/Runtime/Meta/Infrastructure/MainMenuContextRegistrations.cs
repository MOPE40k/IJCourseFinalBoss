using Infrastructure.DI;
using Runtime.Meta.Features.Stats;
using Runtime.Meta.Features.Wallet;
using Runtime.Utils.ConfigsManagement;
using Runtime.Utils.DataManagement.DataProviders;
using Utils.ConfigsManagement;
using Utils.CoroutinesManagement;
using Utils.SceneManagement;

namespace Runtime.Meta.Infrastructure
{
    public class MainMenuContextRegistrations
    {
        public static void Process(DIContainer container)
        {
            container.RegisterAsSingle(CreateGamemodeConfigProvider);
            container.RegisterAsSingle(CreateResetStatsService);
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
    }
}