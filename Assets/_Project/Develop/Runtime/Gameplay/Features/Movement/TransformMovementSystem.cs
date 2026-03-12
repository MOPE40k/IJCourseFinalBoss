using UnityEngine;
using Runtime.Gameplay.EntitiesCore;
using Runtime.Gameplay.EntitiesCore.Systems;
using Runtime.Utils.Reactive;
using Runtime.Utils.Conditions;

namespace Runtime.Gameplay.Features.Movement
{
    public class TransformMovementSystem : IInitializableSystem, IUpdatableSystem
    {
        // References
        private Transform _transform = null;
        private ReactiveVariable<Vector3> _moveDirection = null;
        private ReactiveVariable<float> _moveSpeed = null;
        private ICompositeCondition _canMove = null;
        private ReactiveVariable<bool> _isMoving = null;

        public void OnInit(Entity entity)
        {
            _transform = entity.Transform;
            _moveDirection = entity.MoveDirection;
            _moveSpeed = entity.MoveSpeed;
            _canMove = entity.CanMove;
            _isMoving = entity.IsMoving;
        }

        public void OnUpdateTick(float deltaTime)
        {
            if (_canMove.Evaluate() == false)
            {
                _transform.position += Vector3.zero;

                return;
            }

            Vector3 velocity = _moveDirection.Value.normalized * _moveSpeed.Value;

            _isMoving.Value = velocity.magnitude > 0f;

            _transform.position += velocity * deltaTime;
        }
    }
}