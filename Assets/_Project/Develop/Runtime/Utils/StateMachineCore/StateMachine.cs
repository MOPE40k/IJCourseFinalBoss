using System;
using System.Collections.Generic;
using System.Linq;
using Runtime.Utils.Conditions;

namespace Runtime.Utils.StateMachineCore
{
    public abstract class StateMachine<TState> : State, IUpdatableState, IDisposable where TState : class, IState
    {
        // Runtime
        private List<StateNode<TState>> _states = new();
        private StateNode<TState> _currentState = null;
        private bool _isRunning = false;

        private List<IDisposable> _disposables = null;

        protected StateMachine(List<IDisposable> disposables)
            => _disposables = new List<IDisposable>(disposables);

        public TState CurrentState => _currentState.State;

        public StateMachine<TState> AddState(TState state)
        {
            _states.Add(new StateNode<TState>(state));

            return this;
        }

        public StateMachine<TState> AddTransition(TState fromState, TState toState, ICondition condition)
        {
            StateNode<TState> from = _states.First(stateNode => stateNode.State == fromState);
            StateNode<TState> to = _states.First(stateNode => stateNode.State == toState);

            from.AddTransition(new StateTransition<TState>(to, condition));

            return this;
        }

        public override void Enter()
        {
            base.Enter();

            if (_currentState is null)
                SwitchState(_states[0]);
            else
                _currentState.State.Enter();

            _isRunning = true;
        }

        public override void Exit()
        {
            base.Exit();

            _currentState?.State.Exit();

            _isRunning = false;
        }

        public void UpdateTick(float deltaTime)
        {
            if (_isRunning == false)
                return;

            foreach (StateTransition<TState> transition in _currentState.Transitions)
            {
                if (transition.Condition.Evaluate())
                {
                    SwitchState(transition.ToState);

                    break;
                }
            }

            UpdateLogic(deltaTime);
        }

        public void SwitchState(StateNode<TState> nextState)
        {
            _currentState?.State.Exit();

            _currentState = nextState;

            _currentState.State.Enter();
        }

        public void Dispose()
        {
            _isRunning = false;

            foreach (StateNode<TState> state in _states)
                if (state is IDisposable disposable)
                    disposable.Dispose();

            _states.Clear();

            foreach (IDisposable disposable in _disposables)
                disposable.Dispose();

            _disposables.Clear();
        }

        protected virtual void UpdateLogic(float deltaTime)
        { }
    }
}