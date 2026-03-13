using UnityEngine;

namespace Runtime.Gameplay.Features.InputFeature
{
    public interface IInputService
    {
        bool IsEnabled { get; set; }
        Vector3 Direction { get; }
        Vector3 MousePosition { get; }
        bool IsFire { get; }
    }
}