using Runtime.Gameplay.EntitiesCore;
using UnityEngine;

namespace Runtime.Gameplay.Common
{
    public class RigidbodyComponent : IEntityComponent
    {
        public Rigidbody Value = null;
    }

    public class CharacterControllerComponent : IEntityComponent
    {
        public CharacterController Value = null;
    }

    public class TransformComponent : IEntityComponent
    {
        public Transform Value = null;
    }
}