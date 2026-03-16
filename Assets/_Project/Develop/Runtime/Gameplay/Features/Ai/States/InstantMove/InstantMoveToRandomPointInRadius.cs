using Runtime.Gameplay.EntitiesCore;
using Runtime.Utils.Reactive;
using UnityEngine;

namespace Runtime.Gameplay.Features.Ai.States.InstantMove
{
    public class InstantMoveToRandomPointInRadius : IInstantMoveEndPointProvider
    {
        private readonly ReactiveVariable<float> _radius = null;

        public InstantMoveToRandomPointInRadius(Entity entity)
            => _radius = entity.RadiusForInstantMove;

        public Vector3 GetDirection()
        {
            Vector3 randomDirection = new Vector3(
                Random.Range(0f, 1f),
                0f,
                Random.Range(0f, 1f)).normalized;

            randomDirection *= Random.Range(0f, _radius.Value);

            return randomDirection;
        }
    }
}