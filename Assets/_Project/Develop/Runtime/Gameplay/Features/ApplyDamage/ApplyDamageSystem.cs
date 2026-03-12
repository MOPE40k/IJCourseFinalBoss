using System;
using Runtime.Gameplay.EntitiesCore;
using Runtime.Gameplay.EntitiesCore.Systems;
using Runtime.Utils.Conditions;
using Runtime.Utils.Reactive;
using UnityEngine;

namespace Runtime.Gameplay.Features.ApplyDamage
{
    public class ApplyDamageSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveEvent<float> _damageRequest = null;
        private ReactiveEvent<float> _damageEvent = null;

        private ReactiveVariable<float> _health = null;

        private ICompositeCondition _canApplyDamage = null;

        private IDisposable _requestDisposable = null;

        public void OnInit(Entity entity)
        {
            _damageRequest = entity.TakeDamageRequest;
            _damageEvent = entity.TakeDamageEvent;

            _health = entity.CurrentHealth;

            _canApplyDamage = entity.CanApplyDamage;

            _requestDisposable = _damageRequest.Subscribe(OnDamageRequest);
        }

        public void OnDispose()
        {
            _requestDisposable.Dispose();
        }

        private void OnDamageRequest(float damage)
        {
            if (damage < 0)
                throw new ArgumentOutOfRangeException(nameof(damage));

            if (_canApplyDamage.Evaluate() == false)
                return;

            _health.Value = MathF.Max(0, _health.Value - damage);

            _damageEvent.Invoke(damage);
            Debug.Log($"TAKE DAMAGE! Damage: {damage}");
        }
    }
}