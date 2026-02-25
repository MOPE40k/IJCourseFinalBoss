using System.Collections.Generic;
using Runtime.Gameplay;
using Runtime.Ui.Core;
using Runtime.Ui.TextField;

namespace Runtime.Ui.Gameplay
{
    public class GameplayScreenPresenter : ISubscribePresenter
    {
        // References
        private readonly GameplayScreenView _view = null;
        private readonly ProjectPresentersFactory _projectPresentersFactory = null;
        private readonly GameplayPopupService _popupService = null;
        private readonly SequenceGenerationService _sequenceGenerationService = null;
        private readonly GameplayCycle _gameplayCycle = null;

        // Runtime
        private readonly List<IPresenter> _childPresenters = new();

        public GameplayScreenPresenter(
            GameplayScreenView view,
            ProjectPresentersFactory projectPresentersFactory,
            GameplayPopupService popupService,
            SequenceGenerationService sequenceGenerationService,
            GameplayCycle gameplayCycle)
        {
            _view = view;
            _projectPresentersFactory = projectPresentersFactory;
            _popupService = popupService;
            _sequenceGenerationService = sequenceGenerationService;
            _gameplayCycle = gameplayCycle;
        }

        public void Init()
        {
            Subscribe();

            CreateTextFields();

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
            => _view.SendButtonClicked += OnSendButtonClicked;

        public void Unsubscribe()
            => _view.SendButtonClicked -= OnSendButtonClicked;

        private void CreateTextFields()
        {
            TextFieldPresenter codePhrase = _projectPresentersFactory
                .CreateTextFieldPresenter(
                    _sequenceGenerationService.CodePhrase,
                    _view.SequenceText);

            TextFieldPresenter input = _projectPresentersFactory
                .CreateTextFieldPresenter(
                    _gameplayCycle.CurrentInput,
                    _view.InputText);

            _childPresenters.Add(codePhrase);
            _childPresenters.Add(input);
        }

        private void OnSendButtonClicked()
            => _gameplayCycle.DetermineSessionResult();
    }
}