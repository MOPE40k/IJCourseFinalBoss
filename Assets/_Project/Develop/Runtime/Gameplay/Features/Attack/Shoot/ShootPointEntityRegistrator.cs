using Runtime.Gameplay.EntitiesCore;
using Runtime.Gameplay.EntitiesCore.Mono;
using UnityEngine;

namespace Runtime.Gameplay.Features.Attack.Shoot
{
    public class ShootPointEntityRegistrator : MonoEntityRegistrator
    {
        [Header("References:")]
        [SerializeField] private Transform _shootPoint = null;

        public override void Register(Entity entity)
            => entity.AddShootPoint(_shootPoint);
    }
}