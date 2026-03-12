using System.Collections.Generic;
using Runtime.Gameplay.EntitiesCore;
using Runtime.Utils.Conditions;
using Runtime.Utils.Reactive;
using UnityEngine;

namespace Runtime.Gameplay.Features.LifeCycle
{
    public class CurrentHealth : IEntityComponent
    {
        public ReactiveVariable<float> Value = null;
    }

    public class MaxHealth : IEntityComponent
    {
        public ReactiveVariable<float> Value = null;
    }

    public class IsDead : IEntityComponent
    {
        public ReactiveVariable<bool> Value = null;
    }

    public class MustDie : IEntityComponent
    {
        public ICompositeCondition Value = null;
    }

    public class MustSelfRelease : IEntityComponent
    {
        public ICompositeCondition Value = null;
    }

    public class DeathProcessInitialTimer : IEntityComponent
    {
        public ReactiveVariable<float> Value = null;
    }
    public class DeathProcessCurrentTimer : IEntityComponent
    {
        public ReactiveVariable<float> Value = null;
    }

    public class InDeathProcess : IEntityComponent
    {
        public ReactiveVariable<bool> Value = null;
    }

    public class DisableCollidersOnDeath : IEntityComponent
    {
        public List<Collider> Value = null;
    }
}