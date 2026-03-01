using UnityEngine;

namespace Runtime.Gameplay.EntitiesCore.Systems.MovementFeatures
{
    public class TransformRotationSystem : DirectionalRotator
    {
        // References
        private Transform _transform = null;

        protected override Quaternion CurrentRotation => _transform.rotation;

        protected override void SetRotatableComponent(Entity entity)
            => _transform = entity.Transform;

        protected override void ApplyRotation(Quaternion rotation)
            => _transform.rotation = rotation;
    }
}