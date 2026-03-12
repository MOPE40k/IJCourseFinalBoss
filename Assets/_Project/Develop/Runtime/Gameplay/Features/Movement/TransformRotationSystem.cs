using Runtime.Gameplay.EntitiesCore;
using Runtime.Gameplay.EntitiesCore.Systems;
using Runtime.Utils.Conditions;
using Runtime.Utils.Reactive;
using UnityEngine;

namespace Runtime.Gameplay.Features.Movement
{
    public class TransformRotationSystem : IInitializableSystem, IUpdatableSystem
    {
        // Consts
        private const float RotationThreshold = 0.05f;

        // References
        private Transform _transform = null;
        private ReactiveVariable<Vector3> _rotationDirection = null;
        private ReactiveVariable<float> _rotationSpeed = null;
        private ICompositeCondition _canRotate = null;

        public void OnInit(Entity entity)
        {
            _transform = entity.Transform;
            _rotationDirection = entity.RotationDirection;
            _rotationSpeed = entity.RotationSpeed;
            _canRotate = entity.CanRotate;
        }

        public void OnUpdateTick(float deltaTime)
        {
            if (_canRotate.Evaluate() == false)
                return;

            if (IsRotationThresholdNotReached())
                return;

            Quaternion targetRotation = Quaternion.LookRotation(_rotationDirection.Value);

            float rotationDelta = _rotationSpeed.Value * deltaTime;

            Quaternion newRotation = Quaternion.RotateTowards(
                _transform.rotation,
                targetRotation,
                rotationDelta);

            _transform.rotation = newRotation;
        }

        private bool IsRotationThresholdNotReached()
            => _rotationDirection.Value.sqrMagnitude < RotationThreshold * RotationThreshold;
    }
}