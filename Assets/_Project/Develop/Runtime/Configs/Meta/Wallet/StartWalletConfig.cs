using System;
using System.Collections.Generic;
using System.Linq;
using Runtime.Meta.Features.Wallet;
using UnityEngine;

namespace Runtime.Configs.Meta.Wallet
{
    [CreateAssetMenu(menuName = "Configs/Meta/Wallet/New StartWalletConfig", fileName = "StartWalletConfig")]
    public class StartWalletConfig : ScriptableObject
    {
        [Header("Currencies Settings:")]
        [SerializeField] private List<CurrencyConfig> _configs = null;

        public int GetValueFor(CurrencyTypes type)
            => _configs.First(config => config.Type == type).Value;

        [Serializable]
        private class CurrencyConfig
        {
            [field: SerializeField] public CurrencyTypes Type { get; private set; } = CurrencyTypes.Gold;
            [field: SerializeField, Min(0)] public int Value { get; private set; } = 0;
        }
    }
}