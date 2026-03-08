using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Gameplay.EntitiesCore
{
    public class CollidersRegistryService
    {
        // Runtime
        private readonly Dictionary<Collider, Entity> _colliderToEntity = new();

        public void Register(Collider collider, Entity entity)
            => _colliderToEntity.Add(collider, entity);

        public void Unregister(Collider collider)
            => _colliderToEntity.Remove(collider);

        public Entity GetBy(Collider collider)
        {
            if (_colliderToEntity.TryGetValue(collider, out Entity entity))
                return entity;

            return null;
        }

        public bool TryGetBy(Collider collider, out Entity entity)
        {
            if (_colliderToEntity.TryGetValue(collider, out entity))
                return true;

            entity = null;
            return false;
        }
    }
}