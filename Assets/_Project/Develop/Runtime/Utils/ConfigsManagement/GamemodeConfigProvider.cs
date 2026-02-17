using Runtime.Configs;
using UnityEngine;
using Utils;
using Utils.ConfigsManagement;
using Utils.InputManagement;
using Utils.SceneManagement;
using Utils.CoroutinesManagement;
using Runtime.Gameplay.Infrastucture;

namespace Runtime.Utils.ConfigsManagement
{
    public class GamemodeConfigProvider : IService
    {
        private readonly ConfigsProviderService _configsProviderService = null;
        private readonly SceneSwitcherService _sceneSwitcherService = null;
        private readonly ICoroutinePerformer _coroutinePerformer = null;

        public GamemodeConfigProvider(
            ConfigsProviderService configsProviderService,
            SceneSwitcherService sceneSwitcherService,
            ICoroutinePerformer coroutinePerformer)
        {
            _configsProviderService = configsProviderService;
            _sceneSwitcherService = sceneSwitcherService;
            _coroutinePerformer = coroutinePerformer;
        }

        public void UpdateTick(float deltaTime)
        {
            if (Input.GetKeyDown(InputKeys.DigitsModeKey))
                LoadSceneFor(
                    _configsProviderService.GetConfig<DigitsSetConfig>());

            if (Input.GetKeyDown(InputKeys.LettersModeKey))
                LoadSceneFor(
                    _configsProviderService.GetConfig<LettersSetConfig>());
        }

        private void LoadSceneFor(ISymbolsSetConfig config)
        {
            _coroutinePerformer.StartPerform(
                _sceneSwitcherService.ProcessSwitchTo(Scenes.Gameplay, new GameplayInputArgs(config)));
        }
    }
}