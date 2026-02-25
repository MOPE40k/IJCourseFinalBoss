using Infrastructure.DI;
using Runtime.Utils.ConfigsManagement;

namespace Runtime.Ui.MainMenu
{
    public class MainMenuPresentersFactory
    {
        // References
        private readonly DIContainer _container = null;

        public MainMenuPresentersFactory(DIContainer container)
            => _container = container;

        public MainMenuScreenPresenter CreateMainMenuScreenPresenter(MainMenuScreenView view)
            => new MainMenuScreenPresenter(
                view,
                _container.Resolve<ProjectPresentersFactory>(),
                _container.Resolve<MainMenuPopupService>(),
                _container.Resolve<GamemodeConfigProvider>());
    }
}