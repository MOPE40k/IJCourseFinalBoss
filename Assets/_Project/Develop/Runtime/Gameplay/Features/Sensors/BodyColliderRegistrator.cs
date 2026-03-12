using Runtime.Gameplay.EntitiesCore;
using Runtime.Gameplay.EntitiesCore.Mono;
using UnityEngine;

namespace Runtime.Gameplay.Features.Sensors
{
    public class BodyColliderRegistrator : MonoEntityRegistrator
    {
        [Header("References:")]
        [SerializeField] private SphereCollider _collider = null;

        public override void Register(Entity entity)
            => entity.AddBodyCollider(_collider);
    }
}