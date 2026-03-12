using System;
using Runtime.Gameplay.EntitiesCore;
using Runtime.Gameplay.EntitiesCore.Systems;
using Runtime.Utils.Conditions;
using Runtime.Utils.Reactive;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Runtime.Gameplay.Features.Movement.InstantMove
{
    public class EndInstantMoveSystem : IInitializableSystem, IDisposableSystem
    {
        // References
        private Rigidbody _rigidbody = null;
        private ReactiveVariable<Vector3> _startPosition = null;
        private ReactiveVariable<float> _moveRadius = null;
        private ReactiveVariable<float> _instantMoveProcessInitialTime = null;
        private ReactiveVariable<float> _instantMoveProcessCurrentTime = null;
        private ReactiveVariable<bool> _inInstantMoveProcess = null;
        private ReactiveEvent _endInstantMoveEvent = null;

        // Runtime
        private IDisposable _timerChanged = null;

        public void OnInit(Entity entity)
        {
            _rigidbody = entity.Rigidbody;
            _startPosition = entity.StartPosition;
            _moveRadius = entity.MoveRadius;
            _instantMoveProcessInitialTime = entity.InstantMoveProcessInitialTime;
            _instantMoveProcessCurrentTime = entity.InstantMoveProcessCurrentTime;
            _inInstantMoveProcess = entity.InInstantMoveProcess;
            _endInstantMoveEvent = entity.EndInstantMoveEvent;

            _timerChanged = _instantMoveProcessCurrentTime.Subscribe(OnTimerChanged);
        }

        private void OnTimerChanged(float arg1, float currentTime)
        {
            if (TimeIsOver(currentTime))
            {
                _rigidbody.position = GetRandomPositionInRadius();

                _inInstantMoveProcess.Value = false;

                _endInstantMoveEvent.Invoke();
            }
        }

        private bool TimeIsOver(float currentTime)
            => currentTime >= _instantMoveProcessInitialTime.Value;

        public void OnDispose()
            => _timerChanged.Dispose();

        private Vector3 GetRandomPositionInRadius()
            => new Vector3(
                _startPosition.Value.x + Random.Range(0f, _moveRadius.Value),
                0f,
                _startPosition.Value.z + Random.Range(0f, _moveRadius.Value));
    }
}