namespace Runtime.Gameplay.EntitiesCore.Features
{
    public interface IUpdatableSystem : IEntitySystem
    {
        void OnUpdateTick(float deltaTime);
    }
}