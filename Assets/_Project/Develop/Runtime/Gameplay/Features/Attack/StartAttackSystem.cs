using System;
using Runtime.Gameplay.EntitiesCore;
using Runtime.Gameplay.EntitiesCore.Systems;
using Runtime.Utils.Conditions;
using Runtime.Utils.Reactive;
using UnityEngine;

namespace Runtime.Gameplay.Features.Attack
{
    public class StartAttackSystem : IInitializableSystem, IDisposableSystem
    {
        // References
        private ReactiveEvent _startAttackRequest = null;
        private ReactiveEvent _startAttackEvent = null;
        private ReactiveVariable<bool> _inAttackProcess = null;
        private ICompositeCondition _canStartAttack = null;

        // Runtime
        private IDisposable _attackRequestDisposable = null;

        public void OnInit(Entity entity)
        {
            _startAttackRequest = entity.StartAttackRequest;
            _startAttackEvent = entity.StartAttackEvent;
            _inAttackProcess = entity.InAttackProcess;
            _canStartAttack = entity.CanStartAttack;

            _attackRequestDisposable = _startAttackRequest.Subscribe(OnStartAttackRequest);
        }

        public void OnDispose()
        {
            _attackRequestDisposable.Dispose();
        }

        private void OnStartAttackRequest()
        {
            if (_canStartAttack.Evaluate())
            {
                _inAttackProcess.Value = true;

                _startAttackEvent.Invoke();

                Debug.Log("Start attack!");
            }
            else
            {
                Debug.Log("Can't attack!");
            }
        }
    }
}