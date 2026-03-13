using System;
using Runtime.Gameplay.EntitiesCore;
using Runtime.Gameplay.EntitiesCore.Systems;
using Runtime.Utils.Reactive;
using UnityEngine;

namespace Runtime.Gameplay.Features.Movement.InstantMove
{
    public class EndInstantMoveSystem : IInitializableSystem, IDisposableSystem
    {
        // References
        private Rigidbody _rigidbody = null;
        private ReactiveVariable<float> _instantMoveProcessInitialTime = null;
        private ReactiveVariable<float> _instantMoveProcessCurrentTime = null;
        private ReactiveVariable<Vector3> _instantMoveDestinationPosition = null;
        private ReactiveVariable<bool> _inInstantMoveProcess = null;
        private ReactiveEvent _endInstantMoveEvent = null;

        // Runtime
        private IDisposable _timerChanged = null;

        public void OnInit(Entity entity)
        {
            _rigidbody = entity.Rigidbody;
            _instantMoveProcessInitialTime = entity.InstantMoveProcessInitialTime;
            _instantMoveProcessCurrentTime = entity.InstantMoveProcessCurrentTime;
            _instantMoveDestinationPosition = entity.InstantMoveDestinationPosition;
            _inInstantMoveProcess = entity.InInstantMoveProcess;
            _endInstantMoveEvent = entity.EndInstantMoveEvent;

            _timerChanged = _instantMoveProcessCurrentTime.Subscribe(OnTimerChanged);
        }

        private void OnTimerChanged(float arg1, float currentTime)
        {
            if (TimeIsOver(currentTime))
            {
                _rigidbody.position = _instantMoveDestinationPosition.Value;

                _inInstantMoveProcess.Value = false;

                _endInstantMoveEvent.Invoke();
            }
        }

        private bool TimeIsOver(float currentTime)
            => currentTime >= _instantMoveProcessInitialTime.Value;

        public void OnDispose()
            => _timerChanged.Dispose();
    }
}