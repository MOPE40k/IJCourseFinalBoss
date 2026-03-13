using Runtime.Gameplay.EntitiesCore;
using Runtime.Utils.Reactive;
using Runtime.Utils.StateMachineCore;

namespace Runtime.Gameplay.Features.Ai.States
{
    public class AttackTriggerState : State, IUpdatableState
    {
        // References
        private readonly ReactiveEvent _startAttackRequest = null;

        public AttackTriggerState(Entity entity)
            => _startAttackRequest = entity.StartAttackRequest;

        public override void Enter()
        {
            base.Enter();

            _startAttackRequest.Invoke();
        }

        public void UpdateTick(float deltaTime)
        { }
    }
}