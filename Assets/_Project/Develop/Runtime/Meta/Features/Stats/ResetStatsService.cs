using UnityEngine;
using Runtime.Meta.Features.Wallet;
using Runtime.Utils.DataManagement.DataProviders;
using Utils.ConfigsManagement;
using Runtime.Configs.Meta.Wallet;
using Runtime.Meta.Features.Sessions;
using Utils.CoroutinesManagement;

namespace Runtime.Meta.Features.Stats
{
    public class ResetStatsService
    {
        // References
        private readonly WalletService _walletService = null;
        private readonly PlayerDataProvider _playerDataProvider = null;
        private readonly SessionsResultsCounterService _sessionsResultsCounterService = null;
        private readonly ConfigsProviderService _configsProviderService = null;
        private readonly ICoroutinePerformer _coroutinePerformer = null;

        // Runtime
        private readonly int _resetStatsCost = 0;

        public ResetStatsService(
            WalletService walletService,
            PlayerDataProvider playerDataProvider,
            SessionsResultsCounterService sessionsResultsCounterService,
            ConfigsProviderService configsProviderService,
            ICoroutinePerformer coroutinePerformer)
        {
            _walletService = walletService;
            _playerDataProvider = playerDataProvider;
            _sessionsResultsCounterService = sessionsResultsCounterService;
            _configsProviderService = configsProviderService;
            _coroutinePerformer = coroutinePerformer;

            _resetStatsCost = _configsProviderService
                .GetConfig<ActionsCostsConfig>()
                .GetValueFor(CurrencyTypes.Gold);
        }

        public void ResetStats()
        {
            if (IsEnough(CurrencyTypes.Gold) == false)
                throw new System.InvalidOperationException($"Not enough {CurrencyTypes.Gold}! Currency amount: {_walletService.GetCurrency(CurrencyTypes.Gold).Value}, Currency required: {_resetStatsCost}");

            _sessionsResultsCounterService.Reset();

            _walletService.Spend(CurrencyTypes.Gold, _resetStatsCost);

            _coroutinePerformer.StartPerform(_playerDataProvider.Save());

#if UNITY_EDITOR
            Debug.Log($"RESET STATS!");
#endif
        }

        public bool IsEnough(CurrencyTypes currency)
        {
            int cost = _configsProviderService
                .GetConfig<ActionsCostsConfig>()
                .GetValueFor(currency);

            return _walletService.Enough(currency, cost);
        }
    }
}