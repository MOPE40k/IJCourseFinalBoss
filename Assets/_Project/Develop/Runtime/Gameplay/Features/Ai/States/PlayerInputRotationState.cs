using Runtime.Gameplay.EntitiesCore;
using Runtime.Gameplay.Features.InputFeature;
using Runtime.Utils.Reactive;
using Runtime.Utils.StateMachineCore;
using UnityEngine;

namespace Runtime.Gameplay.Features.Ai.States
{
    public class PlayerInputRotationState : State, IUpdatableState
    {
        // References
        private readonly IInputService _inputService = null;
        private readonly Transform _transform = null;
        private readonly Camera _cameraMain = null;

        // Runtime
        private readonly ReactiveVariable<Vector3> _rotationDirection = null;

        public PlayerInputRotationState(Entity entity, IInputService inputService, Camera camera = null)
        {
            _inputService = inputService;
            _rotationDirection = entity.RotationDirection;
            _transform = entity.Transform;

            if (camera == null)
                _cameraMain = Camera.main;
        }

        public override void Enter()
        {
            base.Enter();

            _rotationDirection.Value = Vector3.zero;
        }

        public override void Exit()
        {
            base.Exit();

            _rotationDirection.Value = Vector3.zero;
        }

        public void UpdateTick(float deltaTime)
        {
            Ray mousePointRay = _cameraMain.ScreenPointToRay(_inputService.MousePosition);

            Plane groundPlane = new Plane(Vector3.up, _transform.position);

            if (groundPlane.Raycast(mousePointRay, out float distanceToMousePoint))
            {
                Vector3 mousePoint = mousePointRay.GetPoint(distanceToMousePoint);

                Vector3 lookDirection = (mousePoint - _transform.position).normalized;
                lookDirection.y = 0f;

                _rotationDirection.Value = lookDirection;
            }
        }
    }
}