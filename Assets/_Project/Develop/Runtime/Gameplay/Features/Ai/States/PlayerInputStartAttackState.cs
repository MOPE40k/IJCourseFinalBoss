using Runtime.Gameplay.EntitiesCore;
using Runtime.Gameplay.Features.InputFeature;
using Runtime.Utils.Reactive;
using Runtime.Utils.StateMachineCore;

namespace Runtime.Gameplay.Features.Ai.States
{
    public class PlayerInputStartAttackState : State, IUpdatableState
    {
        // Delegates
        private readonly ReactiveEvent _startAttackRequest = null;

        // References
        private readonly IInputService _inputService = null;

        public PlayerInputStartAttackState(Entity entity, IInputService inputService)
        {
            _inputService = inputService;
            _startAttackRequest = entity.StartAttackRequest;
        }

        public void UpdateTick(float deltaTime)
        {
            if (_inputService.IsFire)
                _startAttackRequest.Invoke();
        }
    }
}