using Runtime.Gameplay.EntitiesCore;
using Runtime.Utils.Conditions;
using Runtime.Utils.Reactive;

namespace Runtime.Gameplay.Features.Stats
{
    public class MaxStamina : IEntityComponent
    {
        public ReactiveVariable<float> Value = null;
    }

    public class CurrentStamina : IEntityComponent
    {
        public ReactiveVariable<float> Value = null;
    }

    public class RecoveryStaminaStep : IEntityComponent
    {
        public ReactiveVariable<float> Value = null;
    }

    public class RecoveryStaminaInitialTime : IEntityComponent
    {
        public ReactiveVariable<float> Value = null;
    }

    public class RecoveryStaminaCurrentTime : IEntityComponent
    {
        public ReactiveVariable<float> Value = null;
    }

    public class CanStaminaRecovery : IEntityComponent
    {
        public ICompositeCondition Value = null;
    }

    public class RecoveryStaminaTimerCycleIsOver : IEntityComponent
    {
        public ReactiveEvent Value = null;
    }
}