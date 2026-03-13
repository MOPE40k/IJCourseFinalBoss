using Runtime.Utils.StateMachineCore;

namespace Runtime.Gameplay.Features.Ai
{
    public class AiParallelState : ParallelState<IUpdatableState>, IUpdatableState
    {
        public AiParallelState(State[] states) : base(states)
        { }

        public void UpdateTick(float deltaTime)
        {
            foreach (IUpdatableState state in States)
                state.UpdateTick(deltaTime);
        }
    }
}