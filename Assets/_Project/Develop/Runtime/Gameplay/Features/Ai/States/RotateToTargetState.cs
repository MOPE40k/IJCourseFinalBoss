using Runtime.Gameplay.EntitiesCore;
using Runtime.Utils.Reactive;
using Runtime.Utils.StateMachineCore;
using UnityEngine;

namespace Runtime.Gameplay.Features.Ai.States
{
    public class RotateToTargetState : State, IUpdatableState
    {
        // References
        private readonly ReactiveVariable<Entity> _currentTarget = null;
        private readonly Transform _transform = null;

        // Runtime
        private readonly ReactiveVariable<Vector3> _rotationDirection = null;

        public RotateToTargetState(Entity entity)
        {
            _rotationDirection = entity.RotationDirection;
            _currentTarget = entity.CurrentTarget;
            _transform = entity.Transform;
        }

        public void UpdateTick(float deltaTime)
        {
            if (_currentTarget.Value is not null)
                _rotationDirection.Value = (_currentTarget.Value.Transform.position - _transform.position).normalized;
        }
    }
}