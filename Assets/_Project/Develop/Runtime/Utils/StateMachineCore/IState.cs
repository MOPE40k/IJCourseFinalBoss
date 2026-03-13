using Runtime.Utils.Reactive;

namespace Runtime.Utils.StateMachineCore
{
    public interface IState
    {
        IReadOnlyEvent Entered { get; }
        IReadOnlyEvent Exited { get; }
        void Enter();
        void Exit();
    }
}