namespace Runtime.Gameplay.Features.Ai
{
    public class StateMachineBrain : IBrain
    {
        // References
        private readonly AiStateMachine _stateMachine = null;

        // Runtime
        private bool _isEnabled = false;

        public StateMachineBrain(AiStateMachine aiStateMachine)
            => _stateMachine = aiStateMachine;

        public void Enable()
        {
            _stateMachine.Enter();

            _isEnabled = true;
        }

        public void Disable()
        {
            _stateMachine.Exit();

            _isEnabled = false;
        }

        public void UpdateTick(float deltaTime)
        {
            if (_isEnabled == false)
                return;

            _stateMachine.UpdateTick(deltaTime);
        }

        public void Dispose()
        {
            _stateMachine.Dispose();

            _isEnabled = false;
        }
    }
}