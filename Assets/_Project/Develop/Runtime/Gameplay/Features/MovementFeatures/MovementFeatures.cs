using UnityEngine;
using Runtime.Gameplay.EntitiesCore;
using Runtime.Utils.Reactive;

namespace Runtime.Gameplay.Features.MovementFeatures
{
    public class MoveDirection : IEntityComponent
    {
        public ReactiveVeriable<Vector3> Value = new(Vector3.zero);
    }

    public class MoveSpeed : IEntityComponent
    {
        public ReactiveVeriable<float> Value = new(0f);
    }

    public class RotateSpeed : IEntityComponent
    {
        public ReactiveVeriable<float> Value = new(0f);
    }
}