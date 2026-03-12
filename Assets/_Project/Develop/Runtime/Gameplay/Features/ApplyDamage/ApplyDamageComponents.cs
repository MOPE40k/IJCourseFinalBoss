using Runtime.Gameplay.EntitiesCore;
using Runtime.Utils.Conditions;
using Runtime.Utils.Reactive;

namespace Runtime.Gameplay.Features.ApplyDamage
{
    public class TakeDamageRequest : IEntityComponent
    {
        public ReactiveEvent<float> Value = null;
    }

    public class TakeDamageEvent : IEntityComponent
    {
        public ReactiveEvent<float> Value = null;
    }

    public class CanApplyDamage : IEntityComponent
    {
        public ICompositeCondition Value = null;
    }
}