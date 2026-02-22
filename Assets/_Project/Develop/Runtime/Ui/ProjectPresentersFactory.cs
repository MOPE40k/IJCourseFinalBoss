using Infrastructure.DI;
using Runtime.Configs.Meta.Wallet;
using Runtime.Meta.Features.LevelProgression;
using Runtime.Meta.Features.Wallet;
using Runtime.Ui.CommonViews;
using Runtime.Ui.Core;
using Runtime.Ui.Core.TestPopup;
using Runtime.Ui.LevelMenuPopup;
using Runtime.Ui.Wallet;
using Utils.ConfigsManagement;
using Utils.CoroutinesManagement;
using Utils.Reactive;
using Utils.SceneManagement;

namespace Runtime.Ui
{
    public class ProjectPresentersFactory
    {
        // References
        public readonly DIContainer _container = null;

        public ProjectPresentersFactory(DIContainer container)
            => _container = container;

        public CurrencyPresenter CreateCurrencyPresenter(
            IReadOnlyVeriable<int> currency,
            CurrencyTypes currencyType,
            IconTextView view)
        {
            return new CurrencyPresenter(
                currency,
                currencyType,
                _container.Resolve<ConfigsProviderService>().GetConfig<CurrencyIconsConfig>(),
                view);
        }

        public WalletPresenter CreateWalletPresenter(IconTextListView view)
            => new WalletPresenter(
                _container.Resolve<WalletService>(),
                this,
                _container.Resolve<ViewsFactory>(),
                view);

        public TestPopupPresenter CreateTestPopupPresenter(TestPopupView view)
            => new TestPopupPresenter(
                view,
                _container.Resolve<ICoroutinePerformer>());

        public LevelTilePresenter CreateLevelTilePresenter(LevelTileView view, int levelNumber)
            => new LevelTilePresenter(
                _container.Resolve<LevelProgressionService>(),
                _container.Resolve<SceneSwitcherService>(),
                _container.Resolve<ICoroutinePerformer>(),
                view,
                levelNumber);

        public LevelsPopupMenuPresenter CreateLevelsPopupMenuPresenter(LevelsMenuPopupView view)
            => new LevelsPopupMenuPresenter(
                _container.Resolve<ConfigsProviderService>(),
                this,
                _container.Resolve<ViewsFactory>(),
                view,
                _container.Resolve<ICoroutinePerformer>()
            );
    }
}