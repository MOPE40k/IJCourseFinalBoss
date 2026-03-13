using System;
using System.Collections.Generic;
using Runtime.Gameplay.EntitiesCore;

namespace Runtime.Gameplay.Features.Ai
{
    public class AiBrainsContext : IDisposable
    {
        private readonly List<EntityToBrain> _entityToBrains = new();

        public void SetFor(Entity entity, IBrain brain)
        {
            foreach (EntityToBrain entityToBrain in _entityToBrains)
            {
                if (entityToBrain.Entity == entity)
                {
                    entityToBrain.Brain.Disable();
                    entityToBrain.Brain.Dispose();
                    entityToBrain.Brain = brain;
                    entityToBrain.Brain.Enable();

                    return;
                }
            }

            _entityToBrains.Add(new EntityToBrain(entity, brain));

            brain.Enable();
        }

        public void UpdateTick(float deltaTime)
        {
            for (int i = 0; i < _entityToBrains.Count; i++)
            {
                if (_entityToBrains[i].Entity.IsInit == false)
                {
                    int lastIndex = _entityToBrains.Count - 1;

                    _entityToBrains[i].Entity.Dispose();
                    _entityToBrains[i] = _entityToBrains[lastIndex];
                    _entityToBrains.RemoveAt(lastIndex);
                    i--;

                    continue;
                }

                _entityToBrains[i].Brain.UpdateTick(deltaTime);
            }
        }

        public void Dispose()
        {
            foreach (EntityToBrain entityToBrain in _entityToBrains)
                entityToBrain.Brain.Dispose();

            _entityToBrains.Clear();
        }

        private class EntityToBrain
        {
            public Entity Entity = null;
            public IBrain Brain = null;

            public EntityToBrain(Entity entity, IBrain brain)
            {
                Entity = entity;
                Brain = brain;
            }
        }
    }
}