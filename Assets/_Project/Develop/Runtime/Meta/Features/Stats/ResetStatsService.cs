using UnityEngine;
using Runtime.Meta.Features.Wallet;
using Runtime.Utils.DataManagement.DataProviders;
using Utils.ConfigsManagement;
using Utils.CoroutinesManagement;
using Runtime.Configs.Meta.Wallet;

namespace Runtime.Meta.Features.Stats
{
    public class ResetStatsService
    {
        // References
        private readonly WalletService _walletService = null;
        private readonly PlayerDataProvider _playerDataProvider = null;
        private readonly ConfigsProviderService _configsProviderService = null;
        private readonly ICoroutinePerformer _coroutinePerformer = null;

        // Runtime
        private readonly int _resetStatsCost = 0;

        public ResetStatsService(
            WalletService walletService,
            PlayerDataProvider playerDataProvider,
            ConfigsProviderService configsProviderService,
            ICoroutinePerformer coroutinePerformer)
        {
            _walletService = walletService;
            _playerDataProvider = playerDataProvider;
            _configsProviderService = configsProviderService;
            _coroutinePerformer = coroutinePerformer;

            _resetStatsCost = _configsProviderService.GetConfig<ActionsCostsConfig>().ResetCost;
        }

        public void ResetStats()
        {
            if (_walletService.Enough(CurrencyTypes.Gold, _resetStatsCost))
            {
                _playerDataProvider.Reset();

                _playerDataProvider.Save();

#if UNITY_EDITOR
                Debug.Log($"RESET STATS!");
#endif
            }
            else
            {
#if UNITY_EDITOR
                Debug.Log($"Not enough {CurrencyTypes.Gold}! Currency amount: {_walletService.GetCurrency(CurrencyTypes.Gold).Value}, Currency required: {_resetStatsCost}");
#endif
            }
        }
    }
}