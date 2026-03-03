namespace Runtime.Gameplay.EntitiesCore.Features
{
    public interface IFixedUpdatableSystem : IEntitySystem
    {
        void OnFixedUpdateTick(float fixedDeltaTime);
    }
}