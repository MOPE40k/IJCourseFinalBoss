using UnityEngine;

namespace Runtime.Gameplay.Features.Ai.States.InstantMove
{
    public interface IInstantMoveEndPointProvider
    {
        Vector3 GetDirection();
    }
}