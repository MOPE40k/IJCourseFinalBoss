using System;
using System.Collections.Generic;
using System.Linq;
using Runtime.Meta.Features.Sessions;
using Runtime.Meta.Features.Wallet;
using UnityEngine;

namespace Runtime.Configs.Meta.Wallet
{
    [CreateAssetMenu(menuName = "Configs/Meta/ActionsCosts/New ActionsCostsConfig", fileName = "ActionCostsConfig")]
    public class ActionsCostsConfig : ScriptableObject
    {
        [Header("Penalty & Reward Settings:")]
        [SerializeField] private List<PenaltyRewardConfig> _penaltyRewards = null;

        [Space]
        [Header("Reset Stats Settings:")]
        [SerializeField] private List<ResetCostsConfig> _resetCosts = null;

        public int GetValueFor(SessionEndConditionTypes type)
            => _penaltyRewards.First(config => config.EndCondition == type).Value;

        public int GetValueFor(CurrencyTypes type)
            => _resetCosts.First(config => config.Currency == type).Cost;

        [Serializable]
        private class PenaltyRewardConfig
        {
            [field: SerializeField] public SessionEndConditionTypes EndCondition { get; private set; } = SessionEndConditionTypes.Win;
            [field: SerializeField, Min(0)] public int Value { get; private set; } = 0;
        }

        [Serializable]
        private class ResetCostsConfig
        {
            [field: SerializeField] public CurrencyTypes Currency { get; private set; } = CurrencyTypes.Gold;
            [field: SerializeField, Min(0)] public int Cost { get; private set; } = 0;
        }
    }
}