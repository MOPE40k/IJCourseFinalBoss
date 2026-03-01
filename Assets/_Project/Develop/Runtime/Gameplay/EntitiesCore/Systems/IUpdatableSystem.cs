namespace Runtime.Gameplay.EntitiesCore.Systems
{
    public interface IUpdatableSystem : IEntitySystem
    {
        void OnUpdateTick(float deltaTime);
    }
}