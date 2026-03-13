using System.Collections.Generic;
using Runtime.Gameplay.EntitiesCore;

namespace Runtime.Gameplay.Features.Ai.States
{
    public interface ITargetSelector
    {
        Entity SelectTargetFrom(IEnumerable<Entity> targets);
    }
}