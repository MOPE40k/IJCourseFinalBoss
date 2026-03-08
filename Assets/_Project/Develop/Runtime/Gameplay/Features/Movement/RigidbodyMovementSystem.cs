using UnityEngine;
using Runtime.Gameplay.EntitiesCore;
using Runtime.Gameplay.EntitiesCore.Systems;
using Runtime.Utils.Reactive;
using Runtime.Utils.Conditions;

namespace Runtime.Gameplay.Features.Movement
{
    public class RigidbodyMovementSystem : IInitializableSystem, IFixedUpdatableSystem
    {
        // References
        private Rigidbody _rigidbody = null;
        private ReactiveVariable<Vector3> _moveDirection = null;
        private ReactiveVariable<float> _moveSpeed = null;
        private ICompositeCondition _canMove = null;
        private ReactiveVariable<bool> _isMoving = null;

        public void OnInit(Entity entity)
        {
            _rigidbody = entity.Rigidbody;
            _moveDirection = entity.MoveDirection;
            _moveSpeed = entity.MoveSpeed;
            _canMove = entity.CanMove;
            _isMoving = entity.IsMoving;
        }

        public void OnFixedUpdateTick(float fixedDeltaTime)
        {
            if (_canMove.Evaluate() == false)
            {
                _rigidbody.velocity = Vector3.zero;

                return;
            }

            Vector3 velocity = _moveDirection.Value.normalized * _moveSpeed.Value;

            _isMoving.Value = velocity.magnitude > 0f;

            _rigidbody.velocity = velocity;
        }
    }
}