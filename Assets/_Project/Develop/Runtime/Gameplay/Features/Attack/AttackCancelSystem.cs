using Runtime.Gameplay.EntitiesCore;
using Runtime.Gameplay.EntitiesCore.Systems;
using Runtime.Utils.Conditions;
using Runtime.Utils.Reactive;
using UnityEngine;

namespace Runtime.Gameplay.Features.Attack
{
    public class AttackCancelSystem : IInitializableSystem, IUpdatableSystem
    {
        // References
        private ReactiveVariable<bool> _inAttackProcess = null;
        private ReactiveEvent _attackCanceledEvent = null;
        private ICompositeCondition _mustCanceledAttack = null;

        public void OnInit(Entity entity)
        {
            _inAttackProcess = entity.InAttackProcess;
            _attackCanceledEvent = entity.AttackCanceledEvent;
            _mustCanceledAttack = entity.MustCanceledAttack;
        }

        public void OnUpdateTick(float deltaTime)
        {
            if (_inAttackProcess.Value == false)
                return;

            if (_mustCanceledAttack.Evaluate())
            {
                Debug.Log("ATTACK CANCELED!");

                _inAttackProcess.Value = false;

                _attackCanceledEvent.Invoke();
            }
        }
    }
}