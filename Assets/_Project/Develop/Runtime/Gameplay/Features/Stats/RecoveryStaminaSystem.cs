using System;
using Runtime.Gameplay.EntitiesCore;
using Runtime.Gameplay.EntitiesCore.Systems;
using Runtime.Utils.Reactive;
using UnityEngine;

namespace IJCourseFinalBoss.Assets._Project.Develop.Runtime.Gameplay.Features.Stats
{
    public class RecoveryStaminaSystem : IInitializableSystem, IDisposableSystem
    {
        // references
        public ReactiveVariable<float> _maxStamina = null;
        public ReactiveVariable<float> _currentStamina = null;
        public ReactiveVariable<float> _recoveryStaminaStep = null;
        public ReactiveEvent _timerCycleIsOver = null;

        // Runtime
        private IDisposable _timerCycleIsOverEvent = null;

        public void OnInit(Entity entity)
        {
            _maxStamina = entity.MaxStamina;
            _currentStamina = entity.CurrentStamina;
            _recoveryStaminaStep = entity.RecoveryStaminaStep;
            _timerCycleIsOver = entity.RecoveryStaminaTimerCycleIsOver;

            _timerCycleIsOverEvent = _timerCycleIsOver.Subscribe(OnTimerCycleIsOver);
        }

        public void OnDispose()
            => _timerCycleIsOverEvent.Dispose();

        private void OnTimerCycleIsOver()
        {
            _currentStamina.Value = MathF.Min(
                _currentStamina.Value + _recoveryStaminaStep.Value,
                _maxStamina.Value);

            Debug.Log($"CURRENT STAMINA: {_currentStamina.Value}");
        }
    }
}