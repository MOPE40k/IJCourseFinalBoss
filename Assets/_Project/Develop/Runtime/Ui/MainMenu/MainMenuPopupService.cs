using Runtime.Ui.Core;
using UnityEngine;
using System;


namespace Runtime.Ui.MainMenu
{
    public class MainMenuPopupService : PopupService
    {
        private readonly MainMenuUiRoot _mainMenuUiRoot = null;

        public MainMenuPopupService(
            ViewsFactory viewsFactory,
            ProjectPresentersFactory projectPresentersFactory,
            MainMenuUiRoot mainMenuUiRoot)
            : base(viewsFactory, projectPresentersFactory)
        {
            _mainMenuUiRoot = mainMenuUiRoot;
        }

        protected override Transform PopupLayer => _mainMenuUiRoot.PopupsLayer;
    }
}