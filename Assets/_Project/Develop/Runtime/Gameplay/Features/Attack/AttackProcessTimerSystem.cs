using System;
using Runtime.Gameplay.EntitiesCore;
using Runtime.Gameplay.EntitiesCore.Systems;
using Runtime.Utils.Reactive;

namespace Runtime.Gameplay.Features.Attack
{
    public class AttackProcessTimerSystem : IInitializableSystem, IUpdatableSystem, IDisposableSystem
    {
        // References
        private ReactiveVariable<float> _currentTime = null;
        private ReactiveVariable<bool> _inAttackProcess = null;
        private ReactiveEvent _startAttackEvent = null;

        // Runtime
        private IDisposable _startAttackDisposable = null;

        public void OnInit(Entity entity)
        {
            _currentTime = entity.AttackProcessCurrentTime;
            _inAttackProcess = entity.InAttackProcess;
            _startAttackEvent = entity.StartAttackEvent;

            _startAttackDisposable = _startAttackEvent.Subscribe(OnStartAttack);
        }

        public void OnUpdateTick(float deltaTime)
        {
            if (_inAttackProcess.Value == false)
                return;

            _currentTime.Value += deltaTime;
        }

        public void OnDispose()
            => _startAttackDisposable.Dispose();

        private void OnStartAttack()
            => _currentTime.Value = 0f;
    }
}