using System;
using Runtime.Gameplay.EntitiesCore;
using Runtime.Gameplay.EntitiesCore.Systems;
using Runtime.Utils.Reactive;

namespace Runtime.Gameplay.Features.Movement.InstantMove
{
    public class InstantMoveProcessTimerSystem : IInitializableSystem, IUpdatableSystem, IDisposable
    {
        // References
        private ReactiveVariable<float> _currentTime = null;
        private ReactiveVariable<bool> _inInstantMoveProcess = null;
        private ReactiveEvent _startInstantMoveEvent = null;

        // Runtime
        private IDisposable _startInstantMoveEventDisposable = null;

        public void OnInit(Entity entity)
        {
            _currentTime = entity.InstantMoveProcessCurrentTime;
            _inInstantMoveProcess = entity.InInstantMoveProcess;
            _startInstantMoveEvent = entity.StartInstantMoveEvent;

            _startInstantMoveEventDisposable = _startInstantMoveEvent.Subscribe(OnStartInstantMove);
        }

        public void OnUpdateTick(float deltaTime)
        {
            if (_inInstantMoveProcess.Value == false)
                return;

            _currentTime.Value += deltaTime;
        }

        public void Dispose()
            => _startInstantMoveEventDisposable.Dispose();

        private void OnStartInstantMove()
            => _currentTime.Value = 0f;
    }
}