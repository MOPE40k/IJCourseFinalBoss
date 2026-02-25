using Runtime.Ui.Core;
using UnityEngine;

namespace Runtime.Ui.MainMenu
{
    public class MainMenuPopupService : PopupService
    {
        // References
        private readonly MainMenuUiRoot _mainMenuUiRoot = null;

        public MainMenuPopupService(
            ViewsFactory viewsFactory,
            ProjectPresentersFactory projectPresentersFactory,
            MainMenuUiRoot mainMenuUiRoot)
            : base(viewsFactory, projectPresentersFactory)
        {
            _mainMenuUiRoot = mainMenuUiRoot;
        }

        // Runtime
        protected override Transform PopupLayer => _mainMenuUiRoot.PopupsLayer;
    }
}