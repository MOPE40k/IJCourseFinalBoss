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

            RemoveElementFromBuffer<Collider>.Remove(_collider, _contacts);
        }
    }
}