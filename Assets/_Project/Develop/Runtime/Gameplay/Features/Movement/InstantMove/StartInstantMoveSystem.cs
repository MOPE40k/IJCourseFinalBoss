using System;
using Runtime.Gameplay.EntitiesCore;
using Runtime.Gameplay.EntitiesCore.Systems;
using Runtime.Utils.Conditions;
using Runtime.Utils.Reactive;
using UnityEngine;

namespace Runtime.Gameplay.Features.Movement.InstantMove
{
    public class StartInstantMoveSystem : IInitializableSystem, IDisposableSystem
    {
        // Delegates
        private ReactiveEvent _startMoveRequest = null;
        private ReactiveEvent _startMoveEvent = null;


        // References
        private ReactiveVariable<float> _currentStamina = null;
        private ReactiveVariable<float> _staminaCostForInstantMove = null;
        private ReactiveVariable<bool> _inInstantMoveProcess = null;
        private ICompositeCondition _canMove = null;

        // Runtime
        private IDisposable _startMoveRequestDisposable = null;

        public void OnInit(Entity entity)
        {
            _startMoveRequest = entity.StartInstantMoveRequest;
            _startMoveEvent = entity.StartInstantMoveEvent;
            _currentStamina = entity.CurrentStamina;
            _staminaCostForInstantMove = entity.StaminaCostForInstantMove;
            _inInstantMoveProcess = entity.InInstantMoveProcess;
            _canMove = entity.CanMove;

            _startMoveRequestDisposable = _startMoveRequest.Subscribe(OnStartMoveRequest);
        }

        public void OnDispose()
            => _startMoveRequestDisposable.Dispose();

        private void OnStartMoveRequest()
        {
            if (_canMove.Evaluate() == false)
            {
                Debug.Log($"CAN'T MOVE! Current stamina:{_currentStamina.Value} Move stamina cost: {_staminaCostForInstantMove.Value}");
                return;
            }

            _currentStamina.Value -= _staminaCostForInstantMove.Value;
            Debug.Log($"CURRENT STAMINA: {_currentStamina.Value}");

            _inInstantMoveProcess.Value = true;

            _startMoveEvent.Invoke();
        }
    }
}