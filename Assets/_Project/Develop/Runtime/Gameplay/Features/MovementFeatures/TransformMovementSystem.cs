using Runtime.Gameplay.EntitiesCore;
using Runtime.Gameplay.EntitiesCore.Features;
using Runtime.Utils.Reactive;
using UnityEngine;

namespace Runtime.Gameplay.Features.MovementFeatures
{
    public class TransformMovementSystem : IInitializableSystem, IUpdatableSystem
    {
        // References
        private Transform _transform = null;
        private ReactiveVeriable<Vector3> _moveDirection = null;
        private ReactiveVeriable<float> _moveSpeed = null;

        public void OnInit(Entity entity)
        {
            _transform = entity.Transform;
            _moveDirection = entity.MoveDirection;
            _moveSpeed = entity.MoveSpeed;
        }

        public void OnUpdateTick(float deltaTime)
        {
            Vector3 velocity = _moveDirection.Value.normalized * _moveSpeed.Value;

            _transform.position += velocity * deltaTime;
        }
    }
}