using UnityEngine;

namespace Runtime.Gameplay.EntitiesCore.Systems.MovementFeatures
{
    public class RigidbodyRotationSystem : DirectionalRotator
    {
        // References
        private Rigidbody _rigidbody = null;

        protected override Quaternion CurrentRotation => _rigidbody.rotation;

        protected override void SetRotatableComponent(Entity entity)
            => _rigidbody = entity.Rigidbody;

        protected override void ApplyRotation(Quaternion rotation)
            => _rigidbody.rotation = rotation;
    }
}