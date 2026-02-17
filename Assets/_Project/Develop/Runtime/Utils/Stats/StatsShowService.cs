using UnityEngine;
using Runtime.Meta.Features.Sessions;
using Runtime.Meta.Features.Wallet;

namespace Runtime.Utils.Stats
{
    public class StatsShowService
    {
        // References
        private readonly SessionConditionCounterService _sessionConditionCounterService = null;
        private readonly WalletService _walletService = null;

        public StatsShowService(
            SessionConditionCounterService sessionConditionCounterService,
            WalletService walletService)
        {
            _sessionConditionCounterService = sessionConditionCounterService;
            _walletService = walletService;
        }

        public void ShowStats()
        {
            int winCount = _sessionConditionCounterService.GetCondition(SessionEndConditionTypes.Win).Value;
            int defeatCount = _sessionConditionCounterService.GetCondition(SessionEndConditionTypes.Defeat).Value;

            int goldAmount = _walletService.GetCurrency(CurrencyTypes.Gold).Value;

#if UNITY_EDITOR
            Debug.Log($"WIN: {winCount} DEFEAT: {defeatCount} GOLD: {goldAmount}");
#endif
        }
    }
}