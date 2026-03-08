using Runtime.Gameplay.EntitiesCore;
using Runtime.Gameplay.EntitiesCore.Systems;
using Runtime.Utils.Reactive;
using System;

namespace Runtime.Gameplay.Features.LifeCycle
{
    public class DeathProcessTimerSystem : IInitializableSystem, IUpdatableSystem, IDisposableSystem
    {
        // References
        private ReactiveVariable<bool> _isDead = null;
        private ReactiveVariable<bool> _inDeathProcess = null;
        private ReactiveVariable<float> _initialTimer = null;
        private ReactiveVariable<float> _currentTimer = null;

        // Runtime
        private IDisposable _isDeadChangedDisposable = null;

        public void OnInit(Entity entity)
        {
            _isDead = entity.IsDead;
            _inDeathProcess = entity.InDeathProcess;
            _initialTimer = entity.DeathProcessInitialTimer;
            _currentTimer = entity.DeathProcessCurrentTimer;

            _isDeadChangedDisposable = _isDead.Subscribe(OnIsDeadChanged);
        }

        public void OnUpdateTick(float deltaTime)
        {
            if (_inDeathProcess.Value == false)
                return;

            _currentTimer.Value -= deltaTime;

            if (IsCooldownOver())
                _inDeathProcess.Value = false;
        }

        public void OnDispose()
            => _isDeadChangedDisposable.Dispose();

        private bool IsCooldownOver()
            => _currentTimer.Value <= 0f;

        private void OnIsDeadChanged(bool arg1, bool isDead)
        {
            if (isDead)
            {
                _inDeathProcess.Value = true;

                _currentTimer.Value = _initialTimer.Value;
            }
        }
    }
}