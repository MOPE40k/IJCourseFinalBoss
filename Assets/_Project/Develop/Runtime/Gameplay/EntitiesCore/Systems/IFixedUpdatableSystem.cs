namespace Runtime.Gameplay.EntitiesCore.Systems
{
    public interface IFixedUpdatableSystem : IEntitySystem
    {
        void OnFixedUpdateTick(float fixedDeltaTime);
    }
}