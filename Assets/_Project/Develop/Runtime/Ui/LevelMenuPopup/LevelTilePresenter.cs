using Runtime.Meta.Features.LevelProgression;
using Runtime.Ui.Core;
using UnityEngine;
using Utils.CoroutinesManagement;
using Utils.SceneManagement;

namespace Runtime.Ui.LevelMenuPopup
{
    public class LevelTilePresenter : ISubscribePresenter
    {
        // References
        private readonly LevelProgressionService _levelProgressionService = null;
        private readonly SceneSwitcherService _sceneSwitcherService = null;
        private readonly ICoroutinePerformer _coroutinePerformer = null;
        private readonly LevelTileView _view = null;

        // Settings
        private readonly int _levelNumber = 0;

        public LevelTilePresenter(
            LevelProgressionService levelProgressionService,
            SceneSwitcherService sceneSwitcherService,
            ICoroutinePerformer coroutinePerformer,
            LevelTileView view,
            int levelNumber)
        {
            _levelProgressionService = levelProgressionService;
            _sceneSwitcherService = sceneSwitcherService;
            _coroutinePerformer = coroutinePerformer;
            _view = view;
            _levelNumber = levelNumber;
        }

        // Runtime
        public LevelTileView View => _view;

        public void Init()
        {
            _view.SetLevel(_levelNumber.ToString());

            if (_levelProgressionService.CanPlay(_levelNumber))
            {
                if (_levelProgressionService.IsLevelCompleted(_levelNumber))
                {
                    _view.SetComplete();
                }
                else
                {
                    _view.SetActive();
                }
            }
            else
            {
                _view.SetBlock();
            }
        }

        public void Dispose()
            => _view.Clicked -= OnViewClicked;

        public void Subscribe()
            => _view.Clicked += OnViewClicked;

        public void Unsubscribe()
            => _view.Clicked -= OnViewClicked;

        private void OnViewClicked()
        {
            if (_levelProgressionService.CanPlay(_levelNumber) == false)
            {
                Debug.Log("Уровень заблокирован! Пройдите предыдущий!");

                return;
            }

            // _coroutinePerformer
            //     .StartPerform(
            //         _sceneSwitcherService
            //             .ProcessSwitchTo(Scenes.Gameplay, new GameplayInputArgs(_levelNumber)));
        }
    }
}