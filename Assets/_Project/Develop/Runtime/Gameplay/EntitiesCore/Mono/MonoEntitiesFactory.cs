using System;
using System.Collections.Generic;
using Runtime.CommonInfrastracture.DI;
using UnityEngine;
using Utils.AssetsManagement;

namespace Runtime.Gameplay.EntitiesCore.Mono
{
    public class MonoEntitiesFactory : IInitable, IDisposable
    {
        // References
        private readonly ResourcesAssetsLoader _assetsLoader = null;
        private readonly EntitiesLifeContext _entitiesLifeContext = null;
        private readonly CollidersRegistryService _collidersRegistryService = null;

        // Runtime
        private readonly Dictionary<Entity, MonoEntity> _entityToMono = new();

        public MonoEntitiesFactory(
            ResourcesAssetsLoader assetsLoader,
            EntitiesLifeContext entitiesLifeContext,
            CollidersRegistryService collidersRegistryService)
        {
            _assetsLoader = assetsLoader;
            _entitiesLifeContext = entitiesLifeContext;
            _collidersRegistryService = collidersRegistryService;
        }

        public MonoEntity Create(Entity entity, Vector3 position, string path)
        {
            MonoEntity prefab = _assetsLoader.Load<MonoEntity>(path);

            MonoEntity viewInstance = GameObject.Instantiate(prefab, position, Quaternion.identity, null);

            viewInstance.Init(_collidersRegistryService);

            viewInstance.Link(entity);

            _entityToMono.Add(entity, viewInstance);

            return viewInstance;
        }

        public void Init()
        {
            _entitiesLifeContext.Released += OnEntityReleased;
        }

        public void Dispose()
        {
            _entitiesLifeContext.Released -= OnEntityReleased;

            foreach (Entity entity in _entityToMono.Keys)
                CleanupFor(entity);

            _entityToMono.Clear();
        }

        private void CleanupFor(Entity entity)
        {
            MonoEntity monoEntity = _entityToMono[entity];

            monoEntity.Cleanup(entity);

            GameObject.Destroy(monoEntity.gameObject);
        }

        private void OnEntityReleased(Entity entity)
        {
            CleanupFor(entity);

            _entityToMono.Remove(entity);
        }
    }
}