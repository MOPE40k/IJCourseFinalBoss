using UnityEngine;

namespace Runtime.Gameplay.EntitiesCore.Systems.MovementFeatures
{
    public class TransformMovementSystem : DirectionalMover
    {
        // References
        private Transform _transform = null;

        public override void OnUpdateTick(float deltaTime)
            => _transform.position += CurrentVelocity * deltaTime;

        public override void OnFixedUpdateTick(float fixedDeltaTime)
        { }

        protected override void SetMovableComponent(Entity entity)
            => _transform = entity.Transform;
    }
}