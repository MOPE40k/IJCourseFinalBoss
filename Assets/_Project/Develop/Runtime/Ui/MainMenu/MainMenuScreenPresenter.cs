using System.Collections.Generic;
using Runtime.Ui.MainMenu;
using Runtime.Ui.Core;
using Runtime.Ui.Wallet;
using System;

namespace Runtime.Ui.MainMenu
{
    public class MainMenuScreenPresenter : IPresenter
    {
        // References
        private readonly MainMenuScreenView _mainMenuScreenView = null;
        private readonly ProjectPresentersFactory _projectPresentersFactory = null;
        private readonly MainMenuPopupService _mainMenuPopupService = null;

        // Runtime
        private readonly List<IPresenter> _childPresenters = new();

        public MainMenuScreenPresenter(
            MainMenuScreenView mainMenuScreenView,
            ProjectPresentersFactory projectPresentersFactory,
            MainMenuPopupService mainMenuPopupService)
        {
            _mainMenuScreenView = mainMenuScreenView;
            _projectPresentersFactory = projectPresentersFactory;
            _mainMenuPopupService = mainMenuPopupService;
        }

        public void Init()
        {
            _mainMenuScreenView.OnLevelsMenuButtonClicked += OnOpenLevelsMenuButtonClicked;

            CreateWallet();

            foreach (IPresenter presenter in _childPresenters)
                presenter.Init();
        }

        public void Dispose()
        {
            _mainMenuScreenView.OnLevelsMenuButtonClicked -= OnOpenLevelsMenuButtonClicked;

            foreach (IPresenter presenter in _childPresenters)
                presenter.Dispose();

            _childPresenters.Clear();
        }

        private void CreateWallet()
        {
            WalletPresenter walletPresenter = _projectPresentersFactory.CreateWalletPresenter(_mainMenuScreenView.WalletView);

            _childPresenters.Add(walletPresenter);
        }

        private void OnOpenLevelsMenuButtonClicked()
        {
            _mainMenuPopupService.OpenLevelPopup();
        }
    }
}