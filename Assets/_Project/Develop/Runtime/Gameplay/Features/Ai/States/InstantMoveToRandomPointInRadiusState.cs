using Runtime.Gameplay.EntitiesCore;
using Runtime.Utils.Reactive;
using Runtime.Utils.StateMachineCore;
using UnityEngine;

namespace Runtime.Gameplay.Features.Ai.States
{
    public class InstantMoveToRandomPointInRadiusState : State, IUpdatableState
    {
        // Delegates
        private readonly ReactiveEvent _startInstantMoveRequest = null;

        // Settings
        private readonly ReactiveVariable<float> _moveRadius = null;

        // Runtime
        private readonly ReactiveVariable<Vector3> _instantMoveDestinationPosition = null;

        public InstantMoveToRandomPointInRadiusState(Entity entity)
        {
            _startInstantMoveRequest = entity.StartInstantMoveRequest;
            _moveRadius = entity.MoveRadius;
            _instantMoveDestinationPosition = entity.InstantMoveDestinationPosition;
        }

        public override void Enter()
        {
            base.Enter();

            Vector3 randomDirection = new Vector3(
                Random.Range(0f, 1f),
                0f,
                Random.Range(0f, 1f)).normalized;

            randomDirection *= Random.Range(0f, _moveRadius.Value);

            _instantMoveDestinationPosition.Value = randomDirection;

            _startInstantMoveRequest.Invoke();
        }

        public void UpdateTick(float deltaTime)
        { }
    }
}