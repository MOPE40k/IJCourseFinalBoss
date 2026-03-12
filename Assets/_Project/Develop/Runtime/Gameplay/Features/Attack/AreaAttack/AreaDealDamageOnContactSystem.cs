using Runtime.Gameplay.EntitiesCore;
using Runtime.Gameplay.EntitiesCore.Systems;
using Runtime.Gameplay.Features.ApplyDamage;
using Runtime.Utils;
using Runtime.Utils.Reactive;
using UnityEngine;

namespace Runtime.Gameplay.Features.Attack.AreaAttack
{
    public class AreaDealDamageOnContactSystem : IInitializableSystem, IUpdatableSystem
    {
        // References
        private Buffer<Collider> _colliders = null;
        private Buffer<Entity> _entities = null;
        private ReactiveVariable<float> _damage = null;

        public void OnInit(Entity entity)
        {
            _colliders = entity.AreaContactCollidersBuffer;
            _entities = entity.AreaContactEntitiesBuffer;
            _damage = entity.AreaAttackDamage;
        }

        public void OnUpdateTick(float deltaTime)
        {
            for (int i = 0; i < _entities.Count; i++)
            {
                Entity contactEntity = _entities.Items[i];

                if (contactEntity.HasComponent<TakeDamageRequest>())
                    contactEntity.TakeDamageRequest.Invoke(_damage.Value);
            }

            _colliders.Count = 0;
            _entities.Count = 0;
        }
    }
}