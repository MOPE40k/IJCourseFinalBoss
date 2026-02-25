using Infrastructure.DI;
using Runtime.Gameplay;

namespace Runtime.Ui.Gameplay
{
    public class GameplayPresentersFactory
    {
        // References
        private readonly DIContainer _container = null;

        public GameplayPresentersFactory(DIContainer container)
            => _container = container;

        public GameplayScreenPresenter CreateGameplayScreenPresenter(GameplayScreenView view)
            => new GameplayScreenPresenter(
                view,
                _container.Resolve<ProjectPresentersFactory>(),
                _container.Resolve<GameplayPopupService>(),
                _container.Resolve<SequenceGenerationService>(),
                _container.Resolve<GameplayCycle>());
    }
}