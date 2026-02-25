using Runtime.Configs.Meta.Wallet;
using Runtime.Gameplay;
using Runtime.Meta.Features.Sessions;
using Runtime.Meta.Features.Wallet;
using Utils.ConfigsManagement;
using Utils.SceneManagement;

public class GameSessionDetermineService
{
    // References
    private readonly PhraseCompareService _phraseCompareService = null;
    private readonly ConfigsProviderService _configsProviderService = null;
    private readonly WalletService _walletService = null;
    private readonly SessionsResultsCounterService _sessionsResultsCounterService = null;

    // Settings
    private readonly int _rewardCurrencyAmount = 0;
    private readonly int _penaltyCurrencyAmount = 0;

    public GameSessionDetermineService(
        PhraseCompareService phraseCompareService,
        ConfigsProviderService configsProviderService,
        WalletService walletService,
        SessionsResultsCounterService sessionsResultsCounterService)
    {
        _phraseCompareService = phraseCompareService;
        _configsProviderService = configsProviderService;
        _walletService = walletService;
        _sessionsResultsCounterService = sessionsResultsCounterService;

        ActionsCostsConfig actionsCostsConfig = _configsProviderService.GetConfig<ActionsCostsConfig>();

        _rewardCurrencyAmount = actionsCostsConfig.GetValueFor(SessionEndConditionTypes.Win);
        _penaltyCurrencyAmount = actionsCostsConfig.GetValueFor(SessionEndConditionTypes.Defeat);
    }

    public string DetermineResult(string userInput, string codePhrase)
    {
        string nextSceneName = Scenes.MainMenu;

        if (IsEqual(userInput, codePhrase))
        {
            _sessionsResultsCounterService.Add(SessionEndConditionTypes.Win);

            _walletService.Add(CurrencyTypes.Gold, _rewardCurrencyAmount);
        }
        else
        {
            _sessionsResultsCounterService.Add(SessionEndConditionTypes.Defeat);

            if (_walletService.Enough(CurrencyTypes.Gold, _penaltyCurrencyAmount))
                _walletService.Spend(CurrencyTypes.Gold, _penaltyCurrencyAmount);

            nextSceneName = Scenes.Gameplay;
        }

        return nextSceneName;
    }

    private bool IsEqual(string arg1, string arg2)
        => _phraseCompareService.Compare(arg1, arg2);
}
