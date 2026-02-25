using System.Collections;
using Runtime.Gameplay.Infrastucture;
using Runtime.Utils.DataManagement.DataProviders;
using Runtime.Utils.SceneManagement;
using UnityEngine;
using Utils.CoroutinesManagement;
using Utils.InputManagement;
using Utils.Reactive;
using Utils.SceneManagement;

namespace Runtime.Gameplay
{
    public class GameplayCycle
    {
        // References
        private readonly SequenceGenerationService _sequenceGenerationService = null;
        private readonly GameSessionDetermineService _gameSessionDetermineService = null;
        private readonly SceneSwitcherService _sceneSwitcherService = null;
        private readonly PlayerDataProvider _playerDataProvider = null;
        private readonly ICoroutinePerformer _coroutinePerformer = null;
        private readonly GameplayInputArgs _inputArgs = null;

        // Runtime
        private ReactiveVeriable<string> _currentInput = new(string.Empty);
        private bool _isRunning = false;
        private string _nextSceneName = string.Empty;

        public GameplayCycle(
            SequenceGenerationService sequenceGenerationService,
            GameSessionDetermineService gameSessionDetermineService,
            SceneSwitcherService sceneSwitcherService,
            PlayerDataProvider playerDataProvider,
            ICoroutinePerformer coroutinePerformer,
            GameplayInputArgs inputArgs)
        {
            _sequenceGenerationService = sequenceGenerationService;
            _gameSessionDetermineService = gameSessionDetermineService;
            _sceneSwitcherService = sceneSwitcherService;
            _playerDataProvider = playerDataProvider;
            _coroutinePerformer = coroutinePerformer;
            _inputArgs = inputArgs;
        }

        // Runtime
        public IReadOnlyVeriable<string> CurrentInput => _currentInput;

        public void Run()
        {
            _sequenceGenerationService.GetRandomSequence(
                _inputArgs.CharsConfig.SymbolsSet,
                _inputArgs.CharsConfig.PhraseLength);

            StartGameplay();
        }

        public void UpdateTick(float deltaTime)
        {
            if (_isRunning == false)
                return;

            if (string.IsNullOrEmpty(Input.inputString) == false)
                foreach (char c in Input.inputString)
                    InputProcess(c);
        }

        public void DetermineSessionResult()
        {
            StopGameplay();

            _nextSceneName = _gameSessionDetermineService.DetermineResult(
                CurrentInput.Value,
                _sequenceGenerationService.CodePhrase.Value);

            _coroutinePerformer.StartPerform(_playerDataProvider.Save());

            _coroutinePerformer.StartPerform(SceneSwitchTo(_nextSceneName));
        }

        public IEnumerator SceneSwitchTo(string sceneName)
        {
            yield return _sceneSwitcherService.ProcessSwitchTo(sceneName, _inputArgs as IInputSceneArgs);
        }

        private void InputProcess(char c)
        {
            if (IsEnterKeyEntered(c))
            {
                if (_isRunning == false)
                    return;

                DetermineSessionResult();
            }
            else if (IsBackspaceKeyEntered(c))
            {
                if (string.IsNullOrEmpty(_currentInput.Value) == false)
                {
                    RemoveLastCharFromResultInput();
                }
            }
            else
            {
                if (IsLetterOrDigitEntered(c))
                {
                    AddCharToResultInput(c);
                }
            }
        }

        private void StartGameplay()
            => _isRunning = true;

        public void StopGameplay()
            => _isRunning = false;

        private bool IsEnterKeyEntered(char c)
            => c == InputChars.NewlineChar || c == InputChars.ReturnChar;

        private bool IsBackspaceKeyEntered(char c)
            => c == InputChars.BackspaceChar;

        private bool IsLetterOrDigitEntered(char c)
            => char.IsLetterOrDigit(c);

        private void RemoveLastCharFromResultInput()
        {
            int lastCharIndex = _currentInput.Value.Length - 1;

            _currentInput.Value = _currentInput.Value.Substring(0, lastCharIndex);
        }

        private void AddCharToResultInput(char c)
            => _currentInput.Value += c;
    }
}