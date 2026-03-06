using Runtime.Gameplay.EntitiesCore;
using Runtime.Gameplay.EntitiesCore.Features;
using Runtime.Utils.Reactive;
using UnityEngine;

namespace Runtime.Gameplay.Features.MovementFeatures
{
    public class RigidbodyMovementSystem : IInitializableSystem, IFixedUpdatableSystem
    {
        // References
        private Rigidbody _rigidbody = null;
        private ReactiveVeriable<Vector3> _moveDirection = null;
        private ReactiveVeriable<float> _moveSpeed = null;

        public void OnInit(Entity entity)
        {
            _rigidbody = entity.Rigidbody;
            _moveDirection = entity.MoveDirection;
            _moveSpeed = entity.MoveSpeed;
        }

        public void OnFixedUpdateTick(float fixedDeltaTime)
        {
            Vector3 velocity = _moveDirection.Value.normalized * _moveSpeed.Value;

            _rigidbody.velocity = velocity;
        }
    }
}