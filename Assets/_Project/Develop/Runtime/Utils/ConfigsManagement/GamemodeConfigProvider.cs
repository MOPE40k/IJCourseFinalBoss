using Runtime.Configs.Gameplay.Gamemodes;
using Utils.ConfigsManagement;
using Utils.SceneManagement;
using Utils.CoroutinesManagement;
using Runtime.Gameplay.Infrastucture;

namespace Runtime.Utils.ConfigsManagement
{
    public class GamemodeConfigProvider
    {
        // References
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

        public void DigitsModeLoad()
            => LoadSceneFor(_configsProviderService.GetConfig<DigitsSetConfig>());

        public void LettersModeLoad()
            => LoadSceneFor(_configsProviderService.GetConfig<LettersSetConfig>());

        private void LoadSceneFor(ISymbolsSetConfig config)
        {
            _coroutinePerformer.StartPerform(
                _sceneSwitcherService.ProcessSwitchTo(Scenes.Gameplay, new GameplayInputArgs(config)));
        }
    }
}