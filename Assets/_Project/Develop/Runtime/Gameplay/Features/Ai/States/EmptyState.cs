using Runtime.Utils.StateMachineCore;

namespace Runtime.Gameplay.Features.Ai.States
{
    public class EmptyState : State, IUpdatableState
    {
        public void UpdateTick(float deltaTime)
        { }
    }
}