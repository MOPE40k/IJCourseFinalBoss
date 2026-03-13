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
        // References
        private ReactiveVariable<bool> _inInstantMoveProcess = null;
        private ReactiveVariable<float> _currentStamina = null;
        private ReactiveVariable<float> _instantMoveStaminaCost = null;
        private ICompositeCondition _canMove = null;
        private ReactiveEvent _startMoveRequest = null;
        private ReactiveEvent _startMoveEvent = null;

        // Runtime
        private IDisposable _startMoveRequestDisposable = null;

        public void OnInit(Entity entity)
        {
            _inInstantMoveProcess = entity.InInstantMoveProcess;
            _canMove = entity.CanMove;
            _currentStamina = entity.CurrentStamina;
            _instantMoveStaminaCost = entity.InstantMoveStaminaCost;
            _startMoveRequest = entity.StartInstantMoveRequest;
            _startMoveEvent = entity.StartInstantMoveEvent;

            _startMoveRequestDisposable = _startMoveRequest.Subscribe(OnStartMoveRequest);
        }

        public void OnDispose()
            => _startMoveRequestDisposable.Dispose();

        private void OnStartMoveRequest()
        {
            if (_canMove.Evaluate() == false)
            {
                Debug.Log($"CAN'T MOVE! Current stamina:{_currentStamina.Value} Move stamina cost: {_instantMoveStaminaCost.Value}");
                return;
            }

            _currentStamina.Value -= _instantMoveStaminaCost.Value;
            Debug.Log($"CURRENT STAMINA: {_currentStamina.Value}");

            _inInstantMoveProcess.Value = true;

            _startMoveEvent.Invoke();
        }
    }
}