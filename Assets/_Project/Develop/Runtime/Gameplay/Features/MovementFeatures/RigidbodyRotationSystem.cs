using Runtime.Gameplay.EntitiesCore;
using Runtime.Gameplay.EntitiesCore.Features;
using Runtime.Utils.Reactive;
using UnityEngine;

namespace Runtime.Gameplay.Features.MovementFeatures
{
    public class RigidbodyRotationSystem : IInitializableSystem, IFixedUpdatableSystem
    {
        // Consts
        private const float RotationThreshold = 0.05f;

        // References
        private Rigidbody _rigidbody = null;
        private ReactiveVeriable<Vector3> _moveDirection = null;
        private ReactiveVeriable<float> _rotationSpeed = null;

        public void OnInit(Entity entity)
        {
            _rigidbody = entity.Rigidbody;
            _moveDirection = entity.MoveDirection;
            _rotationSpeed = entity.RotateSpeed;
        }

        public void OnFixedUpdateTick(float fixedDeltaTime)
        {
            if (IsRotationThresholdNotReached())
                return;

            Quaternion targetRotation = Quaternion.LookRotation(_moveDirection.Value);

            float rotationDelta = _rotationSpeed.Value * fixedDeltaTime;

            Quaternion newRotation = Quaternion.RotateTowards(
                _rigidbody.rotation,
                targetRotation,
                rotationDelta);

            _rigidbody.MoveRotation(newRotation);
        }

        private bool IsRotationThresholdNotReached()
            => _moveDirection.Value.sqrMagnitude <= RotationThreshold * RotationThreshold;

    }
}