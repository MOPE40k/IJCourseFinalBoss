using UnityEngine;
using Runtime.Gameplay.EntitiesCore;
using Runtime.Utils.Reactive;
using Runtime.Utils.Conditions;
using Runtime.Gameplay.EntitiesCore.Systems;

namespace Runtime.Gameplay.Features.Movement
{
    public class CharacterControllerMovementSystem : IInitializableSystem, IUpdatableSystem
    {
        // References
        private CharacterController _characterController = null;
        private ReactiveVariable<Vector3> _moveDirection = null;
        private ReactiveVariable<float> _moveSpeed = null;
        private ICompositeCondition _canMove = null;
        private ReactiveVariable<bool> _isMoving = null;

        public void OnInit(Entity entity)
        {
            _characterController = entity.CharacterController;
            _moveDirection = entity.MoveDirection;
            _moveSpeed = entity.MoveSpeed;
            _canMove = entity.CanMove;
            _isMoving = entity.IsMoving;
        }

        public void OnUpdateTick(float deltaTime)
        {
            if (_canMove.Evaluate() == false)
            {
                _characterController.Move(Vector3.zero);

                return;
            }

            Vector3 velocity = _moveDirection.Value.normalized * _moveSpeed.Value;

            _isMoving.Value = velocity.magnitude > 0f;

            _characterController.Move(velocity * deltaTime);
        }
    }
}