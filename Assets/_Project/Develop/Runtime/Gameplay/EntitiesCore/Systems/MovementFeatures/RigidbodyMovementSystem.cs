using UnityEngine;

namespace Runtime.Gameplay.EntitiesCore.Systems.MovementFeatures
{
    public class RigidbodyMovementSystem : DirectionalMover
    {
        // References
        private Rigidbody _rigidbody = null;

        public override void OnUpdateTick(float deltaTime)
        { }

        public override void OnFixedUpdateTick(float fixedDeltaTime)
            => _rigidbody.velocity = CurrentVelocity;

        protected override void SetMovableComponent(Entity entity)
            => _rigidbody = entity.Rigidbody;
    }
}