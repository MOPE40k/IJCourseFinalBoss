using UnityEngine;
using Runtime.Ui.Core;

namespace Runtime.Ui.Gameplay
{
    public class GameplayPopupService : PopupService
    {
        // References
        private readonly GameplayUiRoot _gameplayUiRoot = null;

        public GameplayPopupService(
            ViewsFactory viewsFactory,
            ProjectPresentersFactory projectPresentersFactory,
            GameplayUiRoot gameplayUiRoot)
            : base(viewsFactory, projectPresentersFactory)
        {
            _gameplayUiRoot = gameplayUiRoot;
        }

        // Runtime
        protected override Transform PopupLayer => _gameplayUiRoot.PopupsLayer;
    }
}