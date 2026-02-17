using Infrastructure.DI;
using Runtime.Utils.ConfigsManagement;
using Utils.ConfigsManagement;
using Utils.CoroutinesManagement;
using Utils.SceneManagement;

namespace Runtime.Meta.Infrastructure
{
    public class MainMenuContextRegistrations
    {
        public static void Process(DIContainer container)
            => container.RegisterAsSingle(CreateGamemodeConfigProvider);

        private static GamemodeConfigProvider CreateGamemodeConfigProvider(DIContainer container)
            => new GamemodeConfigProvider(
                container.Resolve<ConfigsProviderService>(),
                container.Resolve<SceneSwitcherService>(),
                container.Resolve<ICoroutinePerformer>()
            );
    }
}