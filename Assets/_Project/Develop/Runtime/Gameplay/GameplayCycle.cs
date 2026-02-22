using Infrastructure.DI;
using Runtime.Gameplay.Infrastucture;
using UnityEngine;
using Utils.CoroutinesManagement;
using Utils.InputManagement;

namespace Runtime.Gameplay
{
    public class GameplayCycle
    {
        // References
        private readonly DIContainer _container = null;
        private readonly GameplayInputArgs _inputArgs = null;

        // Runtime
        private string _codePhrase = string.Empty;
        private string _currentInput = string.Empty;
        private bool _isRunning = false;

        public GameplayCycle(DIContainer container, GameplayInputArgs inputArgs)
        {
            _container = container;

            _inputArgs = inputArgs;
        }

        public void Run()
        {
            // _codePhrase = _container.Resolve<SequanceGenerationService>().GetRandomSequance(
            //     _inputArgs.CharsConfig.SymbolsSet,
            //     _inputArgs.CharsConfig.PhraseLength);

#if UNITY_EDITOR
            Debug.Log($"CODE PHRASE: {_codePhrase}"); // TEST DEBUG
#endif

            _isRunning = true;
        }

        public void UpdateTick(float deltaTime)
        {
            if (_isRunning == false)
                return;

            if (string.IsNullOrEmpty(Input.inputString) == false)
                foreach (char c in Input.inputString)
                    InputProcess(c);
        }

        public void InputProcess(char c)
        {
            if (c == InputChars.NewlineChar || c == InputChars.ReturnChar)
            {
                _isRunning = false;

                GameSessionDetermineService gameResultService = _container.Resolve<GameSessionDetermineService>();

                _container.Resolve<ICoroutinePerformer>().StartPerform(
                    gameResultService.DetermineResult(_currentInput, _codePhrase, _inputArgs));
            }
            else if (c == InputChars.BackspaceChar)
            {
                if (string.IsNullOrEmpty(_currentInput) == false)
                {
                    _currentInput = _currentInput.Substring(0, _currentInput.Length - 1);

#if UNITY_EDITOR
                    Debug.Log($"CURRENT_INPUT: {_currentInput}"); //TEST
#endif
                }
            }
            else
            {
                if (char.IsLetterOrDigit(c))
                {
                    _currentInput += c;

#if UNITY_EDITOR
                    Debug.Log($"CURRENT_INPUT: {_currentInput}"); //TEST
#endif
                }
            }
        }
    }
}