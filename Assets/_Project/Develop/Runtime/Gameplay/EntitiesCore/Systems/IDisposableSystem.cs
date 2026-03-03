namespace Runtime.Gameplay.EntitiesCore.Features
{
    public interface IDisposableSystem : IEntitySystem
    {
        void OnDispose();
    }
}