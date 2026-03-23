using Runtime.Gameplay.EntitiesCore;
using Runtime.Utils.Reactive;
using UnityEngine;

namespace Runtime.Gameplay.Features.Ai.States.InstantMove
{
    public class InstantMoveToTargetDirectionInRadiusState : IInstantMoveEndPointProvider
    {
        private readonly Rigidbody _rigidbody = null;
        private readonly ReactiveVariable<Entity> _currentTarget = null;
        private readonly ReactiveVariable<float> _moveRadius = null;

        public InstantMoveToTargetDirectionInRadiusState(Entity entity)
        {
            entity.AddCurrentTarget();

            _rigidbody = entity.Rigidbody;
            _currentTarget = entity.CurrentTarget;
            _moveRadius = entity.RadiusForInstantMove;
        }

        public Vector3 GetDirection()
        {
            Vector3 destinationPoint = (_currentTarget.Value.Transform.position - _rigidbody.position).normalized;

            destinationPoint *= _moveRadius.Value;

            return _rigidbody.position + destinationPoint;
        }
    }
}