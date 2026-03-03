using UnityEngine;
using Runtime.Utils.Reactive;
using Runtime.Gameplay.EntitiesCore;
using Runtime.Gameplay.EntitiesCore.Features;

namespace Runtime.Gameplay.Features.MovementFeatures
{
    public class CharacterControllerMovementSystem : IInitializableSystem, IUpdatableSystem
    {
        // References
        private CharacterController _characterController = null;
        private ReactiveVeriable<Vector3> _moveDirection = null;
        private ReactiveVeriable<float> _moveSpeed = null;

        public void OnInit(Entity entity)
        {
            _characterController = entity.CharacterController;
            _moveDirection = entity.MoveDirection;
            _moveSpeed = entity.MoveSpeed;
        }

        public void OnUpdateTick(float deltaTime)
        {
            Vector3 velocity = _moveDirection.Value.normalized * _moveSpeed.Value;

            _characterController.Move(velocity * deltaTime);
        }
    }
}