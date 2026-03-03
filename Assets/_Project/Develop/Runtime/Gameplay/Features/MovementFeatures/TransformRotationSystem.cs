using Runtime.Gameplay.EntitiesCore;
using Runtime.Gameplay.EntitiesCore.Features;
using Runtime.Utils.Reactive;
using UnityEngine;

namespace Runtime.Gameplay.Features.MovementFeatures
{
    public class TransformRotationSystem : IInitializableSystem, IUpdatableSystem
    {
        // Consts
        private const float RotationThreshold = 0.05f;

        // References
        private Transform _transform = null;
        private ReactiveVeriable<Vector3> _moveDirection = null;
        private ReactiveVeriable<float> _rotationSpeed = null;


        public void OnInit(Entity entity)
        {
            _transform = entity.Transform;
            _moveDirection = entity.MoveDirection;
            _rotationSpeed = entity.RotateSpeed;
        }

        public void OnUpdateTick(float deltaTime)
        {
            if (IsRotationThresholdNotReached())
                return;

            Quaternion targetRotation = Quaternion.LookRotation(_moveDirection.Value);

            float rotationDelta = _rotationSpeed.Value * deltaTime;

            Quaternion newRotation = Quaternion.RotateTowards(
                _transform.rotation,
                 targetRotation,
                 rotationDelta);

            _transform.rotation = newRotation;
        }

        private bool IsRotationThresholdNotReached()
            => _moveDirection.Value.sqrMagnitude <= RotationThreshold * RotationThreshold;
    }
}