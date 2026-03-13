using Runtime.Gameplay.EntitiesCore;
using Runtime.Utils.Reactive;
using Runtime.Utils.StateMachineCore;
using UnityEngine;

namespace Runtime.Gameplay.Features.Ai.States
{
    public class InstantMoveToTargetInRadiusState : State, IUpdatableState
    {
        // Delegates
        private readonly ReactiveEvent _startInstantMoveRequest = null;

        // References
        private readonly Rigidbody _rigidbody = null;
        private readonly Transform _transform = null;

        // Settings
        private readonly ReactiveVariable<Entity> _currentTarget = null;

        // Runtime
        private readonly ReactiveVariable<float> _moveRadius = null;
        private readonly ReactiveVariable<Vector3> _instantMoveDestinationPosition = null;

        public InstantMoveToTargetInRadiusState(Entity entity)
        {
            _startInstantMoveRequest = entity.StartInstantMoveRequest;
            _rigidbody = entity.Rigidbody;
            _transform = entity.Transform;
            _currentTarget = entity.CurrentTarget;
            _moveRadius = entity.MoveRadius;
            _instantMoveDestinationPosition = entity.InstantMoveDestinationPosition;
        }

        public override void Enter()
        {
            base.Enter();

            Vector3 destinationPoint = (_currentTarget.Value.Transform.position - _transform.position).normalized;

            destinationPoint *= _moveRadius.Value;

            _instantMoveDestinationPosition.Value = _rigidbody.position + destinationPoint;

            _startInstantMoveRequest.Invoke();
        }

        public void UpdateTick(float deltaTime)
        { }
    }
}