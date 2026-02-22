using System;
using System.Collections.Generic;
using System.Linq;
using Runtime.Meta.Features.Wallet;
using UnityEngine;

namespace Runtime.Configs.Meta.Wallet
{
    [CreateAssetMenu(menuName = "Configs/Meta/Wallet/New CurrencyIconsConfig", fileName = "CurrencyIconsConfig")]
    public class CurrencyIconsConfig : ScriptableObject
    {
        [Header("Currencies Settings:")]
        [SerializeField] private List<IconsConfig> _configs = null;

        public Sprite GetSpriteFor(CurrencyTypes type)
            => _configs.First(config => config.Type == type).Sprite;

        [Serializable]
        private class IconsConfig
        {
            [field: SerializeField] public CurrencyTypes Type { get; private set; } = CurrencyTypes.Gold;
            [field: SerializeField] public Sprite Sprite { get; private set; } = null;
        }
    }
}