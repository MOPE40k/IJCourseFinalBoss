using Runtime.Gameplay.EntitiesCore;
using Runtime.Utils.Reactive;

namespace Runtime.Gameplay.Features.Ai
{
    public class CurrentTarget : IEntityComponent
    {
        public ReactiveVariable<Entity> Value = null;
    }
}