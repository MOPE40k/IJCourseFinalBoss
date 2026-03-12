using Runtime.Gameplay.EntitiesCore;
using Runtime.Gameplay.EntitiesCore.Systems;
using Runtime.Utils.Conditions;
using Runtime.Utils.Reactive;

namespace Runtime.Gameplay.Features.Stats
{
    public class RecoveryStaminaTimerSystem : IInitializableSystem, IUpdatableSystem
    {
        // References
        private ReactiveVariable<float> _initialTime = null;
        private ReactiveVariable<float> _currentTime = null;
        private ICompositeCondition _canStaminaRecovery = null;
        private ReactiveEvent _timerCycleIsOverEvent = null;

        public void OnInit(Entity entity)
        {
            _initialTime = entity.RecoveryStaminaInitialTime;
            _currentTime = entity.RecoveryStaminaCurrentTime;
            _canStaminaRecovery = entity.CanStaminaRecovery;
            _timerCycleIsOverEvent = entity.RecoveryStaminaTimerCycleIsOver;
        }

        public void OnUpdateTick(float deltaTime)
        {
            if (_canStaminaRecovery.Evaluate() == false)
                return;

            _currentTime.Value += deltaTime;

            if (TimeIsOver())
            {
                _timerCycleIsOverEvent.Invoke();

                _currentTime.Value = 0f;
            }
        }

        private bool TimeIsOver()
            => _currentTime.Value >= _initialTime.Value;
    }
}