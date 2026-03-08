using Runtime.Gameplay.EntitiesCore;
using Runtime.Utils.Conditions;
using Runtime.Utils.Reactive;
using UnityEngine;

namespace Runtime.Gameplay.Features.Attack
{
    public class StartAttackRequest : IEntityComponent
    {
        public ReactiveEvent Value = null;
    }

    public class StartAttackEvent : IEntityComponent
    {
        public ReactiveEvent Value = null;
    }

    public class CanStartAttack : IEntityComponent
    {
        public ICompositeCondition Value = null;
    }

    public class EndAttackEvent : IEntityComponent
    {
        public ReactiveEvent Value = null;
    }

    public class AttackProcessInitialTime : IEntityComponent
    {
        public ReactiveVariable<float> Value = null;
    }

    public class AttackProcessCurrentTime : IEntityComponent
    {
        public ReactiveVariable<float> Value = null;
    }

    public class InAttackProcess : IEntityComponent
    {
        public ReactiveVariable<bool> Value = null;
    }

    public class AttackDelayTime : IEntityComponent
    {
        public ReactiveVariable<float> Value = null;
    }

    public class AttackDelayEndEvent : IEntityComponent
    {
        public ReactiveEvent Value = null;
    }

    public class InstantAttackDamage : IEntityComponent
    {
        public ReactiveVariable<float> Value = null;
    }

    public class ShootPoint : IEntityComponent
    {
        public Transform Value = null;
    }

    public class MustCanceledAttack : IEntityComponent
    {
        public ICompositeCondition Value = null;
    }

    public class AttackCanceledEvent : IEntityComponent
    {
        public ReactiveEvent Value = null;
    }

    public class AttackCooldownInitialTime : IEntityComponent
    {
        public ReactiveVariable<float> Value = null;
    }

    public class AttackCooldownCurrentTime : IEntityComponent
    {
        public ReactiveVariable<float> Value = null;
    }

    public class InAttackCooldown : IEntityComponent
    {
        public ReactiveVariable<bool> Value = null;
    }
}