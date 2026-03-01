using UnityEngine;
using Runtime.Utils.Reactive;

namespace Runtime.Gameplay.EntitiesCore.Systems.MovementFeatures
{
    public class CharacterControllerMovementSystem : DirectionalMover
    {
        // References
        private CharacterController _characterController = null;

        public override void OnUpdateTick(float deltaTime)
            => _characterController.Move(CurrentVelocity * deltaTime);

        public override void OnFixedUpdateTick(float fixedDeltaTime)
        { }

        protected override void SetMovableComponent(Entity entity)
            => _characterController = entity.CharacterController;
    }
}