using System;
using System.Collections.Generic;

namespace Runtime.Gameplay.EntitiesCore
{
    public class EntitiesLifeContext : IDisposable
    {
        // Delegates
        public event Action<Entity> Added = null;
        public event Action<Entity> Released = null;

        // Runtime
        private readonly List<Entity> _entities = new();
        private readonly List<Entity> _releaseRequests = new();

        public void Add(Entity entity)
        {
            _entities.Add(entity);

            entity.Init();

            Added?.Invoke(entity);
        }

        public void UpdateTick(float deltaTime)
        {
            for (int i = 0; i < _entities.Count; i++)
                _entities[i].UpdateTick(deltaTime);

            foreach (Entity entity in _releaseRequests)
            {
                _entities.Remove(entity);

                entity.Dispose();

                Released?.Invoke(entity);
            }

            _releaseRequests.Clear();
        }

        public void FixedUpdateTick(float fixedDeltaTime)
        {
            for (int i = 0; i < _entities.Count; i++)
                _entities[i].FixedUpdateTick(fixedDeltaTime);
        }

        public void Release(Entity entity)
            => _releaseRequests.Add(entity);

        public void Dispose()
        {
            foreach (Entity entity in _entities)
                entity.Dispose();

            _entities.Clear();

            _releaseRequests.Clear();
        }
    }
}