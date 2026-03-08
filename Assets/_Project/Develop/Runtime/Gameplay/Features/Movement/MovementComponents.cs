using UnityEngine;
using Runtime.Gameplay.EntitiesCore;
using Runtime.Utils.Reactive;
using Runtime.Utils.Conditions;

namespace Runtime.Gameplay.Features.Movement
{
    public class MoveDirection : IEntityComponent
    {
        public ReactiveVariable<Vector3> Value = null;
    }

    public class MoveSpeed : IEntityComponent
    {
        public ReactiveVariable<float> Value = null;
    }

    public class IsMoving : IEntityComponent
    {
        public ReactiveVariable<bool> Value = null;
    }

    public class RotationDirection : IEntityComponent
    {
        public ReactiveVariable<Vector3> Value = null;
    }

    public class RotationSpeed : IEntityComponent
    {
        public ReactiveVariable<float> Value = null;
    }

    public class CanMove : IEntityComponent
    {
        public ICompositeCondition Value = null;
    }

    public class CanRotate : IEntityComponent
    {
        public ICompositeCondition Value = null;
    }
}