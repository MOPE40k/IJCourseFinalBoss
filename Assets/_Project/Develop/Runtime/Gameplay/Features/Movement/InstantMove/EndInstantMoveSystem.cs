using System;
using Runtime.Gameplay.EntitiesCore;
using Runtime.Gameplay.EntitiesCore.Systems;
using Runtime.Utils.Reactive;
using UnityEngine;

namespace Runtime.Gameplay.Features.Movement.InstantMove
{
    public class EndInstantMoveSystem : IInitializableSystem, IDisposableSystem
    {
        // Delegates
        private ReactiveEvent _startInstantMoveEvent = null;
        private ReactiveEvent _endInstantMoveEvent = null;

        // References
        private Rigidbody _rigidbody = null;
        private ReactiveVariable<Vector3> _endPositionForInstantMove = null;
        private ReactiveVariable<bool> _inInstantMoveProcess = null;

        // Runtime
        private IDisposable _startInstantMoveEventDisposable = null;

        public void OnInit(Entity entity)
        {
            _startInstantMoveEvent = entity.StartInstantMoveEvent;
            _endInstantMoveEvent = entity.EndInstantMoveEvent;
            _rigidbody = entity.Rigidbody;
            _endPositionForInstantMove = entity.EndPositionForInstantMove;
            _inInstantMoveProcess = entity.InInstantMoveProcess;
            _startInstantMoveEventDisposable = _startInstantMoveEvent.Subscribe(OnStartInstantMove);
        }



        public void OnDispose()
            => _startInstantMoveEventDisposable.Dispose();

        private void OnStartInstantMove()
        {
            _rigidbody.position = _endPositionForInstantMove.Value;

            _inInstantMoveProcess.Value = false;

            _endInstantMoveEvent.Invoke();
        }
    }
}