using UnityEngine;
using Runtime.Gameplay.EntitiesCore;
using Runtime.Gameplay.EntitiesCore.Systems;
using Runtime.Utils.Reactive;
using Runtime.Utils.Conditions;

namespace Runtime.Gameplay.Features.Movement
{
    public class RigidbodyRotationSystem : IInitializableSystem, IFixedUpdatableSystem
    {
        // Consts
        private const float RotationThreshold = 0.05f;

        // References
        private Rigidbody _rigidbody = null;
        private ReactiveVariable<Vector3> _rotationDirection = null;
        private ReactiveVariable<float> _rotationSpeed = null;
        private ICompositeCondition _canRotate = null;

        public void OnInit(Entity entity)
        {
            _rigidbody = entity.Rigidbody;
            _rotationDirection = entity.RotationDirection;
            _rotationSpeed = entity.RotationSpeed;
            _canRotate = entity.CanRotate;

            if (_rotationDirection.Value != Vector3.zero)
                _rigidbody.transform.rotation = Quaternion.LookRotation(_rotationDirection.Value);
        }

        public void OnFixedUpdateTick(float fixedDeltaTime)
        {
            if (_canRotate.Evaluate() == false)
                return;

            if (IsRotationThresholdNotReached())
                return;

            Quaternion targetRotation = Quaternion.LookRotation(_rotationDirection.Value);

            float rotationDelta = _rotationSpeed.Value * fixedDeltaTime;

            Quaternion newRotation = Quaternion.RotateTowards(
                _rigidbody.rotation,
                targetRotation,
                rotationDelta);

            _rigidbody.MoveRotation(newRotation);
        }

        private bool IsRotationThresholdNotReached()
            => _rotationDirection.Value.sqrMagnitude < RotationThreshold * RotationThreshold;
    }
}