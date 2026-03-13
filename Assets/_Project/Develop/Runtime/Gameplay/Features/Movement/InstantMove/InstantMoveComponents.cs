using Runtime.Gameplay.EntitiesCore;
using Runtime.Utils.Reactive;
using UnityEngine;

namespace Runtime.Gameplay.Features.Movement.InstantMove
{
    public class StartInstantMoveRequest : IEntityComponent
    {
        public ReactiveEvent Value = null;
    }

    public class StartInstantMoveEvent : IEntityComponent
    {
        public ReactiveEvent Value = null;
    }

    public class EndInstantMoveEvent : IEntityComponent
    {
        public ReactiveEvent Value = null;
    }

    public class InInstantMoveProcess : IEntityComponent
    {
        public ReactiveVariable<bool> Value = null;
    }

    public class InstantMoveProcessInitialTime : IEntityComponent
    {
        public ReactiveVariable<float> Value = null;
    }

    public class InstantMoveProcessCurrentTime : IEntityComponent
    {
        public ReactiveVariable<float> Value = null;
    }

    public class StartPosition : IEntityComponent
    {
        public ReactiveVariable<Vector3> Value = null;
    }

    public class InstantMoveDestinationPosition : IEntityComponent
    {
        public ReactiveVariable<Vector3> Value = null;
    }

    public class MoveRadius : IEntityComponent
    {
        public ReactiveVariable<float> Value = null;
    }

    public class InstantMoveStaminaCost : IEntityComponent
    {
        public ReactiveVariable<float> Value = null;
    }
}