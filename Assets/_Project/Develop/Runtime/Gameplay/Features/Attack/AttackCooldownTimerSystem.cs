using System;
using Runtime.Gameplay.EntitiesCore;
using Runtime.Gameplay.EntitiesCore.Systems;
using Runtime.Utils.Reactive;
using UnityEngine;

namespace Runtime.Gameplay.Features.Attack
{
    public class AttackCooldownTimerSystem : IInitializableSystem, IUpdatableSystem, IDisposableSystem
    {
        // References
        private ReactiveVariable<float> _initialTime = null;
        private ReactiveVariable<float> _currentTime = null;
        private ReactiveVariable<bool> _inAttackCooldown = null;
        private ReactiveEvent _endAttackEvent = null;

        // Runtime
        private IDisposable _endAttackEventDisposable = null;

        public void OnInit(Entity entity)
        {
            _initialTime = entity.AttackCooldownInitialTime;
            _currentTime = entity.AttackCooldownCurrentTime;
            _inAttackCooldown = entity.InAttackCooldown;
            _endAttackEvent = entity.EndAttackEvent;

            _endAttackEventDisposable = _endAttackEvent.Subscribe(OnEndAttack);
        }

        public void OnUpdateTick(float deltaTime)
        {
            if (_inAttackCooldown.Value == false)
                return;

            _currentTime.Value -= deltaTime;

            if (CooldownIsOver())
            {
                _inAttackCooldown.Value = false;
                Debug.Log("ATTACK COOLDOWN ENDED");
            }
        }

        public void OnDispose()
            => _endAttackEventDisposable.Dispose();

        private bool CooldownIsOver()
            => _currentTime.Value <= 0f;

        private void OnEndAttack()
        {
            Debug.Log("ATTACK COOLDOWN STARTED");
            _currentTime.Value = _initialTime.Value;
            _inAttackCooldown.Value = true;
        }
    }
}