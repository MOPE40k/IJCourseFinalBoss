using System;

namespace Runtime.Gameplay.Features.Ai
{
    public interface IBrain : IDisposable
    {
        void Enable();

        void Disable();

        void UpdateTick(float deltaTime);
    }
}