using Runtime.Gameplay.EntitiesCore;
using Runtime.Utils;
using Runtime.Utils.Reactive;
using UnityEngine;

namespace Runtime.Gameplay.Features.Sensors
{
    public class BodyCollider : IEntityComponent
    {
        public SphereCollider Value = null;
    }

    public class ContactsDetectingMask : IEntityComponent
    {
        public LayerMask Value = 0;
    }

    public class ContactCollidersBuffer : IEntityComponent
    {
        public Buffer<Collider> Value = null;
    }

    public class AreaContactCollidersBuffer : IEntityComponent
    {
        public Buffer<Collider> Value = null;
    }

    public class ContactEntitiesBuffer : IEntityComponent
    {
        public Buffer<Entity> Value = null;
    }

    public class AreaContactEntitiesBuffer : IEntityComponent
    {
        public Buffer<Entity> Value = null;
    }

    public class DeathMask : IEntityComponent
    {
        public LayerMask Value = 0;
    }

    public class IsTouchDeathMask : IEntityComponent
    {
        public ReactiveVariable<bool> Value = null;
    }
}