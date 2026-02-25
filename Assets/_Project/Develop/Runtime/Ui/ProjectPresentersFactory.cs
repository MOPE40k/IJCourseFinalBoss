using Infrastructure.DI;
using Runtime.Configs.Meta.SessionResult;
using Runtime.Configs.Meta.Wallet;
using Runtime.Meta.Features.LevelProgression;
using Runtime.Meta.Features.Sessions;
using Runtime.Meta.Features.Stats;
using Runtime.Meta.Features.Wallet;
using Runtime.Ui.CommonViews;
using Runtime.Ui.Core;
using Runtime.Ui.LevelMenuPopup;
using Runtime.Ui.ResetStatsPopup;
using Runtime.Ui.SessionsResults;
using Runtime.Ui.TextField;
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

        public LevelTilePresenter CreateLevelTilePresenter(LevelTileView view, int levelNumber)
            => new LevelTilePresenter(
                _container.Resolve<LevelProgressionService>(),
                _container.Resolve<SceneSwitcherService>(),
                _container.Resolve<ICoroutinePerformer>(),
                view,
                levelNumber);

        public LevelsMenuPopupPresenter CreateLevelsPopupMenuPresenter(LevelsMenuPopupView view)
            => new LevelsMenuPopupPresenter(
                _container.Resolve<ConfigsProviderService>(),
                this,
                _container.Resolve<ViewsFactory>(),
                view,
                _container.Resolve<ICoroutinePerformer>());

        public ResetStatsPopupPresenter CreateResetStatsPopupPresenter(ResetStatsPopupView view)
            => new ResetStatsPopupPresenter(
                view,
                _container.Resolve<ResetStatsService>(),
                _container.Resolve<ICoroutinePerformer>());

        public ResultPresenter CreateResultPresenter(
            IReadOnlyVeriable<int> result,
            SessionEndConditionTypes sessionEndConditionType,
            IconTextView view)
        {
            return new ResultPresenter(
                result,
                sessionEndConditionType,
                _container.Resolve<ConfigsProviderService>().GetConfig<SessionResultIconConfig>(),
                view);
        }

        public SessionsResultsPresenter CreateSessionsResultsPresenter(IconTextListView view)
            => new SessionsResultsPresenter(
                _container.Resolve<SessionsResultsCounterService>(),
                _container.Resolve<ProjectPresentersFactory>(),
                _container.Resolve<ViewsFactory>(),
                view);

        public TextFieldPresenter CreateTextFieldPresenter(
            IReadOnlyVeriable<string> text,
            TextView view)
        {
            return new TextFieldPresenter(text, view);
        }
    }
}