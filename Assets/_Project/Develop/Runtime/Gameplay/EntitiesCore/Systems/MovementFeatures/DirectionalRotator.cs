using System;
using UnityEngine;
using Runtime.Utils.Reactive;

namespace Runtime.Gameplay.EntitiesCore.Systems.MovementFeatures
{
    public abstract class DirectionalRotator : IInitializableSystem, IUpdatableSystem
    {
        // Consts
        private const float RotationThreshold = 0.05f;

        // Runtime
        private ReactiveVeriable<Vector3> _moveDirection = null;
        private ReactiveVeriable<float> _rotationSpeed = null;

        protected abstract Quaternion CurrentRotation { get; }

        public void OnInit(Entity entity)
        {
            SetRotatableComponent(entity);

            _moveDirection = entity.MoveDirection;
            _rotationSpeed = entity.RotateSpeed;
        }

        public void OnUpdateTick(float deltaTime)
        {
            if (IsRotationThresholdNotReached())
                return;

            Quaternion targetRotation = Quaternion.LookRotation(_moveDirection.Value);

            float rotationDelta = _rotationSpeed.Value * deltaTime;

            ApplyRotation(Quaternion.RotateTowards(CurrentRotation, targetRotation, rotationDelta));
        }

        protected abstract void SetRotatableComponent(Entity entity);

        protected abstract void ApplyRotation(Quaternion rotation);

        private bool IsRotationThresholdNotReached()
            => _moveDirection.Value.sqrMagnitude <= RotationThreshold * RotationThreshold;
    }
}