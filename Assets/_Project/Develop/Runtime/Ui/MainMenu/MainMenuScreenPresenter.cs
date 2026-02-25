using System.Collections.Generic;
using Runtime.Ui.Core;
using Runtime.Ui.Wallet;
using Runtime.Ui.SessionsResults;
using Runtime.Utils.ConfigsManagement;

namespace Runtime.Ui.MainMenu
{
    public class MainMenuScreenPresenter : ISubscribePresenter
    {
        // References
        private readonly MainMenuScreenView _view = null;
        private readonly ProjectPresentersFactory _projectPresentersFactory = null;
        private readonly MainMenuPopupService _mainMenuPopupService = null;
        private readonly GamemodeConfigProvider _gamemodeConfigProvider = null;

        // Runtime
        private readonly List<IPresenter> _childPresenters = new();

        public MainMenuScreenPresenter(
            MainMenuScreenView view,
            ProjectPresentersFactory projectPresentersFactory,
            MainMenuPopupService mainMenuPopupService,
            GamemodeConfigProvider gamemodeConfigProvider)
        {
            _view = view;
            _projectPresentersFactory = projectPresentersFactory;
            _mainMenuPopupService = mainMenuPopupService;
            _gamemodeConfigProvider = gamemodeConfigProvider;
        }

        public void Init()
        {
            Subscribe();

            CreateWallet();

            CreateSessionsResults();

            foreach (IPresenter presenter in _childPresenters)
                presenter.Init();
        }

        public void Dispose()
        {
            Unsubscribe();

            foreach (IPresenter presenter in _childPresenters)
                presenter.Dispose();

            _childPresenters.Clear();
        }

        public void Subscribe()
        {
            _view.LettersModeButtonClicked += OnLettersModeButtonClicked;
            _view.DigitsModeButtonClicked += OnDigitsModeButtonClicked;
            _view.ResetStatsButtonClicked += OnResetStatsButtonClicked;
        }

        public void Unsubscribe()
        {
            _view.LettersModeButtonClicked -= OnLettersModeButtonClicked;
            _view.DigitsModeButtonClicked -= OnDigitsModeButtonClicked;
            _view.ResetStatsButtonClicked -= OnResetStatsButtonClicked;

        }

        private void CreateWallet()
        {
            WalletPresenter walletPresenter = _projectPresentersFactory
                .CreateWalletPresenter(_view.WalletView);

            _childPresenters.Add(walletPresenter);
        }

        private void CreateSessionsResults()
        {
            SessionsResultsPresenter sessionsResultsPresenter = _projectPresentersFactory
                .CreateSessionsResultsPresenter(_view.SessionsResultsView);

            _childPresenters.Add(sessionsResultsPresenter);
        }

        private void OnLettersModeButtonClicked()
            => _gamemodeConfigProvider.LettersModeLoad();

        private void OnDigitsModeButtonClicked()
            => _gamemodeConfigProvider.DigitsModeLoad();

        private void OnResetStatsButtonClicked()
            => _mainMenuPopupService.OpenResetMenuPopup();
    }
}