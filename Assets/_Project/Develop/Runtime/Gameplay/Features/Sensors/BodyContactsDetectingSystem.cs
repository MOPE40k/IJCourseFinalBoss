using Runtime.Gameplay.EntitiesCore;
using Runtime.Gameplay.EntitiesCore.Systems;
using Runtime.Utils;
using UnityEngine;

namespace Runtime.Gameplay.Features.Sensors
{
    public class BodyContactsDetectingSystem : IInitializableSystem, IFixedUpdatableSystem
    {
        // References
        private Buffer<Collider> _contacts = null;
        private LayerMask _mask = 0;
        private SphereCollider _collider = null;

        public void OnInit(Entity entity)
        {
            _contacts = entity.ContactCollidersBuffer;
            _mask = entity.ContactsDetectingMask;
            _collider = entity.BodyCollider;
        }

        public void OnFixedUpdateTick(float fixedDeltaTime)
        {
            _contacts.Count = Physics.OverlapSphereNonAlloc(
                _collider.bounds.center,
                _collider.radius,
                _contacts.Items,
                _mask,
                QueryTriggerInteraction.Ignore);

            RemoveSelfFromContacts();
        }

        private void RemoveSelfFromContacts()
        {
            int indexToRemove = -1;

            for (int i = 0; i < _contacts.Count; i++)
            {
                if (_contacts.Items[i] == _collider)
                {
                    indexToRemove = i;

                    break;
                }
            }

            if (indexToRemove >= 0)
            {
                _contacts.Items[indexToRemove] = _contacts.Items[_contacts.Count - 1];

                _contacts.Count--;

                _contacts.Items[_contacts.Count] = null;
            }
        }
    }
}