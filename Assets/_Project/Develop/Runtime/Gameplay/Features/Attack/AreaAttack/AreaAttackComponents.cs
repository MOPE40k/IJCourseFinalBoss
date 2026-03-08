using Runtime.Gameplay.EntitiesCore;
using Runtime.Utils.Reactive;

namespace Runtime.Gameplay.Features.Attack.AreaAttack
{
    public class AreaAttackRadius : IEntityComponent
    {
        public ReactiveVariable<float> Value = null;
    }

    public class AreaAttackDamage : IEntityComponent
    {
        public ReactiveVariable<float> Value = null;
    }
}