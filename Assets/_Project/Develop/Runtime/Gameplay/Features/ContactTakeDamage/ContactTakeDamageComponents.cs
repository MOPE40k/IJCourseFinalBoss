using Runtime.Gameplay.EntitiesCore;
using Runtime.Utils.Reactive;

namespace Runtime.Gameplay.Features.ContactTakeDamage
{
    public class BodyContactDamage : IEntityComponent
    {
        public ReactiveVariable<float> Value = null;
    }
}