using Runtime.Gameplay.EntitiesCore;
using Runtime.Utils.Reactive;
using Runtime.Utils.StateMachineCore;
using UnityEngine;

namespace Runtime.Gameplay.Features.Ai.States.InstantMove
{
    public class InstantMoveToRandomPointState : State, IUpdatableState
    {
        // Delegates
        private readonly ReactiveEvent _startInstantMoveRequest = null;

        // References
        IInstantMoveEndPointProvider _instantMoveEndPointProvider = null;

        // Runtime
        private readonly ReactiveVariable<Vector3> _instantMoveDestinationPosition = null;

        public InstantMoveToRandomPointState(Entity entity, IInstantMoveEndPointProvider endPointProvider)
        {
            _startInstantMoveRequest = entity.StartInstantMoveRequest;

            _instantMoveEndPointProvider = endPointProvider;
            _instantMoveDestinationPosition = entity.EndPositionForInstantMove;
        }

        public override void Enter()
        {
            base.Enter();

            _instantMoveDestinationPosition.Value = _instantMoveEndPointProvider.GetDirection();

            _startInstantMoveRequest.Invoke();
        }

        public void UpdateTick(float deltaTime)
        { }
    }
}