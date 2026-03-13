namespace Runtime.Utils.StateMachineCore
{
    public interface IUpdatableState : IState
    {
        void UpdateTick(float deltaTime);
    }
}