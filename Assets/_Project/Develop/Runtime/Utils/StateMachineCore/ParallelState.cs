using System.Collections.Generic;

namespace Runtime.Utils.StateMachineCore
{
    public abstract class ParallelState<TState> : State where TState : class, IState
    {
        // Runtime
        private List<State> _states = null;

        public ParallelState(State[] states)
        {
            _states = new List<State>(states);
        }

        public IReadOnlyList<State> States => _states;

        public override void Enter()
        {
            base.Enter();

            foreach (State state in _states)
                state.Enter();
        }

        public override void Exit()
        {
            base.Exit();

            foreach (State state in _states)
                state.Exit();
        }
    }
}