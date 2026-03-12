using Runtime.Gameplay.EntitiesCore;
using Runtime.Gameplay.EntitiesCore.Systems;
using Runtime.Utils;
using UnityEngine;

namespace Runtime.Gameplay.Features.Sensors
{
    public class AreaContactsEntityFilterSystem : IInitializableSystem, IUpdatableSystem
    {
        // References
        private readonly CollidersRegistryService _collidersRegistryService = null;
        private Buffer<Collider> _colliders = null;
        private Buffer<Entity> _entities = null;

        public AreaContactsEntityFilterSystem(CollidersRegistryService collidersRegistryService)
            => _collidersRegistryService = collidersRegistryService;

        public void OnInit(Entity entity)
        {
            _colliders = entity.AreaContactCollidersBuffer;
            _entities = entity.AreaContactEntitiesBuffer;
        }

        public void OnUpdateTick(float deltaTime)
        {
            _entities.Count = 0;

            for (int i = 0; i < _colliders.Count; i++)
            {
                Collider collider = _colliders.Items[i];

                if (_collidersRegistryService.TryGetBy(collider, out Entity entity))
                {
                    _entities.Items[_entities.Count] = entity;

                    _entities.Count++;
                }
            }
        }
    }
}