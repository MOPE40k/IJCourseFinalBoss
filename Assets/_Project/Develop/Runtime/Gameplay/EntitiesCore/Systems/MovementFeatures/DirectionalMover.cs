using Runtime.Utils.Reactive;
using UnityEngine;

namespace Runtime.Gameplay.EntitiesCore.Systems.MovementFeatures
{
    public abstract class DirectionalMover : IInitializableSystem, IUpdatableSystem, IFixedUpdatableSystem
    {
        // Runtime
        private ReactiveVeriable<Vector3> _moveDirection = null;
        private ReactiveVeriable<float> _moveSpeed = null;

        public Vector3 CurrentVelocity => _moveDirection.Value.normalized * _moveSpeed.Value;

        public void OnInit(Entity entity)
        {
            SetMovableComponent(entity);

            _moveDirection = entity.MoveDirection;
            _moveSpeed = entity.MoveSpeed;
        }

        public abstract void OnUpdateTick(float deltaTime);

        public abstract void OnFixedUpdateTick(float fixedDeltaTime);

        protected abstract void SetMovableComponent(Entity entity);
    }
}