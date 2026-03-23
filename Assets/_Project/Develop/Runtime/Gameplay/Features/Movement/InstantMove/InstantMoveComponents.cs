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

    public class StartPositionBeforeInstantMove : IEntityComponent
    {
        public ReactiveVariable<Vector3> Value = null;
    }

    public class EndPositionForInstantMove : IEntityComponent
    {
        public ReactiveVariable<Vector3> Value = null;
    }

    public class RadiusForInstantMove : IEntityComponent
    {
        public ReactiveVariable<float> Value = null;
    }

    public class StaminaCostForInstantMove : IEntityComponent
    {
        public ReactiveVariable<float> Value = null;
    }

    public class HasEnoughStaminaForInstantMove : IEntityComponent
    {
        public ReactiveVariable<bool> Value = null;
    }
}