using System.Collections.Generic;
using Runtime.Configs.Gameplay.Levels;
using Runtime.Ui.Core;
using Utils.ConfigsManagement;
using Utils.CoroutinesManagement;

namespace Runtime.Ui.LevelMenuPopup
{
    public class LevelsMenuPopupPresenter : PopupPresenterBase
    {
        // Const
        private const string TitleName = "Levels:";

        // Refernces
        private readonly ConfigsProviderService _configsProviderService = null;
        private readonly ProjectPresentersFactory _presentersFactory = null;
        private readonly ViewsFactory _viewsFactory = null;
        private readonly LevelsMenuPopupView _view = null;

        // Runtime
        private readonly List<LevelTilePresenter> _levelTilePresenters = new();

        public LevelsMenuPopupPresenter(
            ConfigsProviderService configsProviderService,
            ProjectPresentersFactory presentersFactory,
            ViewsFactory viewsFactory,
            LevelsMenuPopupView view,
            ICoroutinePerformer coroutinePerformer) : base(coroutinePerformer)
        {
            _configsProviderService = configsProviderService;
            _presentersFactory = presentersFactory;
            _viewsFactory = viewsFactory;
            _view = view;
        }

        // Runtime
        protected override PopupViewBase PopupView => _view;

        public override void Init()
        {
            base.Init();

            _view.SetTitle(TitleName);

            LevelsListConfig levelsListConfig = _configsProviderService.GetConfig<LevelsListConfig>();

            for (int i = 0; i < levelsListConfig.Levels.Count; i++)
            {
                LevelTileView levelTileView = _viewsFactory.Create<LevelTileView>(ViewIds.LevelTile);

                _view.LevelTilesListView.Add(levelTileView);

                LevelTilePresenter levelTilePresenter = _presentersFactory.CreateLevelTilePresenter(levelTileView, i + 1);

                levelTilePresenter.Init();

                _levelTilePresenters.Add(levelTilePresenter);
            }
        }

        protected override void OnPreShow()
        {
            base.OnPreShow();

            foreach (LevelTilePresenter presenter in _levelTilePresenters)
                presenter.Subscribe();
        }

        protected override void OnPreHide()
        {
            base.OnPreHide();

            foreach (LevelTilePresenter presenter in _levelTilePresenters)
                presenter.Unsubscribe();
        }

        public override void Dispose()
        {
            base.Dispose();

            foreach (LevelTilePresenter presenter in _levelTilePresenters)
            {
                _view.LevelTilesListView.Remove(presenter.View);

                _viewsFactory.Release(presenter.View);

                presenter.Dispose();
            }

            _levelTilePresenters.Clear();
        }
    }
}