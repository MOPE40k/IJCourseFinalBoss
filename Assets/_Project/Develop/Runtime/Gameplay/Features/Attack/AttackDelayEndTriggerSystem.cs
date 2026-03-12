using System;
using Runtime.Gameplay.EntitiesCore;
using Runtime.Gameplay.EntitiesCore.Systems;
using Runtime.Utils.Reactive;
using UnityEngine;

namespace Runtime.Gameplay.Features.Attack
{
    public class AttackDelayEndTriggerSystem : IInitializableSystem, IDisposableSystem
    {
        // References
        private ReactiveEvent _attackDelayEndEvent = null;
        private ReactiveVariable<float> _attackDelayTime = null;
        private ReactiveVariable<float> _attackProcessCurrentTime = null;
        private ReactiveEvent _startAttackEvent = null;

        // Runtime
        private IDisposable _timerDisposable = null;
        private IDisposable _startAttackDisposable = null;
        private bool _alreadyAttacked = false;

        public void OnInit(Entity entity)
        {
            _attackDelayEndEvent = entity.AttackDelayEndEvent;
            _attackDelayTime = entity.AttackDelayTime;
            _attackProcessCurrentTime = entity.AttackProcessCurrentTime;
            _startAttackEvent = entity.StartAttackEvent;

            _timerDisposable = _attackProcessCurrentTime.Subscribe(OnTimerChanged);
            _startAttackDisposable = _startAttackEvent.Subscribe(OnStartAttack);
        }

        public void OnDispose()
        {
            _timerDisposable.Dispose();
            _startAttackDisposable.Dispose();
        }

        private void OnTimerChanged(float arg1, float currentTime)
        {
            if (_alreadyAttacked)
                return;

            if (currentTime >= _attackDelayTime.Value)
            {
                Debug.Log("Attack delay is end");

                _attackDelayEndEvent.Invoke();

                _alreadyAttacked = true;
            }
        }

        private void OnStartAttack()
            => _alreadyAttacked = false;
    }
}