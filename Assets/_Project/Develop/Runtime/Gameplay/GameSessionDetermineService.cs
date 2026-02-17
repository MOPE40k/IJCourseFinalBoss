using System.Collections;
using Runtime.Configs.Meta.Wallet;
using Runtime.Gameplay;
using Runtime.Gameplay.Infrastucture;
using Runtime.Meta.Features.Sessions;
using Runtime.Meta.Features.Wallet;
using Runtime.Utils.DataManagement.DataProviders;
using Runtime.Utils.Stats;
using UnityEngine;
using Utils.ConfigsManagement;
using Utils.CoroutinesManagement;
using Utils.InputManagement;
using Utils.SceneManagement;

public class GameSessionDetermineService
{
    // References
    private readonly PhraseCompareService _phraseCompareService = null;
    private readonly SceneSwitcherService _sceneSwitcherService = null;
    private readonly ICoroutinePerformer _coroutinePerformer = null;
    private readonly ConfigsProviderService _configsProviderService = null;
    private readonly PlayerDataProvider _playerDataProvider = null;
    private readonly WalletService _walletService = null;
    private readonly SessionConditionCounterService _sessionConditionCounterService = null;
    private readonly StatsShowService _statsShowService = null;

    // Settings
    private readonly int _rewardCount = 0;
    private readonly int _penaltyCount = 0;

    public GameSessionDetermineService(
        PhraseCompareService phraseCompareService,
        SceneSwitcherService sceneSwitcherService,
        ICoroutinePerformer coroutinePerformer,
        ConfigsProviderService configsProviderService,
        PlayerDataProvider playerDataProvider,
        WalletService walletService,
        SessionConditionCounterService sessionConditionCounterService,
        StatsShowService statsShowService)
    {
        _phraseCompareService = phraseCompareService;
        _sceneSwitcherService = sceneSwitcherService;
        _coroutinePerformer = coroutinePerformer;
        _configsProviderService = configsProviderService;
        _playerDataProvider = playerDataProvider;
        _walletService = walletService;
        _sessionConditionCounterService = sessionConditionCounterService;
        _statsShowService = statsShowService;

        ActionsCostsConfig actionsCostsConfig = _configsProviderService.GetConfig<ActionsCostsConfig>();

        _rewardCount = actionsCostsConfig.GetValueFor(SessionEndConditionTypes.Win);
        _penaltyCount = actionsCostsConfig.GetValueFor(SessionEndConditionTypes.Defeat);
    }

    public IEnumerator DetermineResult(string userInput, string codePhrase, GameplayInputArgs inputArgs)
    {
        IEnumerator nextSceneRoutine = null;

        if (_phraseCompareService.Compare(userInput, codePhrase))
        {
            _sessionConditionCounterService.Add(SessionEndConditionTypes.Win);

            _walletService.Add(CurrencyTypes.Gold, _rewardCount);

            nextSceneRoutine = _sceneSwitcherService.ProcessSwitchTo(Scenes.MainMenu, null);
        }
        else
        {
            _sessionConditionCounterService.Add(SessionEndConditionTypes.Defeat);

            if (_walletService.Enough(CurrencyTypes.Gold, _penaltyCount))
                _walletService.Spend(CurrencyTypes.Gold, _penaltyCount);

            nextSceneRoutine = _sceneSwitcherService.ProcessSwitchTo(Scenes.Gameplay, inputArgs);
        }

        _statsShowService.ShowStats();

        _coroutinePerformer.StartPerform(_playerDataProvider.Save());

        Debug.Log("PRESS SPACE TO CONTINUE!");

        yield return WaitConfirm(InputKeys.RestartKey);

        _coroutinePerformer.StartPerform(nextSceneRoutine);
    }

    private IEnumerator WaitConfirm(KeyCode key)
    {
        yield return new WaitWhile(() => Input.GetKeyDown(key) == false);
    }
}
