using Runtime.Utils.Conditions;
using Runtime.Utils.Reactive;
using UnityEngine;
using Runtime.Gameplay.EntitiesCore;
using Runtime.Gameplay.EntitiesCore.Systems;

namespace Runtime.Gameplay.Features.LifeCycle
{
    public class DeathSystem : IInitializableSystem, IUpdatableSystem
    {
        // References
        private ICompositeCondition _mustDie = null;
        private ReactiveVariable<bool> _isDead = null;

        public void OnInit(Entity entity)
        {
            _mustDie = entity.MustDie;
            _isDead = entity.IsDead;
        }

        public void OnUpdateTick(float deltaTime)
        {
            if (_isDead.Value)
                return;

            if (_mustDie.Evaluate())
                _isDead.Value = true;
        }
    }
}