using UnityEngine;
using Runtime.Gameplay.EntitiesCore;
using Runtime.Gameplay.EntitiesCore.Mono;

namespace Runtime.Gameplay.Common
{
    public class CharacterControllerEntityRegistrator : MonoEntityRegistrator
    {
        public override void Register(Entity entity)
        {
            entity.AddCharacterController(GetComponent<CharacterController>());
        }
    }
}