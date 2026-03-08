using System;
using System.Linq;
using Runtime.Gameplay.EntitiesCore;
using Runtime.Gameplay.EntitiesCore.Systems;
using Runtime.Utils;
using Runtime.Utils.Reactive;
using UnityEngine;

namespace Runtime.Gameplay.Features.Sensors
{
    public class AreaContactsDetectingSystem : IInitializableSystem, IDisposableSystem
    {
        // References
        private ReactiveVariable<float> _areaRadius = null;
        private Buffer<Collider> _areaContacts = null;
        private LayerMask _mask = 0;
        private SphereCollider _collider = null;
        private ReactiveEvent _endInstantMoveEvent = null;

        // Runtime
        private IDisposable _endInstantMoveEventDisposable = null;

        public void OnInit(Entity entity)
        {
            _areaRadius = entity.AreaAttackRadius;
            _areaContacts = entity.AreaContactCollidersBuffer;
            _mask = entity.ContactsDetectingMask;
            _collider = entity.BodyCollider;
            _endInstantMoveEvent = entity.EndInstantMoveEvent;

            _endInstantMoveEventDisposable = _endInstantMoveEvent.Subscribe(OnEndInstantMove);
        }

        public void OnDispose()
            => _endInstantMoveEventDisposable.Dispose();

        private void OnEndInstantMove()
        {
            _areaContacts.Count = Physics.OverlapSphereNonAlloc(
                _collider.bounds.center,
                _areaRadius.Value,
                _areaContacts.Items,
                _mask,
                QueryTriggerInteraction.Ignore);

            RemoveSelfFromContacts();
        }

        private void RemoveSelfFromContacts()
        {
            int indexToRemove = -1;

            for (int i = 0; i < _areaContacts.Count; i++)
            {
                if (_areaContacts.Items[i] == _collider)
                {
                    indexToRemove = i;

                    break;
                }
            }

            if (indexToRemove >= 0)
            {
                _areaContacts.Items[indexToRemove] = _areaContacts.Items[_areaContacts.Count - 1];

                _areaContacts.Count--;

                _areaContacts.Items[_areaContacts.Count] = null;
            }
        }
    }
}