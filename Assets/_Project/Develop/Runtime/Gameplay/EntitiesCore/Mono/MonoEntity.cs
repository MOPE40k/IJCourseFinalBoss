using UnityEngine;

namespace Runtime.Gameplay.EntitiesCore.Mono
{
    public class MonoEntity : MonoBehaviour
    {
        // References
        private CollidersRegistryService _collidersRegistryService = null;
        private Entity _linkedEntity = null;

        // Runtime
        public Entity LinkedEntity => _linkedEntity;

        public void Init(CollidersRegistryService collidersRegistryService)
            => _collidersRegistryService = collidersRegistryService;

        public void Link(Entity entity)
        {
            _linkedEntity = entity;

            MonoEntityRegistrator[] registrators = GetComponentsInChildren<MonoEntityRegistrator>();

            if (registrators != null)
                foreach (MonoEntityRegistrator registrator in registrators)
                    registrator.Register(entity);

            foreach (Collider collider in GetComponentsInChildren<Collider>())
                _collidersRegistryService.Register(collider, entity);
        }

        public void Cleanup(Entity entity)
        {
            foreach (Collider collider in GetComponentsInChildren<Collider>())
                _collidersRegistryService.Unregister(collider);

            _linkedEntity = null;
        }
    }
}