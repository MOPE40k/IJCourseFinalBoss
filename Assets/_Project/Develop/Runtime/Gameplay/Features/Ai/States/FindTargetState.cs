using Runtime.Gameplay.EntitiesCore;
using Runtime.Utils.Reactive;
using Runtime.Utils.StateMachineCore;

namespace Runtime.Gameplay.Features.Ai.States
{
    public class FindTargetState : State, IUpdatableState
    {
        // References
        private readonly ITargetSelector _targetSelector = null;
        private readonly EntitiesLifeContext _entitiesLifeContext = null;
        private readonly ReactiveVariable<Entity> _currentTarget = null;

        public FindTargetState(
            ITargetSelector targetSelector,
            EntitiesLifeContext entitiesLifeContext,
            Entity entity)
        {
            _targetSelector = targetSelector;
            _entitiesLifeContext = entitiesLifeContext;
            _currentTarget = entity.CurrentTarget;
        }

        public void UpdateTick(float deltaTime)
            => _currentTarget.Value = _targetSelector.SelectTargetFrom(_entitiesLifeContext.Entities);
    }
}