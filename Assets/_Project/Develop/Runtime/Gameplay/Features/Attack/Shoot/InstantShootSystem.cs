using System;
using Runtime.Gameplay.EntitiesCore;
using Runtime.Gameplay.EntitiesCore.Systems;
using Runtime.Utils.Reactive;
using UnityEngine;

namespace Runtime.Gameplay.Features.Attack.Shoot
{
    public class InstantShootSystem : IInitializableSystem, IDisposableSystem
    {
        // References
        private readonly EntitiesFactory _entitiesFactory = null;
        private ReactiveEvent _attackDelayEndEvent = null;
        private ReactiveVariable<float> _damage = null;
        private Transform _shootPoint = null;

        // Runtime
        private IDisposable _attackDelayEndDisposable = null;

        public InstantShootSystem(EntitiesFactory entitiesFactory)
            => _entitiesFactory = entitiesFactory;

        public void OnInit(Entity entity)
        {
            _attackDelayEndEvent = entity.AttackDelayEndEvent;
            _damage = entity.InstantAttackDamage;
            _shootPoint = entity.ShootPoint;

            _attackDelayEndDisposable = _attackDelayEndEvent.Subscribe(OnAttackDelayEnd);
        }

        public void OnDispose()
            => _attackDelayEndDisposable.Dispose();

        private void OnAttackDelayEnd()
            => _entitiesFactory.CreateProjectileEntity(
                _shootPoint.position,
                _shootPoint.forward,
                _damage.Value);
    }
}