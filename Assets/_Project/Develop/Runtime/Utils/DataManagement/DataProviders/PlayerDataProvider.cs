using System;
using System.Collections.Generic;
using Runtime.Configs.Meta.Wallet;
using Runtime.Meta.Features.Sessions;
using Runtime.Meta.Features.Wallet;
using Utils.ConfigsManagement;
using Utils.DataManagement;

namespace Runtime.Utils.DataManagement.DataProviders
{
    public class PlayerDataProvider : DataProvider<PlayerData>
    {
        // References
        private readonly ConfigsProviderService _configsProviderService = null;

        public PlayerDataProvider(
            ISaveLoadService saveLoadService,
            ConfigsProviderService configsProviderService) : base(saveLoadService)
        {
            _configsProviderService = configsProviderService;
        }

        protected override PlayerData GetOriginalData()
        {
            return new PlayerData()
            {
                WalletData = InitWalletData(),
                SessionsResultsData = InitSessionsResultsData(),
                CompletedLevels = new()
            };
        }

        private Dictionary<CurrencyTypes, int> InitWalletData()
        {
            Dictionary<CurrencyTypes, int> walletData = new();

            StartWalletConfig startWalletConfig = _configsProviderService.GetConfig<StartWalletConfig>();

            foreach (CurrencyTypes type in Enum.GetValues(typeof(CurrencyTypes)))
                walletData[type] = startWalletConfig.GetValueFor(type);

            return walletData;
        }

        private Dictionary<SessionEndConditionTypes, int> InitSessionsResultsData()
        {
            Dictionary<SessionEndConditionTypes, int> sessionsResultsData = new();

            foreach (SessionEndConditionTypes type in Enum.GetValues(typeof(SessionEndConditionTypes)))
                sessionsResultsData[type] = 0;

            return sessionsResultsData;
        }
    }
}