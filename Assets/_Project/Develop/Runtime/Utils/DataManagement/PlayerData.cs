using System.Collections.Generic;
using Runtime.Meta.Features.Sessions;
using Runtime.Meta.Features.Wallet;
using Runtime.Utils.DataManagement;

namespace Utils.DataManagement
{
    public class PlayerData : ISaveData
    {
        // Runtime
        public Dictionary<CurrencyTypes, int> WalletData = null;
        public Dictionary<SessionEndConditionTypes, int> SessionsResultsData = null;
        public List<int> CompletedLevels = null;
    }
}