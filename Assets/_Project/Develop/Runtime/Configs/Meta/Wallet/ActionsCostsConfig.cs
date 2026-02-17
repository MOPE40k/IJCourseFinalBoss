using System;
using System.Collections.Generic;
using System.Linq;
using Runtime.Meta.Features.Sessions;
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
        [SerializeField, Min(0)] private int _resetCost = 10;

        // Runtime
        public int ResetCost => _resetCost;

        public int GetValueFor(SessionEndConditionTypes type)
            => _penaltyRewards.First(config => config.Type == type).Value;

        [Serializable]
        private class PenaltyRewardConfig
        {
            [field: SerializeField] public SessionEndConditionTypes Type { get; private set; } = SessionEndConditionTypes.Win;
            [field: SerializeField, Min(0)] public int Value { get; private set; } = 0;
        }
    }
}