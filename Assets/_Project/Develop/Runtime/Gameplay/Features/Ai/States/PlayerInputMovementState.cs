using Runtime.Gameplay.EntitiesCore;
using Runtime.Gameplay.Features.InputFeature;
using Runtime.Utils.Reactive;
using Runtime.Utils.StateMachineCore;
using UnityEngine;

namespace Runtime.Gameplay.Features.Ai.States
{
    public class PlayerInputMovementState : State, IUpdatableState
    {
        // References
        private readonly IInputService _inputService = null;

        // Runtime
        private readonly ReactiveVariable<Vector3> _movementDirection = null;
        private readonly ReactiveVariable<Vector3> _rotationDirection = null;

        public PlayerInputMovementState(Entity entity, IInputService inputService)
        {
            _inputService = inputService;
            _movementDirection = entity.MoveDirection;
            _rotationDirection = entity.RotationDirection;
        }

        public override void Exit()
        {
            base.Exit();

            _movementDirection.Value = Vector3.zero;
        }

        public void UpdateTick(float deltaTime)
        {
            _movementDirection.Value = _inputService.Direction;
            _rotationDirection.Value = _inputService.Direction;
        }
    }
}