using System;
using Runtime.Gameplay.EntitiesCore;
using Runtime.Gameplay.EntitiesCore.Systems;
using Runtime.Utils.Reactive;
using UnityEngine;

namespace Runtime.Gameplay.Features.Attack
{
    public class EndAttackSystem : IInitializableSystem, IDisposableSystem
    {
        // References
        private ReactiveEvent _endAttackEvent = null;
        private ReactiveVariable<bool> _inAttackProcess = null;
        private ReactiveVariable<float> _attackProcessInitialTime = null;
        private ReactiveVariable<float> _attackProcessCurrentTime = null;

        // Runtime
        private IDisposable _timerDisposable = null;

        public void OnInit(Entity entity)
        {
            _endAttackEvent = entity.EndAttackEvent;
            _inAttackProcess = entity.InAttackProcess;
            _attackProcessInitialTime = entity.AttackProcessInitialTime;
            _attackProcessCurrentTime = entity.AttackProcessCurrentTime;

            _timerDisposable = _attackProcessCurrentTime.Subscribe(OnTimerChanged);
        }

        public void OnDispose()
        {
            _timerDisposable.Dispose();
        }

        private void OnTimerChanged(float arg1, float currentTime)
        {
            if (TimeIsDone(currentTime))
            {
                Debug.Log("END ATTACK");
                _inAttackProcess.Value = false;

                _endAttackEvent.Invoke();
            }
        }

        private bool TimeIsDone(float currentTime)
            => currentTime >= _attackProcessInitialTime.Value;
    }
}